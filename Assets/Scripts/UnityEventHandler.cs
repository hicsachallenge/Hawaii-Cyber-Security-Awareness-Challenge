using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UnityEventHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent eventHandler;
    public Dialogue myDialogue;

    //this is what happens when you click on this button
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        eventHandler.Invoke();
        DialogueManager.instance.CloseOptions();

        if(myDialogue != null)  //if current dialogue is finished
        {
            DialogueManager.instance.EnqueueDialogue(myDialogue);   //queue next dialogue
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //load next scene
        }
    }
}
