using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{

    public TextAsset textFromfile;
    public Text text;

    void Start()
    {
        text.text = textFromfile.text;
    }
}
