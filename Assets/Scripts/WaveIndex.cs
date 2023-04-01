using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIndex : MonoBehaviour
{
    public static int Waveindex = 1;
    private EnemySpawner timer;
    private SpeedyInvaderMovement speedyinvader;
    private InvaderMovement invader;
    private TankyInvaderMovement tankyinvader;
   //ublic bool movedAllowed = false;

    void Awake()
    {
        Debug.Log(Waveindex);
        timer = FindObjectOfType<EnemySpawner>();
        speedyinvader = FindObjectOfType<SpeedyInvaderMovement>();
        invader = FindObjectOfType<InvaderMovement>();
        tankyinvader = FindObjectOfType<TankyInvaderMovement>();
       
    }


    void Update()
    {
        NewWave();
    }

    //void FirstWave()
    //{
    //    Debug.Log("Firstwave");
    //    if (Waveindex == 1)
    //    {
    //        Debug.Log("waveindex = 1");
    //        InvaderMovement.allowmove = false;
    //        Debug.Log(InvaderMovement.allowmove);
    //        TankyInvaderMovement.allowmove = false;
    //    }
    //}

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
