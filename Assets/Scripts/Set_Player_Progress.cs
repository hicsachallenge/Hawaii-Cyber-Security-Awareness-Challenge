using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Player_Progress : MonoBehaviour
{
    //public ProgressBar prog;


    public static float getPlayerProgress(){
        float percentage = 0f;

        if(PlayerPrefs.GetInt("InternetTab1") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("InternetTab2") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("InternetTab3") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("InternetTab4") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("InternetTab5") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("EmailTab1") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("EmailTab2") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("EmailTab3") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("EmailTab4") == 1) percentage += 10f;
        if(PlayerPrefs.GetInt("EmailTab5") == 1) percentage += 10f;

        return percentage;
    }

    public void clearPlayerProgress()
    {
        PlayerPrefs.SetInt("InternetTab1", 0);
        PlayerPrefs.SetInt("InternetTab2", 0);
        PlayerPrefs.SetInt("InternetTab3", 0);
        PlayerPrefs.SetInt("InternetTab4", 0);
        PlayerPrefs.SetInt("InternetTab5", 0);

        PlayerPrefs.SetInt("EmailTab1", 0);
        PlayerPrefs.SetInt("EmailTab2", 0);
        PlayerPrefs.SetInt("EmailTab3", 0);
        PlayerPrefs.SetInt("EmailTab4", 0);
        PlayerPrefs.SetInt("EmailTab5", 0);
    }

    public void progressedInternetTab1(){
        PlayerPrefs.SetInt("InternetTab1", 1);
        //prog.IncrementProgress(1);
    }

    public void progressedInternetTab2(){
        PlayerPrefs.SetInt("InternetTab2", 1);
        //prog.IncrementProgress(1);
    }

    public void progressedInternetTab3(){
        PlayerPrefs.SetInt("InternetTab3", 1);
        //prog.IncrementProgress(1);
    }

    public void progressedInternetTab4(){
        PlayerPrefs.SetInt("InternetTab4", 1);
        //prog.IncrementProgress(1);
    }

    public void progressedInternetTab5(){
        PlayerPrefs.SetInt("InternetTab5", 1);
        //prog.IncrementProgress(1);
    }


    public void progressedEmailTab1(){
        PlayerPrefs.SetInt("EmailTab1", 1);
        //prog.IncrementProgress(1);
    }
    public void progressedEmailTab2(){
        PlayerPrefs.SetInt("EmailTab2", 1);
        //prog.IncrementProgress(1);
    }
    public void progressedEmailTab3(){
        PlayerPrefs.SetInt("EmailTab3", 1);
        //prog.IncrementProgress(1);
    }
    public void progressedEmailTab4(){
        PlayerPrefs.SetInt("EmailTab4", 1);
        //prog.IncrementProgress(1);
    }
    public void progressedEmailTab5(){
        PlayerPrefs.SetInt("EmailTab5", 1);
        //prog.IncrementProgress(1);
    }

    
}
