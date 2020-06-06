using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;  //swaps between emails

    public void Subscribe (TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab) //change sprite if tab isn't already selected
        button.background.sprite = tabHover;
    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }
    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;   //selected tab before resetting
        selectedTab.Select();
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++){
            if (i== index)
                {
                    objectsToSwap[i].SetActive(true);
                }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }
    public void ResetTabs() //sets all tabs to idle
    {
        foreach(TabButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab)    //skip over currently selected tab
            {
                continue;
            }
            button.background.sprite = tabIdle;
        }
    }
}
