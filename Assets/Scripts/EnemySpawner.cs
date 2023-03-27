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
<<<<<<< HEAD
        timer += 1f * Time.deltaTime;
        CountDown -= 1f * Time.deltaTime; 
        Spawn();
        EndWave(); 
=======
        timer += 1 * Time.deltaTime;
        Spawn(); 
>>>>>>> a521c87f111ca5f5c06e1b3e643e8e5f1e4656c6
    }


    // Allows Enemy Prefabs to be created based off of a timer.
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

<<<<<<< HEAD

    // Discontinues spawning after a minute 31 seconds.
    void EndWave()
    {
        if (CountDown <= 0f)
        {
            spawn = false; 
        }
    }
=======
>>>>>>> a521c87f111ca5f5c06e1b3e643e8e5f1e4656c6
}
