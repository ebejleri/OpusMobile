using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{

        void OnTriggerEnter2D(Collider2D col)
        {
        if (col.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("Pomogranite Garden");
        }
    }
}
