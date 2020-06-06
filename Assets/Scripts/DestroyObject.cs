using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    GameObject destroyedObject;

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            Destroy(gameObject);
        }
    }
}
