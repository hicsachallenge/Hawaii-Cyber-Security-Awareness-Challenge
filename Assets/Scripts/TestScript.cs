using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Dialogue dialogue;
    private bool clicked;

    void Start()
    {
        clicked = false;
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        clicked = true;
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        if (!clicked)
    //        {
                
    //        }

    //    }

    //}

}
