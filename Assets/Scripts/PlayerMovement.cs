using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private Animator anim;
    private BoxCollider2D coll;

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float runningSpeed = 5f;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private int numJumps = 2;

    private enum AnimationState 
    {
        Idle,
        Running,
        Jumping,
        Falling
    } 

    private AnimationState state =  AnimationState.Idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    
    private void Update()
    {
        float dirX = UpdateKeyboardInput();
        UpdateAnimationState(dirX);
    }
    // Update is called once per frame
    private float UpdateKeyboardInput()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * runningSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        return dirX;
    }

    void UpdateAnimationState(float dirX)
    {
        if(dirX > 0f)
        {
            state = AnimationState.Running;
            spr.flipX = false;
        }
        // moving left
        else if (dirX < 0f)
        {
            state = AnimationState.Running;
            spr.flipX = true;
        }
        else
        {
            state = AnimationState.Idle;
        }
      
        if(rb.velocity.y > 0.1f)
        {
            Debug.Log("Jumping Animation");
            state = AnimationState.Jumping;
        }
        else if(rb.velocity.y < -0.1f)
        { 
            state = AnimationState.Falling;
        }
       
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.size,0, Vector2.down, 0.1f, jumpableGround);
    }
}
