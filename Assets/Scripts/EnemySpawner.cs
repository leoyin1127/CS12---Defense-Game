using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnrate = 1f;
    private float timer = 0;


    public float CountDown = 61f;
    public float ShopTime = 20f; 


    public bool spawn = true;  
    public float HeightOffSet = 3.78f;
  
   
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1f * Time.deltaTime;
        CountDown -= 1f * Time.deltaTime; 
        Spawn();
        WaveIndex(); 
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
    void WaveIndex()
    {
        if (CountDown <= 0f)
        {
            spawn = false;
            ShopTime -= 1f * Time.deltaTime;
            if (ShopTime <= 0f)
            {
                CountDown = 61f;
                spawn = true; 
            }
        }
    }
}
