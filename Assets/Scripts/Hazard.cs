﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{

        void OnTriggerEnter(Collision col)
        {
        if (col.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("Pomogranite Garden");
        }
    }
}
