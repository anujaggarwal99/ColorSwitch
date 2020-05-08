using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudio : MonoBehaviour
{
    static AudioSource audSrc;
    public static AudioClip starCollect, tap, gameOver,changerSound;
    void Start()
    {
        starCollect = Resources.Load<AudioClip>("star");
        tap = Resources.Load<AudioClip>("jump");
        changerSound = Resources.Load<AudioClip>("button");
        gameOver = Resources.Load<AudioClip>("dead");
        audSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public static void playSound(string audio)
    {
        switch(audio)
        {
            case "tap":
                audSrc.PlayOneShot(tap);
                break;
            case "starCollect":
                audSrc.PlayOneShot(starCollect);
                break;
            
            case "changerSound":
                audSrc.PlayOneShot(changerSound);
                break;
            case "gameOver":
                audSrc.PlayOneShot(gameOver);
                break;
                
        }
    }
}
