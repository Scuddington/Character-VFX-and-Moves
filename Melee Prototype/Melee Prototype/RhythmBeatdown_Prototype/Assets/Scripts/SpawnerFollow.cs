using UnityEngine;
using System.Collections;

public class SpawnerFollow : MonoBehaviour {

	public GameObject p1Target;
	public GameObject p2Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.tag == "p1Spawner_Follow") {
			this.transform.position = new Vector3 (p1Target.transform.position.x, p1Target.transform.position.y, 1);
		} else if (this.gameObject.tag == "p2Spawner_Follow") {
			this.transform.position = new Vector3(p2Target.transform.position.x, p2Target.transform.position.y, 1);
		}
	}
}
