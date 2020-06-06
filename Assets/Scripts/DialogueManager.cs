using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    public Set_Player_Progress spp;
    public static DialogueManager instance;
    private void Awake()
    {
        
        spp.clearPlayerProgress();
        if (instance != null)
        {
            //Debug.LogWarning("fix this " + gameObject.name);
        }
        else
        {
            instance = this;
        }


    }


    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.0001f;   //how fast text scrolls
    private bool isCurrentlyTyping;
    private string completeText;    //used for autocompleting text
    public string nextScene;

    public Queue<Dialogue.Info> dialogueInfo = new Queue<Dialogue.Info>();
    public GameObject dialogueOptionUI;
    public GameObject[] optionButtons;
    private bool isDialogueOption;
    private bool inDialogue;
    private int optionsAmount;
    public Text questionText;

    public void EnqueueDialogue(Dialogue db)
    {
        if (inDialogue) return;
        inDialogue = true;

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;

            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].SetActive(false);  //makes all options buttons inactive at start
            }
            for (int i = 0; i < optionsAmount; i++)
            {
                optionButtons[i].SetActive(true);
                optionButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = dialogueOptions.optionsInfo[i].buttonName;
                UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                if(dialogueOptions.optionsInfo[i] != null) //checks if there is another dialogue option
                {
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;    //queues next dialogue
                }
                else
                {
                    myEventHandler.myDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }

        foreach(Dialogue.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()   //shows dialogue
    {
        if (isCurrentlyTyping == true)  //autocompletes text
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        
        Dialogue.Info info = dialogueInfo.Dequeue();
        completeText = info.myText;

        dialogueName.text = info.name;


        pullTextUrl(info);
 
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));


    }

    IEnumerator pullTextUrl(Dialogue.Info info){
        //Disable annoying obsolete warning
        #pragma warning disable 0618
        
        WWW www = new WWW(info.url);
        yield return www;
        string text = www.text;
        info.myText = text;

        //Restore warnings
        #pragma warning restore 0618
    }
    IEnumerator TypeText(Dialogue.Info info)
    {
        isCurrentlyTyping = true;
        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndOfDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        OptionsLogic();
        //SceneManager.LoadScene(nextScene);
    }

    private void OptionsLogic()
    {
        if (isDialogueOption == true)
        {
            dialogueOptionUI.SetActive(true);
            dialogueOptionUI.SetActive(true);
            
        }
    }

    public void CloseOptions()
    {
        dialogueOptionUI.SetActive(false);
    }
}
 