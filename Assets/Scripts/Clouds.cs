using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    public float speed;
    private float xDir;

	// Use this for initialization
	void Start () {
        xDir = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        xDir -= Time.deltaTime * speed;
        transform.position = new Vector3(xDir, transform.position.y, transform.position.z);
        if (transform.position.x > 15) {
            transform.position = new Vector3(-35, transform.position.y, transform.position.z);
        }
     }
}
