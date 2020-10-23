using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource winMusic;

    public AudioSource[] sfx;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGameOver() //stop level music and play gameover music
    {
        levelMusic.Stop();

        gameOverMusic.Play();
    }

    public void playWinMusic()
    {
        levelMusic.Stop();

        winMusic.Play();
    }

    public void Playsfx(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
