using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrowdMeter : MonoBehaviour {

	public static int currentCrowdState = 50;
	int maxvalue = 100;
	int minvalue = 0;

	private Slider crowdSlider;

	// Use this for initialization
	void Start () {
		crowdSlider = this.GetComponent<Slider> ();
	}
	void OnEnable()
	{
		TakeDamage.gotHit += UpdateCrowdState;
	}
	void OnDisable()
	{
		TakeDamage.gotHit -= UpdateCrowdState;
	}
	
	// Update is called once per frame
	void UpdateCrowdState () {

		if (currentCrowdState > maxvalue) {
			currentCrowdState = maxvalue;
		} 

		else if (currentCrowdState < minvalue) {
			currentCrowdState = minvalue;
		} 

		else {
			crowdSlider.value = currentCrowdState;
		}
	}
}
