using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private LayerMask groundLayer;
    [Range(0, 40f)] [SerializeField] private float speed = 10;
    [Range(0, 5f)][SerializeField] private float fallLongMult = 0.85f;
    [Range(0, 5f)][SerializeField] private float fallShortMult = 1.55f;
    float moveX = 0f;
    bool jump = false, jumpHeld = false;

    

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
        
    }


    
    private void FixedUpdate()
    {
        float moveFactor = moveX * Time.fixedDeltaTime;
        rigidBody2D.velocity = new Vector2(moveFactor * 10f, rigidBody2D.velocity.y);

    }
}
