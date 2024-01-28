using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LifeUpdate : MonoBehaviour
{

   private Animator anim;
   private Rigidbody2D rb;

   [SerializeField] private AudioSource deathSoundEffect;

   private void Start()
   {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
   }

   private void OnCollisionEnter2D(Collision2D coll)
   {
        if(coll.gameObject.CompareTag("Spikes"))
        {
            //Debug.Log("Player hit spikes");
            Die();
            
            // need to restart level
        }
        else if(coll.gameObject.CompareTag("Saw"))
        {
          Debug.Log("Player Hit Saw");
          
          Die();
        }
   }

   private void Die()
   {
     rb.bodyType = RigidbodyType2D.Static;
     anim.SetTrigger("hurt");
     deathSoundEffect.Play();
   }

   private void RestartLevel()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
