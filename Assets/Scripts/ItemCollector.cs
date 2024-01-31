using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

   // private int numCherries = 0;
   [SerializeField] private AudioSource itemCollectSoundEffect;
   [SerializeField] private TextMeshProUGUI cherriesText;
   //[SerializeField] private Animator cherryAnimator;

   private void OnTriggerEnter2D(Collider2D coll)
   {
        if(coll.gameObject.CompareTag("Cherry"))
        {
            //Debug.Log("Player Collected Cherry!");
            Debug.Log("Collected Cherry");
            
            //numCherries++;
            StateNameController.numCherries++;
            cherriesText.text = "Cherries: " + StateNameController.numCherries;
            itemCollectSoundEffect.Play();
            coll.gameObject.GetComponent<Animator>().SetTrigger("collected");
            //coll.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Get collected trigger value: " + coll.gameObject.GetComponent<Animator>().GetBool("collected"));
            //Destroy(coll.gameObject);
        }
   }
}
