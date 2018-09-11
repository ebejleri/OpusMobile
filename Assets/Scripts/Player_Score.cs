using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    public float timeLeft = 500;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public AudioClip Chirp;

    void Start () {
        //Just for testing
        Data_Management.dataManagement.LoadData();
    }

	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene ("Marshmallow_Level_2");
        } 
    }

    void OnTriggerEnter2D (Collider2D trig) {
        if (trig.gameObject.name == "End_Level") {
            CountScore();
        }
        if (trig.gameObject.name == "CMG_Star")
        {
            playerScore += 10;
            AudioSource.PlayClipAtPoint(Chirp, transform.position);
            Destroy(trig.gameObject);
        }
        if (trig.gameObject.name == "CMG_StarBox") {
            playerScore += 10;
            AudioSource.PlayClipAtPoint(Chirp, transform.position);
            Destroy(trig.gameObject);
     
        }
        if (trig.gameObject.name == "CMG_Marshmallow_01") {
            playerScore += 20;
            AudioSource.PlayClipAtPoint(Chirp, transform.position);
            Destroy(trig.gameObject);

        }
    }

    void CountScore () {
        Debug.Log("Data says high score is currently" + Data_Management.dataManagement.highScore);
        playerScore = playerScore + (int)(timeLeft * 10);
        Data_Management.dataManagement.highScore = playerScore + (int)(timeLeft * 10);
        Data_Management.dataManagement.SaveData();
        Debug.Log(message: "Now that we have added the score to Data_Management, data says high score is currently" + Data_Management.dataManagement.highScore);
    }
}
