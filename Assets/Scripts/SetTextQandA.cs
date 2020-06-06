using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextQandA : MonoBehaviour
{
    public int i;
    //public Text thisText;


    void Update()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = Quiz.QuestionsAndAnswers[i];
    }

}