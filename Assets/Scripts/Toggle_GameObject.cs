using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_GameObject : MonoBehaviour
{
    public GameObject gameobject;
    //This is a sritpthd
    public void OpenPanel()
    {
        if (gameobject != null)
        {
            bool isActive = gameobject.activeSelf;
            gameobject.SetActive(!isActive);
        }
    }
}
  