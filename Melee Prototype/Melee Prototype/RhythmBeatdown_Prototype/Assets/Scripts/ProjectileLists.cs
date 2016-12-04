using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileLists : MonoBehaviour {

	public static List <Rigidbody> p2List; 
	public static List <Rigidbody> p1List;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {

			foreach (Rigidbody rb in p1List) {
				print (rb.name);
			}
			foreach (Rigidbody rb in p2List) {
				print (rb.name);
			}
		
		}
	}
}
