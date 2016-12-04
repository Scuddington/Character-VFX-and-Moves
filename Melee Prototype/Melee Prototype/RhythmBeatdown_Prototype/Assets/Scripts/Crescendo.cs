using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Crescendo : MonoBehaviour {

	public static int crescendoVal1 = 1;
	public static int crescendoVal2 = 1;
	private int maxCrescendo = 100;
	public Image fill1;
	public Image fill2;
	public Color maxBar = Color.magenta;
	public Color notMaxBar = Color.cyan;

	public Slider crescendoSlider_P1;
	public Slider crescendoSlider_P2;

	// Use this for initialization
	void Start () {

	}
	void OnEnable()
	{
		TakeDamage.gotHit += UpdateCresBar;
	}
	void OnDisable()
	{
		TakeDamage.gotHit -= UpdateCresBar;
	}
	// Update is called once per frame
	void UpdateCresBar () {
		if (crescendoVal1 > maxCrescendo) {
		
			crescendoVal1 = maxCrescendo;
			fill1.color = maxBar;
		}
		if (crescendoVal2 > maxCrescendo) {
		
			crescendoVal2 = maxCrescendo;
			fill2.color = maxBar;
		}
		if (crescendoVal1 == 100 && Input.GetKeyDown (KeyCode.LeftShift)) {
		
			crescendoVal1 = 0;
			fill1.color = notMaxBar;
			foreach (GameObject obj in Lists.p2aprojectilelist) {
				Destroy (obj);
			}
			foreach (GameObject obj in Lists.p2bprojectilelist) {
				Destroy (obj);
			}
			foreach (GameObject obj in Lists.p2cprojectilelist) {
				Destroy (obj);
			}
			Lists.p2aprojectilelist.Clear ();
			Lists.p2bprojectilelist.Clear ();
			Lists.p2cprojectilelist.Clear ();


		
		}
		if (crescendoVal2 == 100 && Input.GetKeyDown (KeyCode.RightShift)) {
			
			crescendoVal2 = 0;
			fill2.color = notMaxBar;
			foreach (GameObject obj in Lists.p1aprojectilelist) {
				Destroy (obj);
			}
			foreach (GameObject obj in Lists.p1bprojectilelist) {
				Destroy (obj);
			}
			foreach (GameObject obj in Lists.p1cprojectilelist) {
				Destroy (obj);
			}
			Lists.p1aprojectilelist.Clear ();
			Lists.p1bprojectilelist.Clear ();
			Lists.p1cprojectilelist.Clear ();
		}
		crescendoSlider_P1.value = crescendoVal1;
		crescendoSlider_P2.value = crescendoVal2;
	}
}
