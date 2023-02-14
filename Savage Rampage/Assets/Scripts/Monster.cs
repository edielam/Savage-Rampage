using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed; //speed here is a vector quantity...it has direction
    private Rigidbody2D myBody;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        anim.SetBool(WALK_ANIMATION, true);
    }
}
