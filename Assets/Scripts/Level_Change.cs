using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Make sure to add this, or you can't use SceneManager
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level_Change : MonoBehaviour
{
    public int index;
    public string levelName;
    public Image black;
    public Animator anim;
    public bool loading = false;
    AsyncOperation asyncLoad;

    private void Start()
    {
        asyncLoad = SceneManager.LoadSceneAsync(2);
        asyncLoad.allowSceneActivation = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //other.name should equal the root of your Player object
        if (other.gameObject.CompareTag("Player"))
        {
            if (!loading)
            {
                //asyncLoad.allowSceneActivation = true;


                loading = true;
                StartCoroutine(switchScreen());

            }
            //The scene number to load (in File->Build Settings)
            //SceneManager.LoadScene("EndScreen");
            // asyncLoad.allowSceneActivation = true;
            //StartCoroutine(switchScreen());
        }

    }
    IEnumerator switchScreen()
    {
        print("Ghost Hit");
        anim.SetBool("SwitchScreen", true);
        yield return new WaitForSeconds(2);
        print("Waiting too long");
        asyncLoad.allowSceneActivation = true;
    }
}