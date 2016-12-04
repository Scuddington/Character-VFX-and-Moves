using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {

//	public Canvas title;
//	public Button start;
//	public Button options;
//	public Button quit;
//
//	void Start (){
//		title = title.GetComponents<Canvas> ();
//		start = start.GetComponents<Button> ();
//		options = options.GetComponents<Button> ();
//		quit = quit.GetComponents<Button> ();
//	}


	public void PlayedBefore()
	{
		
		SceneManager.LoadScene (4);
		//StartCoroutine ("WaitForIt");

	}
	public void LoadGame(){
		SceneManager.LoadScene (3);
	}
	public void Options(){
		SceneManager.LoadScene (10);
	}
	public void Quit(){
		SceneManager.LoadScene (11);
	}
	public void Tutorial(){
		SceneManager.LoadScene (5);
	}
	public void MoveList(){
		SceneManager.LoadScene (14);
	}
	public void Credits(){
		SceneManager.LoadScene (13);
	}
	public void FullCinematic(){
		SceneManager.LoadScene (12);
	}
	public void Pause(){
		SceneManager.LoadScene (9);
	}
	public void Elephant(){
		SceneManager.LoadScene (8);
	}
	public void Coyote(){
		SceneManager.LoadScene (7);
	}

	public void Close(){
		Application.Quit ();
	}
	public void MainMenu(){
		SceneManager.LoadScene (2);
	}
	public void FunkyChicken(){
		SceneManager.LoadScene (2);
	}

//	IEnumerator WaitForIt()
//	{
//		yield return new WaitForSeconds(3);
//		SceneManager.LoadScene (4);	
//	}

}


	
