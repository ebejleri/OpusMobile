using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharonDialouge : MonoBehaviour {
    public Image charonScroll;
    public Text charonText;
    public GameObject Opus;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Opus.transform.position.x> -5)
        {
            charonScroll.enabled = false;
            charonText.enabled = false;
        }
	}
}
