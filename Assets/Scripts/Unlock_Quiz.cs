using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Quiz : MonoBehaviour
{
    public GameObject QuizButton;
   
        
    void Update(){
        if(PlayerPrefs.GetInt("InternetTab1") == 1 &&
            (PlayerPrefs.GetInt("InternetTab2") == 1) &&
            (PlayerPrefs.GetInt("InternetTab3") == 1) &&
            (PlayerPrefs.GetInt("InternetTab4") == 1) &&
            (PlayerPrefs.GetInt("InternetTab5") == 1) &&
            (PlayerPrefs.GetInt("EmailTab1") == 1) &&
            (PlayerPrefs.GetInt("EmailTab2") == 1) &&
            (PlayerPrefs.GetInt("EmailTab3") == 1) &&
            (PlayerPrefs.GetInt("EmailTab4") == 1) &&
            (PlayerPrefs.GetInt("EmailTab5") == 1)){
                QuizButton.SetActive(true);
        }
    }
}
