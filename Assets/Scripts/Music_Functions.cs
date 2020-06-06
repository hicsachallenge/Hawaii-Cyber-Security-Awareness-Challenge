using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Functions : MonoBehaviour
{
    public AudioSource backgroundMusic;

    public void toggleMusic(){
        if(backgroundMusic.isPlaying){
            backgroundMusic.Pause();
        }else{
            backgroundMusic.UnPause();
        }
    }

    public void increaseVolume(){
        backgroundMusic.volume += .1f;

        if(backgroundMusic.volume >= 1.0f){
            backgroundMusic.volume = 1.0f;
        }
    }

    public void decreaseVolume(){
        backgroundMusic.volume -= .1f;
        
        if(backgroundMusic.volume <= 0.0f){
            backgroundMusic.volume = 0.0f;
        }
    }

}
