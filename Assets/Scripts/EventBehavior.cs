using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventBehavior : ScriptableObject
{
    public void TestEvent()
    {
        Debug.Log("Test event successful");
        //put logic here
    }
    public void TestEvent02()
    {
        Debug.Log("Test event02 successful");
        //put logic here
    }
    public void TestEvent03()
    {
        Debug.Log("Test event03 successful");
        //put logic here
    }
}
