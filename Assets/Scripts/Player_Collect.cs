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
    public AudioClip coinCollectSound;
    public AudioClip doorCollectSound;
    public AudioClip cerberusCollectSound;
    public Text cerberusKey;
    public Text shardsCollected;
    public GameObject CerberusFace;
    public GameObject CerberusBlock;
    public Text timeLeftUI;
    public Image CerberusKeyImage;
    public bool openDoor = false;
    public float timeLeft = 500;
    public GameObject doorToOpen;
    public int doorCount = 0;


    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.text = ("Time Left: " + (int)timeLeft);
        if (openDoor && doorCount<90)
        {
            doorToOpen.gameObject.transform.Rotate(0, 0, 5);
            doorCount += 5;
            //doorToOpen.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * 10);
        }
    }
    void Start()
    {
        cerberusKey.text = "";
        CerberusKeyImage.enabled = false;
    }


    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && !finished && keyCollected)
        {
            cerberusCalled = true;
            cerberusKey.text = "";
            CerberusKeyImage.enabled = false;
            CerberusBlock.SetActive(false);
            CerberusFace.SetActive(false);
            finished = true;
            Debug.Log(collision.name);
            AudioSource.PlayClipAtPoint(doorCollectSound, transform.position);
            float speed = 10F;
            openDoor = true;
            //collision.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * speed);
            //StartCoroutine(doorOpen(collision));
            collision.isTrigger = false;
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            keyCollected = true;
            AudioSource.PlayClipAtPoint(cerberusCollectSound, transform.position);
            cerberusKey.text = "";
            CerberusKeyImage.enabled = true;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
            coinAmount++;
            shardsCollected.text = ": " + coinAmount;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(sceneName: "EndScreen");
        }
       
    }
    IEnumerator doorOpen(Collider2D coll)
    {
        coll.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * 10);
        coll.gameObject.transform.Rotate(0, 0, 1);

        yield return new WaitForSeconds(0.01F);
        //float speed = 10F;
        //coll.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), speed * Time.deltaTime);
    }

}
