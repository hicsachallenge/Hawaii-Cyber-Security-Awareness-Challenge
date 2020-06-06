using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "DialogueOptions")]
public class DialogueOptions : Dialogue
{
    [TextArea(2, 10)]
    public string questionText;

    [System.Serializable]
    public class Options
    {
        public string buttonName;
        public Dialogue nextDialogue;   //next dialogue to be played
        public UnityEvent myEvent;
        
    }
    public Options[] optionsInfo;

    
}
