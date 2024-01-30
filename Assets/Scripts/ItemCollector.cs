using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

   private int numCherries = 0;
   [SerializeField] private AudioSource itemCollectSoundEffect;
   [SerializeField] private TextMeshProUGUI cherriesText;

   private void OnTriggerEnter2D(Collider2D coll)
   {
        if(coll.gameObject.CompareTag("Cherry"))
        {
            //Debug.Log("Player Collected Cherry!");
            Destroy(coll.gameObject);
            //numCherries++;
            StateNameController.numCherries++;
            cherriesText.text = "Cherries: " + StateNameController.numCherries;
            itemCollectSoundEffect.Play();
        }
   }
}
