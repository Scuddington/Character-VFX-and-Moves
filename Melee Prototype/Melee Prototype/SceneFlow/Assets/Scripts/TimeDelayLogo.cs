using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeDelayLogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (LoadNext ());

	}
	
	IEnumerator LoadNext(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (1);
	}
}
