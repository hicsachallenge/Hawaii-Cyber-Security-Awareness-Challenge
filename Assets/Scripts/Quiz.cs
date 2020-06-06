using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Networking;
using System;

public class Quiz : MonoBehaviour{
    public string ContentFromUrl;
    public string URLQuestions;
    public string URLAnswerKey;
    public static string[] QuestionsAndAnswers = new string[100];
    public static string[] answerKey = new string[20];
    public static string[] userAnswers;
    public static bool[] correctIncorrect;
    public GameObject scorePanel;
    public Text scoreText;
    public Text correctAnswersText;
    public Text questionsText;

    public GameObject loadingPanel;

    private int correctAnswers = 0;
    private const int maxQuestions = 20;
    private double score;

    public Text afterQuizMemo;
    public GameObject GoToCertificate;
    public GameObject cert_Memo;
    public GameObject InField;
    public InputField InputField_PlayerName;

    private string PlayerName;
    public Text Text_PlayerName;
    public GameObject Certificate;
    public Text Text_SecretCode;

    public ToggleGroup[] toggleGroups = new ToggleGroup[20];

    void Start(){

        GoToCertificate.SetActive(false);
        cert_Memo.SetActive(false);
        InField.SetActive(false);
        Certificate.SetActive(false);

        //Pull  quiz from online and store in one giant string
        StartCoroutine(getFromURL(URLQuestions));

        /* DEBUG
        Debug.Log(ContentFromUrl);
        */

        

        /* DEBUG
        for(int i = 0; i < QuestionsAndAnswers.Length; ++i){
            Debug.Log(i + ":   " + QuestionsAndAnswers[i]);
        }
        */

        //Get answer key and store in one string
        StartCoroutine(getFromURL(URLAnswerKey));        

        userAnswers = new string[20];
        correctIncorrect = new bool[20];


    }




    IEnumerator getFromURL(string url){
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)){
            yield return webRequest.SendWebRequest();
            

            if(webRequest.isNetworkError){
                Debug.Log("Badness happened: " + webRequest.error);
            }else{
                //Debug.Log("Snagged it!");
                ContentFromUrl = webRequest.downloadHandler.text;

                if(url == URLQuestions){
                    QuestionsAndAnswers = ContentFromUrl.Split('\n');
                    loadingPanel.SetActive(false);
                }
                else{
                    answerKey = ContentFromUrl.Split('\n');
                }
            }
            
        }
    }

    /* WWW | deprecated
    string getFromUrl(string url){
        
        #pragma warning disable 0618 //Remove annoying warning
        WWW www = new WWW(url);
        #pragma warning restore 0618 //Restore future warnings
        

        float startTimer = Time.time;
        //This while loop could be dangerous so I added a timeout function
        // that should return to the computer scene if 5 seconds pass. UNTESTED.
        while(!www.isDone){
            float currentTime = Time.time;
            if(currentTime == startTimer+5){
                Debug.Log("WE TIMED OUT");
                SceneManager.LoadScene("Computer");
                //Ideally we should tell the user and also make sure they don't lose progress / still have access to quiz              
            }
        }
        return www.text;
    }*/


    public void Submit_Quiz(){
        correctAnswers = 0;
        //Pull all the answers from the Quiz and store them as A-D in an array called userAnswers
        for(int i = 0; i < toggleGroups.Length; ++i){
            userAnswers[i] = getAnswerFromGroup(toggleGroups[i]);
        }


        /* DEBUG
        for(int i = 0; i < userAnswers.Length; ++i){
            Debug.Log(userAnswers[i]);
        }
        */


        for(int i = 0; i < userAnswers.Length; ++i){
            if(userAnswers[i] == answerKey[i]){
                correctIncorrect[i] = true;
                correctAnswers++;
            }
        }
        /* DEBUG
        for(int i = 0; i < correctIncorrect.Length; ++i){
             if (correctIncorrect[i]){
                 Debug.Log(i + ": CORRECT");
             }else{
                 Debug.Log(i + ": WRONG");
             }
        }
        */

        score = ((double)correctAnswers / (double)maxQuestions) * 100;

        /* DEBUG
        Debug.Log("Correct Answers: " + correctAnswers);
        Debug.Log("Max Questions: " + maxQuestions);
        Debug.Log("Score: " + score + "%");
        */

        //Enable score overview
        scorePanel.SetActive(!scorePanel.activeSelf);
        
        scoreText.text = "Score: " + score + "%";
        correctAnswersText.text = "Correct Answers: " + correctAnswers;
        questionsText.text = "Questions: " + maxQuestions;

        if(score >= 95){
            
            afterQuizMemo.text = "Excellent job!\n Please Enter your name...";
            GoToCertificate.SetActive(true);
            cert_Memo.SetActive(true);
            InField.SetActive(true);
            PlayerName = InputField_PlayerName.text;
            
        }else{
            afterQuizMemo.text = "Nice try but you'll need to do better to get that certificate.\n"
                                    + "Press the X and try again.";
            GoToCertificate.SetActive(false);
            cert_Memo.SetActive(false);
            InField.SetActive(false);
            
        }        
    }

    string getAnswerFromGroup(ToggleGroup TG){
        Toggle answer = TG.ActiveToggles().FirstOrDefault();
        string letterAnswer = "E";

        if(!TG.AnyTogglesOn()){
            return letterAnswer;
        }

        switch(answer.name){
            case "Toggle_A":
                letterAnswer = "A";
                break;
            case "Toggle_B":
                letterAnswer = "B";
                break;
            case "Toggle_C":
                letterAnswer = "C";
                break;
            case "Toggle_D":
                letterAnswer = "D";
                break;
            default:
                break;
        }

        return letterAnswer;
    }

    public void showCertificate(){
        PlayerName = InputField_PlayerName.text;
        Certificate.SetActive(true);
        Text_PlayerName.text = PlayerName;
        Text_SecretCode.text = "Secret Code: " + getSecretCode();

        getSecretCode();
    }

    int getSecretCode(){
        string secretCode = "C4b3rRu135!" + this.PlayerName;
        return Math.Abs(secretCode.GetHashCode());        
    }
}
