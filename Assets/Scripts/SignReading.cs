using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignReading : MonoBehaviour {
    float moveX;
    public Image signMessage;
    public Text signText;
	// Use this for initialization
	void Start () {
        signMessage.enabled = false;
        signText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        moveX = Input.GetAxis("Vertical");
        if (moveX > 0.0f)
        {
            signText.enabled = true;
            signMessage.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        signMessage.enabled = false;
        signText.enabled = false;

    }
}
