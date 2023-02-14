using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 15f;

    private float movementX;
    private Rigidbody2D mybody;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private SpriteRenderer sr;
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    //private FixedJoint2D fixj;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //fixj.connectedBody = GameObject.FindWithTag("Ground").GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        } else if (movementX < 0)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            isGrounded = false;
            anim.SetBool(JUMP_ANIMATION, true);
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
           
        } else
        {
            anim.SetBool(JUMP_ANIMATION, false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            Debug.Log("Landed on ground");
        }
    }
}
