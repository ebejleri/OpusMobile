using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour {
    public Animator anim;
    public Image transition;
    public bool isTransition = true;
    public void LoadByIndex(int sceneIndex)
    {
        StartCoroutine(Example(sceneIndex));
    }
    IEnumerator Example(int sceneIndex)
    {
        if (isTransition)
        {
            anim.SetBool("SwitchScreens", true);
            yield return new WaitForSeconds(2);
        }
        SceneManager.LoadScene(sceneIndex);

    }
}
