using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Move : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    public int jumpCount = 0;
    public bool canDoubleJump;
    public LayerMask groundLayer;
    public bool hasBone;
    public Text bonePower;
    public AudioClip boneCollect;
    public GameObject bonePowerUp;
    public Image bonePowerImage;


    // Update is called once per frame
    void Update () {
        PlayerRaycast();
		PlayerMove ();
	}
    private void Start()
    {
        Cursor.visible = false;
        bonePowerImage.enabled = false;
    }
    void PlayerMove () {
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")){
            Jump();
        }

		//ANIMATIONS
        if (moveX != 0) {
            GetComponent<Animator>().SetBool("IsRunning", true);
        } else {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }

		//PLAYER DIRECTION
		if (moveX < 0.0f ) {
            GetComponent<SpriteRenderer>().flipX = true;
		} else if (moveX > 0.0f ) {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //PHYSICS

		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
    

    void Jump () {
        //JUMPING CODE
            if (isGrounded && jumpCount==0)
            {
            Debug.Log("First Jump");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerJumpPower));
            canDoubleJump = true;
            isGrounded = false;
            jumpCount++;
            }
            else
            {
            
                if (canDoubleJump && jumpCount==1)
                {
                Debug.Log("Second Jump");
                canDoubleJump = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerJumpPower));
                jumpCount--;
                isGrounded = false;
                }
                else
                {
                
                    Debug.Log("Bone check");
                    if (hasBone)
                    {
                        hasBone = false;
                    bonePower.text = "";
                    bonePowerImage.enabled = false;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerJumpPower));
                    bonePowerUp.SetActive(true);
                    
                    }
                isGrounded = false;
                jumpCount = 0;
            }
        }
          //  GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        //isGrounded = false;


    }


    void PlayerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy") {
            GetComponent<Rigidbody2D>().AddForce(force: Vector2.up * 500);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce(Vector2.down * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy_Move>().enabled = false;
            //Destroy(hit.collider.gameObject);
        }
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.6f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        //if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer) {
      //  Debug.Log("Raydown distance"+rayDown.distance);
        //    isGrounded = true;
        //}
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bone"))
        {
            hasBone = true;
            AudioSource.PlayClipAtPoint(boneCollect, transform.position);
            bonePower.text = "";
            bonePowerUp = collision.gameObject;
            bonePowerImage.enabled=true;
            collision.gameObject.SetActive(false);
        }
    }

}
