using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SetTextFromURL : MonoBehaviour{

    public string url;
    public Text text;

    IEnumerator Start()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)){
            yield return webRequest.SendWebRequest();

            if(webRequest.isNetworkError){
                Debug.Log("Uh oh: " + webRequest.error);
            }else{
                //Debug.Log("--good--");
                text.text = webRequest.downloadHandler.text;
            }
        }

        /* WWW | deprecated
        //Disable the annoying obsolete message
        #pragma warning disable 0618        
        WWW www = new WWW(url);
        yield return www;
        text.text = www.text;
        //Restore warnings
        #pragma warning restore 0618
        */
    }
}
