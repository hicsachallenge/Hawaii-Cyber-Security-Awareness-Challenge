using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailManager : MonoBehaviour
{
    public GameObject inboxTab;
    public GameObject trashTab;

    public void MoveFromInbox(GameObject inbox)
    {
        inbox.SetActive(false);
    }
    public void MoveToTrash(GameObject trash)
    {
        trash.SetActive(true);
    }

    public void DeleteObject(GameObject item)
    {
        item.SetActive(false);
    }
}
