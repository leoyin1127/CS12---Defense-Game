using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnrate = 1f;
    private float timer = 0;
    public float HeightOffSet = 3.78f;
    public float CountDown;
    private bool spawn; 
  


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        CountDown = 91f;
        spawn = true; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1f * Time.deltaTime;
        CountDown -= 1f * Time.deltaTime; 
        Spawn();
        BossMode(); 
    }

    void Spawn()
    {
        if (timer >= spawnrate && spawn == true)
        {
            float lowestpoint = transform.position.y - HeightOffSet;
            float highestpoint = transform.position.y + HeightOffSet;

            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), -3), transform.rotation);
            timer = 0; 
        }
    }
    void BossMode()
    {
        if (CountDown <= 0f)
        {
            spawn = false; 
        }
    }
}
