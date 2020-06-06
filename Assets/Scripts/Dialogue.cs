using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        //Dialogue base
        public string name;
        public Sprite portrait;
        [TextArea(3, 10)]
        public string myText;
        public string url;
    }

 

    [Header("Insert Dialogue information Below")]
    public Info[] dialogueInfo;


}
