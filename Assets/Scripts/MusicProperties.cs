using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProperties : MonoBehaviour
{
    private AudioSource MusicPlayer;
    public AudioClip[] Songs;
    [SerializeField] public float SongsPlayed;
    [SerializeField] private bool[] Played; 
    public float Volume; 
    // Start is called before the first frame update
    void Start()
    {
        MusicPlayer = GetComponent<AudioSource>();

        if (!MusicPlayer.isPlaying)
        {
            ChangeSong(Random.Range(0, Songs.Length));
            Played = new bool[Songs.Length]; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        MusicPlayer.volume = Volume;

        if (!MusicPlayer.isPlaying || Input.GetKeyDown(KeyCode.A))
        {
            ChangeSong(Random.Range(0, Songs.Length)); 
        }
        if (SongsPlayed == Songs.Length)
        {
            SongsPlayed = 0;
            for (int i = 0; i < Songs.Length; i++)
            {
                if (i == Songs.Length)
                    break;
                else
                    Played[i] = false;
            }
        }
    }

    public void ChangeSong(int songpicked)
    {
        if (!Played[songpicked])
        {
            SongsPlayed++;
            Played[songpicked] = true;
            MusicPlayer.clip = Songs[songpicked];
            MusicPlayer.Play();
        }
        else
            MusicPlayer.Stop();

    }   
}
