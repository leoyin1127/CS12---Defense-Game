using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankyEnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnRate = 6f;
    private float timer = 0;
    private float countDown = 45f;
    private bool spawn = true;
    private float heightOffSet = 3.85f;
    private bool allowSpawn = false;
    private WaveIndex waveSpawn;

    
    public float SpawnRate
    {
        get { return spawnRate; }
        set { spawnRate = value; }
    }

    public float CountDown
    {
        get { return countDown; }
        set { countDown = value; }
    }

    public bool Spawn
    {
        get { return spawn; }
        set { spawn = value; }
    }

    public float HeightOffSet
    {
        get { return heightOffSet; }
        set { heightOffSet = value; }
    }

    public bool AllowSpawn
    {
        get { return allowSpawn; }
        set { allowSpawn = value; }
    }

    private void Awake()
    {
        waveSpawn = FindObjectOfType<WaveIndex>();
    }

    private void Start()
    {
        Spawning();
    }

    private void Update()
    {
        timer += 1f * Time.deltaTime;
        CountDown -= 1f * Time.deltaTime;
        CheckSpawn();
        EndWave();
    }

    private void CheckSpawn()
    {
        if (WaveIndex.Waveindex >= 3)
        {
            AllowSpawn = true;
            if (AllowSpawn == true)
            {
                Spawning();
            }
        }
    }

    public void Spawning()
    {
        if (timer >= SpawnRate && Spawn == true)
        {
            float lowestpoint = transform.position.y - HeightOffSet;
            float highestpoint = transform.position.y + HeightOffSet;

            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), -3), transform.rotation);
            timer = 0;
        }
    }

    public void EndWave()
    {
        if (CountDown <= 0f)
        {
            spawn = false;
            if (WaveIndex.Waveindex >= 3)
            {
                CountDown = 45f;
                spawn = true;
                if (WaveIndex.Waveindex > 3)
                {
                    SpawnRate *= 0.95f;
                    Debug.Log("tanky invader increase spawnrate");
                }
            }
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TankyEnemySpawner : MonoBehaviour
//{
//    public GameObject Enemy;
//    public float spawnrate = 1f;
//    private float timer = 0;
//    public float CountDown = 45f;
//    public static bool spawn = true;
//    public float HeightOffSet = 3.78f;
//    public static bool allowspawn = false;
//    private WaveIndex wavespawn;

//    void Awake()
//    {
//        wavespawn = FindObjectOfType<WaveIndex>();
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        Spawn();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        timer += 1f * Time.deltaTime;
//        CountDown -= 1f * Time.deltaTime;
//        CheckSpawn();
//        EndWave();
//    }

//    void CheckSpawn()
//    {
//        //Debug.Log(WaveIndex.Waveindex);
//        if (WaveIndex.Waveindex >= 3)
//        {
//            allowspawn = true;
//            if (allowspawn == true)
//            {
//                //Debug.Log("invader spawn");
//                Spawn();
//            }
//        }
//    }

//    public void Spawn()
//    {
//        if (timer >= spawnrate && spawn == true)
//        {
//            //Debug.Log("invader spawn spawn");
//            float lowestpoint = transform.position.y - HeightOffSet;
//            float highestpoint = transform.position.y + HeightOffSet;

//            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), -3), transform.rotation);
//            timer = 0;
//        }
//    }
//    public void EndWave()
//    {
//        if (CountDown <= 0f)
//        {
//            spawn = false;
//            //Debug.Log(WaveIndex.Waveindex);
//            if (WaveIndex.Waveindex >= 3)
//            {
//                CountDown = 45f;
//                spawn = true;
//                if (WaveIndex.Waveindex > 3)
//                {
//                    spawnrate *= 0.95f;
//                    Debug.Log("tanky invader increase spawnrate");
//                }
//            }
//        }
//    }
//}