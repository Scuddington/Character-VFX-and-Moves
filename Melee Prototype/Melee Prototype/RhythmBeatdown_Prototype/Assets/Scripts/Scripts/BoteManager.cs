using UnityEngine;
using System.Collections;
//using SonicBloom.Koreo;

public class BoteManager : MonoBehaviour {
	
	//public delegate void KoreographyEventCallBack(KoreographyEvent koreoEvent);

	public static bool onBote = false;

	public GameObject displayCube;
	public float waitTime = 0.02f;
	public static bool onBeat= false;
	public MeshRenderer pulseMesh;
	public GameObject rBote;
	public GameObject rBoteTarget;
	public GameObject rBoteStart;
	public GameObject lBote;
	public GameObject lBoteTarget;
	public GameObject lBoteStart;
	public float speed;
	public float time = 4f;

	private float displayLength = 0.1f;//0.1
	private Vector3 initialDisplay;
	private Vector3 fullDisplay;
	private float timeLimit = 5f;

	void start()
	{
		

		pulseMesh = displayCube.GetComponent<MeshRenderer> ();
		pulseMesh.enabled = false;
	}

	void OnEnable()
	{
		//Koreographer.Instance.RegisterForEvents("RH Piano",BoteEvent);
		AudioProcessor.OnPreBote += PreBoteEvent;
		//AudioProcessor.OnBote += BoteEvent;
	}

	void OnDisable()
	{
		AudioProcessor.OnPreBote -= PreBoteEvent;
		//AudioProcessor.OnBote -= BoteEvent;
	}

//	void BoteEvent(KoreographyEvent evt)
//	{
//		StartCoroutine ("RightFret");
//		StartCoroutine ("LeftFret");
//		StartCoroutine ("BeatEffect");
//
//		print ("event");
//	}
	void PreBoteEvent()
	{
		StartCoroutine ("RightFret");
		StartCoroutine ("LeftFret");
		StartCoroutine ("BeatEffect");
	}
	IEnumerator BeatEffect(){
		onBeat = true;
		onBote = true;
		pulseMesh.enabled = true;
		yield return new WaitForSeconds (displayLength);
		onBeat = false;
		onBote = false;
		pulseMesh.enabled = false;
	}
	IEnumerator RightFret(){
		float timer = 0.0f;
		GameObject rBoteObject;
		rBoteObject = Instantiate (rBote, rBoteStart.transform.position, rBoteStart.transform.rotation) as GameObject;
		for (float t = 0; t <= 1; t += (Time.deltaTime / time)) {
			rBoteObject.transform.position = Vector3.Lerp (rBoteStart.transform.position, rBoteTarget.transform.position, t);
			yield return new WaitForSeconds (0);
		}
		Destroy (rBoteObject);
	}
	IEnumerator LeftFret(){
		float timer = 0.0f;
		GameObject lBoteObject;
		lBoteObject = Instantiate (lBote, lBoteStart.transform.position, lBoteStart.transform.rotation) as GameObject;
		for (float t = 0; t <= 1; t += (Time.deltaTime / time)) {
			lBoteObject.transform.position = Vector3.Lerp (lBoteStart.transform.position, lBoteTarget.transform.position, t);
			yield return new WaitForSeconds (0);
		}
		Destroy (lBoteObject);
	}
}

