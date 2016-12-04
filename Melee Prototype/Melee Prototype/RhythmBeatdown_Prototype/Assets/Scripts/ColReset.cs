using UnityEngine;
using System.Collections;

public class ColReset : MonoBehaviour {
	public delegate void ResetCol ();

	public static event ResetCol resetAction;
	//public GameObject collider_One;
	//public GameObject collider_Two;

	void Start()
	{
		
	}


	void ResetRoutine()
	{
		if (resetAction != null)
		{
			resetAction ();
		}


	}

}
