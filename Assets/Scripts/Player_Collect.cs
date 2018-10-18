using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Collect : MonoBehaviour {
    public bool finished = false;
    public bool keyCollected = false;
    public bool cerberusCalled = false;
    public int coinAmount = 0;
    public AudioClip collectSound;
    public Text cerberusKey;
    public Text shardsCollected;
    public Text timeLeftUI;
    public float timeLeft = 500;


    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.text = ("Time Left: " + (int)timeLeft);
    }
    void Start()
    {
        cerberusKey.text = "";
    }


    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && !finished && keyCollected)
        {
            cerberusCalled = true;
            cerberusKey.text = "";
            finished = true;
            Debug.Log(collision.name);
            collision.transform.Rotate(0, 0, 90);
            collision.isTrigger = false;
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            keyCollected = true;
            cerberusKey.text = "Cerberus Key Collected";
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            coinAmount++;
            shardsCollected.text = "Shards: " + coinAmount;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(sceneName: "Pomogranite Garden");
        }
    }
}
