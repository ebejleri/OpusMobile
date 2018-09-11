using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;


	// Update is called once per frame
	void Update () {
		PlayerMove ();
        PlayerRaycast();
	}
	void PlayerMove () {
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true){
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
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;

    }

    void PlayerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "CMG_StarBox") {
            Destroy (rayUp.collider.gameObject);
        }
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
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "Enemy") {
            isGrounded = true;
        }
    }
}
