using UnityEngine;
using System.Collections;

public class CollectablesScript : MonoBehaviour {
	
	void OnEnable () {
		Invoke ("DestroyCollectable", 6.0f);
	}
	
	void DestroyCollectable() {
		gameObject.SetActive (false);
	}
}
