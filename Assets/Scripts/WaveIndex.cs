using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIndex : MonoBehaviour
{
    public static int Waveindex = 1;
    private EnemySpawner timer;
   //ublic bool movedAllowed = false;

    void Awake()
    {
        Debug.Log(Waveindex);
        timer = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        NewWave();
    }

    void NewWave()
    {
        if (EnemySpawner.spawn == false)
        {

            Waveindex += 1;
            Debug.Log(Waveindex);
            EnemySpawner.spawn = true;
            Debug.Log(EnemySpawner.spawn);

           
        }
    }

}
