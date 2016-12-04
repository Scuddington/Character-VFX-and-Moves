using UnityEngine;
using System.Collections;


public class AudioManager : MonoBehaviour {

	public AudioSource rockAudio;
	public AudioSource classicalAudio;
	public AudioSource applauseAudio;
	public AudioSource reactionAudio;


	public ParticleSystem sparks;

	private int p2ThreshA = 66;
	private int p2ThreshB = 82;
	private int p1ThreshA = 34;
	private int p1ThreshB = 18;
	private float p2VolA = 0.75f;
	private float p2VolB = 1.0f;
	private float p1VolA = 0.75f;
	private float p1VolB = 1.0f;
	private float p1MinusA = 0.4f;
	private float p1MinusB = 0.3f;
	private float p2MinusA = 0.4f;
	private float p2MinusB = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float currentClassicalVolume = classicalAudio.volume;
		float currentRockVolume = rockAudio.volume;

		if (CrowdMeter.currentCrowdState >= p2ThreshA && CrowdMeter.currentCrowdState < p2ThreshB && currentClassicalVolume < p2VolA && applauseAudio.isPlaying == false) {
		
			classicalAudio.volume = p2VolA;
			rockAudio.volume = p1MinusA;

			sparks.Play ();
			applauseAudio.Play ();
		} 
		else if (CrowdMeter.currentCrowdState >= p2ThreshB && currentClassicalVolume < p2VolB && applauseAudio.isPlaying == false) {
		
			classicalAudio.volume = p2VolB;
			rockAudio.volume = p1MinusB;

			sparks.Play ();
			applauseAudio.Play ();
		}
		else if (CrowdMeter.currentCrowdState <= p1ThreshA && CrowdMeter.currentCrowdState < p1ThreshA && currentRockVolume < p1VolA && applauseAudio.isPlaying == false) {

			rockAudio.volume = p1VolA;
			classicalAudio.volume = p2MinusA;

			sparks.Play ();
			applauseAudio.Play ();
		}
		else if (CrowdMeter.currentCrowdState <= p1ThreshB && currentRockVolume < p1VolB && applauseAudio.isPlaying == false) {

			rockAudio.volume = p1VolB;
			classicalAudio.volume = p2MinusB;

			sparks.Play ();
			applauseAudio.Play ();
		}
		else if (CrowdMeter.currentCrowdState < p2ThreshB && currentClassicalVolume >= p2VolB && reactionAudio.isPlaying == false) {

			classicalAudio.volume = p2VolA;
			rockAudio.volume = p1MinusA;

			reactionAudio.Play ();
		} 
		else if (CrowdMeter.currentCrowdState < p2ThreshA && currentClassicalVolume >= p2VolA && reactionAudio.isPlaying == false) {

			classicalAudio.volume = 0.5f;
			rockAudio.volume = 0.5f;

			reactionAudio.Play ();
		}
		else if (CrowdMeter.currentCrowdState > p1ThreshB && currentRockVolume >= p1VolB && reactionAudio.isPlaying == false) {

			rockAudio.volume = p1VolA;
			classicalAudio.volume = p2MinusA;

			reactionAudio.Play ();
		}
		else if (CrowdMeter.currentCrowdState > p1ThreshA && currentRockVolume >= p1VolA) {

			rockAudio.volume = 0.5f;
			classicalAudio.volume = 0.5f;

			reactionAudio.Play ();
		}
		else if (CrowdMeter.currentCrowdState == 50) {

			rockAudio.volume = 0.5f;
			classicalAudio.volume = 0.5f;

		}


		}
	}

