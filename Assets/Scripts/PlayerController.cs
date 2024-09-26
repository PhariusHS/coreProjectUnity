using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D circleCollider2D;
    private bool isFacingRight = true;
    [SerializeField] private LayerMask groundLayer;
    [Range(0, 60f)] [SerializeField] private float speed = 25;
    [Range(0, 5f)][SerializeField] private float fallLongMult = 0.85f;
    [Range(0, 5f)][SerializeField] private float fallShortMult = 1.55f;
    float moveX = 0f;
    bool jump = false, jumpHeld = false;

    

    //Is the character touching ground?
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(circleCollider2D.bounds.center, circleCollider2D.radius, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        rigidBody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        moveX = Input.GetAxisRaw("Horizontal") * speed;

        //Getting right animation while moving
        
        Console.WriteLine(moveX);

        if (!moveX.Equals(0))
        {
            if (moveX is > 0 or < 0)
                GetComponent<Animator>().Play("PlayerWalk");
        }
        else GetComponent<Animator>().Play("PlayerIdle");



    }


    
    private void FixedUpdate()
    {
        float moveFactor = moveX * Time.fixedDeltaTime;

        //Movement "Physic"
        rigidBody2D.velocity = new Vector2(moveFactor * 10f, rigidBody2D.velocity.y);

        //Flipping the sprite -> Calling flipSprite()
        if (moveFactor > 0f && !isFacingRight) flipSprite();
        else if (moveFactor < 0 && isFacingRight) flipSprite();
    }



    private void flipSprite()
    {
        isFacingRight = !isFacingRight;

        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale= transformScale;
    }





}
