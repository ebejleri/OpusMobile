using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Update : MonoBehaviour {

    public int playerSpeed = 5;
    public int playerJumpPower = 1300;
    private float moveX;
    public int jumpCount = 0;
    public bool hasBone = false;

    [Tooltip("Only change this if your character is having problems jumping when they shouldn't or not jumping at all.")]
    public float distToGround = 1.0f;
    private bool inControl = true;

    [Tooltip("Everything you jump on should be put in a ground layer. Without this, your player probably* is able to jump infinitely")]
    public LayerMask GroundLayer;





    // Update is called once per frame
    void Update() { 
    
        if (inControl)
        {
            PlayerMove();
        }
        
    }

    void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            jumpCount++;
        }
        else
        {
            if(Input.GetButtonDown("Jump")&&!IsGrounded() && jumpCount==1)
            {
                Jump();
            }
            else
            {
                if (Input.GetButton("Jump") && !IsGrounded() && jumpCount == 2 && hasBone == true)
                {
                    hasBone = false;
                    Jump();
                }
            }
        }

        //ANIMATIONS
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }

        //PLAYER DIRECTION
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);

    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround, GroundLayer);
        if (hit.collider != null)
        {
            //jumpCount = 0;
            return true;
        }
        return false;

    }

    public void SetControl(bool b)
    {
        inControl = b;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bone"))
        {
            hasBone = true;
            Destroy(collision.gameObject);
        }
    }
}
