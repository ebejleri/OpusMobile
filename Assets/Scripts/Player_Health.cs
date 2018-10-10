/* Player Health Script
This script should be put on the player in a 2D game.
--------------------------------------------
7/19/18: 	Wilson Gansler - Fixed so it loads specific level after falling, enemy, hazard deaths
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{


    void Update()
    {
        if (gameObject.transform.position.y < 40)
        {
            SceneManager.LoadScene(sceneName: "Pomogranite Garden");
        }
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            SceneManager.LoadScene(sceneName: "Pomogranite Garden");
        }

        
        if (collision.tag == "Hazard")
        {
             SceneManager.LoadScene(sceneName: "Pomogranite Garden");
        }
        

    }
}
     

