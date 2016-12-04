using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DestroyBullets : MonoBehaviour {

	//public float bulletlife = 3.0f;



    void OnCollisionEnter (Collision col)
    {
		if (col.gameObject.tag == "projectile") {
			if (col.gameObject.name == "High2") {
				Lists.p2aprojectilelist.Remove (col.gameObject);
				Destroy (this.gameObject);
			} else if (col.gameObject.name == "High") {
				Lists.p1aprojectilelist.Remove (col.gameObject);
				Destroy (this.gameObject);
			} else if (col.gameObject.name == "Mid2") {
				Lists.p2aprojectilelist.Remove (col.gameObject);
				Destroy (this.gameObject);
			} else if (col.gameObject.name == "Mid") {
				Lists.p1aprojectilelist.Remove (col.gameObject);
				Destroy (this.gameObject);
				//Destroy (gameObject, bulletlife);  
			} else if (col.gameObject.name == "Low2") {
				Lists.p2aprojectilelist.Remove (col.gameObject);
				Destroy (this.gameObject);
			} else if (col.gameObject.name == "Low") {
				Lists.p1aprojectilelist.Remove (col.gameObject);
				Destroy (this.gameObject);
			}
		} else if (col.gameObject.tag == "ground") {
			if (this.gameObject.name == "High2") {
				Lists.p2aprojectilelist.Remove (this.gameObject);
				Destroy (this.gameObject);
			} else if (this.gameObject.name == "High") {
				Lists.p1aprojectilelist.Remove (this.gameObject);
				Destroy (this.gameObject);
			} else if (this.gameObject.name == "Mid2") {
				Lists.p2aprojectilelist.Remove (this.gameObject);
				Destroy (this.gameObject);
			} else if (this.gameObject.name == "Mid") {
				Lists.p1aprojectilelist.Remove (this.gameObject);
				Destroy (this.gameObject);
				//Destroy (gameObject, bulletlife);  
			} else if (this.gameObject.name == "Low2") {
				Lists.p2aprojectilelist.Remove (this.gameObject);
				Destroy (this.gameObject);
			} else if (this.gameObject.name == "Low") {
				Lists.p1aprojectilelist.Remove (this.gameObject);
				Destroy (this.gameObject);
			}
		
			
		
		
		}

		}
		//Destroy (gameObject);
    }

