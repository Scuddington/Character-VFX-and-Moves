using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	public void LoadBattle(int index)
	{
	
		SceneManager.LoadScene (index);

	}
}
