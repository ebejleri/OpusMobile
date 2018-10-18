using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Update : MonoBehaviour {


    // InstaDeath objects should be tagged "Death" and set as a trigger
    // Enemies (and other 1-damage obstacles) should be tagged "Enemy" and should NOT be set as a trigger

    private GameObject respawn;
 
    private int playerScore;
    [Tooltip("The amount of hits a player can take before respawning.")]
    public static int MaxHealth = 3;
    private int health;

    [Tooltip("The score value of a coin or pickup.")]
    public int coinValue = 5;
    [Tooltip("The amount of points a player loses on death.")]
    public int deathPenalty = 20;

    public Text scoreText;
    public Text healthText;

   





    // Use this for initialization
    void Start()
    {
        health = MaxHealth;
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        playerScore = 0;
        scoreText.text = "Shards: " +playerScore.ToString();

    }

    private void Update()
    {
        if(gameObject.transform.position.y < -50)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Respawn();
        }
        else if (collision.CompareTag("Coin"))
        {
            AddPoints(coinValue);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (--health == 0)
        {
            Respawn();
        }
    }


    public void Respawn()
    {
        health = MaxHealth;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        AddPoints(-1*deathPenalty);
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddPoints(int amount)
    {
        playerScore += amount;
        scoreText.text = "Shards: " + playerScore.ToString();
    }
}
