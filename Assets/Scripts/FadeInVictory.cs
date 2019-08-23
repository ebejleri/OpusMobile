using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeInVictory : MonoBehaviour {
    public Animator anim;
    public int index;
    private bool pressed = false;
	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey&&!pressed)
        {
            pressed = true;
            StartCoroutine(fadeIn());
        }
    }
    IEnumerator fadeIn()
    {
        //anim.SetBool("SwtichScreen", false);
        //yield return new WaitForSeconds(5);
        anim.SetBool("SwitchScreen", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);

    }
}
