using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnrate = 1f;
    private float timer = 0;
    public float CountDown = 45f;
    public static bool spawn = true;
    public float HeightOffSet = 3.78f;
    public static bool allowspawn = false;
    private WaveIndex wavespawn;

    void Awake()
    {
        wavespawn = FindObjectOfType<WaveIndex>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= 1f * Time.deltaTime;
        CheckSpawn();
        EndWave();
    }

    void CheckSpawn()
    {
        Debug.Log(WaveIndex.Waveindex);
        if (WaveIndex.Waveindex >= 4)
        {
            allowspawn = true;
            if (allowspawn == true)
            {
                timer += 1f * Time.deltaTime;
                Debug.Log("invader spawn");
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        if (timer >= spawnrate && spawn == true)
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
            CountDown = 45f;
            spawn = true;
        }
    }
}
