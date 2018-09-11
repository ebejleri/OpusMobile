using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public GameObject sp1, sp2;
    
    void Start() {
        sp1 = this.gameObject;
    }

    void OnTriggerStay2D (Collider2D trig) {
        if (Input.GetButtonDown ("Jump")) {
            trig.gameObject.transform.position = sp2.gameObject.transform.position;
            
        }
        
    }

   
}
