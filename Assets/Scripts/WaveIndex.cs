using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveIndex : MonoBehaviour
{
    public static int Waveindex = 1;
    private EnemySpawner timer;
    private SpeedyInvaderMovement speedyinvader;
    private InvaderMovement invader;
    private TankyInvaderMovement tankyinvader;

    public Text WaveIndexText;

    void Awake()
    {
        Debug.Log(Waveindex);
        timer = FindObjectOfType<EnemySpawner>();
        speedyinvader = FindObjectOfType<SpeedyInvaderMovement>();
        invader = FindObjectOfType<InvaderMovement>();
        tankyinvader = FindObjectOfType<TankyInvaderMovement>();
        WaveIndexText.text = "Wave Index: " + Waveindex.ToString();
        WaveIndexText.gameObject.SetActive(true);
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
            WaveIndexText.text = "Wave Index: " + Waveindex.ToString();
            EnemySpawner.spawn = true;
        }
    }
}

