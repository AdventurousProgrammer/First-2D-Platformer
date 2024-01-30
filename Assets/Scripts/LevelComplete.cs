using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private BoxCollider2D boxcoll;
    private bool levelCompleted = false;

    [SerializeField] private AudioSource levelCompleteSoundEffect;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        boxcoll = GetComponent<BoxCollider2D>();
       
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Player" && !levelCompleted)
        {
            anim.SetTrigger("level_complete");
            levelCompleteSoundEffect.Play();
            levelCompleted = true;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 
}
