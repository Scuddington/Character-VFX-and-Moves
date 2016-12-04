using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lists : MonoBehaviour {
	public GameObject projectile;
	public static List <GameObject> p1aprojectilelist;
	public static List <GameObject> p1bprojectilelist;
	public static List <GameObject> p1cprojectilelist;
	public static List <GameObject> p2aprojectilelist;
	public static List <GameObject> p2bprojectilelist;
	public static List <GameObject> p2cprojectilelist;

	// Use this for initialization
	void Start () {
		p1aprojectilelist = new List<GameObject>();
		p1bprojectilelist = new List<GameObject>();
		p1cprojectilelist = new List<GameObject>();
		p2aprojectilelist = new List<GameObject>();
		p2bprojectilelist = new List<GameObject>();
		p2cprojectilelist = new List<GameObject>();
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKeyDown(KeyCode.R)) {

			// Instantiate the projectile at the position and rotation of this transform
			GameObject clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			p1aprojectilelist.Add(clone);
			clone.name = "p1aBullet";
			//print(clone.name);
	}
		if (Input.GetKeyDown(KeyCode.F)) {

			// Instantiate the projectile at the position and rotation of this transform
			GameObject clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			p1bprojectilelist.Add(clone);
			clone.name = "p1bBullet";
			//print(clone.name);
		}
		if (Input.GetKeyDown(KeyCode.V)) {

			// Instantiate the projectile at the position and rotation of this transform
			GameObject clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			p1cprojectilelist.Add(clone);
			clone.name = "p1cBullet";
			//print(clone.name);
		}*/

}
}
