using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    public InputField inputText;
    string playerName;

    public void ChangeScene(string sceneName)
    {
        //Disable annoying obsolete message
        #pragma warning disable 0618
        
        Application.LoadLevel(sceneName);
    }
}
