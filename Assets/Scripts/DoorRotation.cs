using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorRotation : MonoBehaviour {
    int rotation_direction=1;
    bool finished = false;
	// Use this for initialization
	
    void RotateOpen()
    {
        transform.Rotate(0,0,90*rotation_direction);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //RotateOpen();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Opus"))
        {
            Debug.Log(collision.name);
            RotateOpen();
        }
    }
}
