using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            coll.gameObject.transform.SetParent(transform);
            Debug.Log("Player on platform");
        }
    }

    
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            coll.gameObject.transform.SetParent(null);
        }
    }
    
}
