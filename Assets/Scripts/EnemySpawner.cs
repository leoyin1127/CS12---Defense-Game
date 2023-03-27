using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnrate = 1f;
    private float timer = 0;
<<<<<<< HEAD
<<<<<<< HEAD
    public float HeightOffSet = 3.85f;
    public float CountDown = 91f;
    public bool spawn = true; 
    
=======
=======
>>>>>>> parent of e6662f0 (Merge)
    public float HeightOffSet = 3.78f;
    public float CountDown;
    private bool spawn; 
  
>>>>>>> parent of e6662f0 (Merge)


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
        EndWave(); 
<<<<<<< HEAD
<<<<<<< HEAD
        timer += 1 * Time.deltaTime;
        Spawn(); 
=======
>>>>>>> parent of e6662f0 (Merge)
=======
>>>>>>> parent of e6662f0 (Merge)
    }


    // Allows Enemy Prefabs to be created based off of a timer.
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


    // Discontinues spawning after a minute 31 seconds.
    void EndWave()
    {
        if (CountDown <= 0f)
        {
            spawn = false; 
        }
    }
}
