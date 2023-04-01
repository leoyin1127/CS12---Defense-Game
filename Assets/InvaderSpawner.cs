using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnrate = 1f;
    private float timer = 0;
    public float CountDown = 91f;
    public static bool spawn = true;
    public float HeightOffSet = 3.78f;
    private InvaderMovement invadermove;

    void Awake()
    {
        invadermove = FindObjectOfType<InvaderMovement>();
    }

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
        EndWave();
    }

    void Spawn()
    {
        if (timer >= spawnrate && spawn == true && InvaderMovement.allowmove == true)
        {
            float lowestpoint = transform.position.y - HeightOffSet;
            float highestpoint = transform.position.y + HeightOffSet;

            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), -3), transform.rotation);
            timer = 0;
        }
    }
    void EndWave()
    {
        if (CountDown <= 0f)
        {
            spawn = false;
            CountDown = 91f;
        }
    }
}
