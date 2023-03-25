using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnrate = 1f;
    private float timer = 0;
    public float HeightOffSet = 3.85f;
  


    // Start is called before the first frame update
    void Start()
    {
       Spawn(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        Spawn(); 
    }

    void Spawn()
    {
        if (timer >= spawnrate)
        {
            float lowestpoint = transform.position.y - HeightOffSet;
            float highestpoint = transform.position.y + HeightOffSet;

            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), -3), transform.rotation);
            timer = 0; 
        }

    }

}
