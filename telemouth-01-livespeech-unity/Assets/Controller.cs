using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public int mode = 0; // 0 = neutral, 1 = happy, 2 = sad

	private int timer = 0, timerMax = 5;

	private string ip;

	public double micThreshold = .01;

	private GameObject mouthNeutral,
		mouthHappy, 
		mouthSad,
		mouthNeutralOpen,
		mouthHappyOpen,
		mouthSadOpen,
		mouthNeutralClosed,
		mouthHappyClosed,
		mouthSadClosed;

	private GameObject communicator;

	private bool initText = true;

	void Start(){
		mouthNeutral = GameObject.Find ("Mouth Neutral");
		mouthNeutralOpen = GameObject.Find ("Mouth Neutral Open");
		mouthNeutralClosed = GameObject.Find ("Mouth Neutral Closed");
		mouthHappy = GameObject.Find ("Mouth Happy");
		mouthHappyOpen = GameObject.Find ("Mouth Happy Open");
		mouthHappyClosed = GameObject.Find ("Mouth Happy Closed");
		mouthSad = GameObject.Find ("Mouth Sad");
		mouthSadOpen = GameObject.Find ("Mouth Sad Open");
		mouthSadClosed = GameObject.Find ("Mouth Sad Closed");

		mouthHappy.SetActive (false);
		mouthSad.SetActive (false);
		mouthNeutralOpen.SetActive (false);

		communicator = GameObject.FindGameObjectWithTag ("OSC");

		ip = Network.player.ipAddress;

	}
	
	void Update () {

		mode = communicator.GetComponent<Communicator>().theValue;

		if (initText && Time.fixedTime > 6) {
			initText = false;
			GameObject.Destroy (GameObject.Find ("Debug"));
		}

		if(initText)
			GameObject.Find ("Debug").GetComponent<Text> ().text = ip + "\n" + mode;

		/*
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			mode = 0;
			mouthNeutral.SetActive (true);
			mouthHappy.SetActive (false);
			mouthSad.SetActive (false);
		} else if(Input.GetKeyDown(KeyCode.Alpha2)){
			mode = 1;
			mouthNeutral.SetActive (false);
			mouthHappy.SetActive (true);
			mouthSad.SetActive (false);
		} else if(Input.GetKeyDown(KeyCode.Alpha3)){
			mode = 2;
			mouthNeutral.SetActive (false);
			mouthHappy.SetActive (false);
			mouthSad.SetActive (true);
		}
		*/


		switch(mode){
		case 0:
			mouthNeutral.SetActive (true);
			mouthHappy.SetActive (false);
			mouthSad.SetActive (false);
			if (MicInput.MicLoudness > micThreshold) {
				timer = timerMax;
				mouthNeutralOpen.SetActive (true);
				mouthNeutralClosed.SetActive (false);
			} else if(timer <= 0){
				mouthNeutralOpen.SetActive (false);
				mouthNeutralClosed.SetActive (true);
			} else {
				timer--;
			}
			break;

		case 1:
			mouthNeutral.SetActive (false);
			mouthHappy.SetActive (true);
			mouthSad.SetActive (false);
			if (MicInput.MicLoudness > micThreshold) {
				timer = timerMax;
				mouthHappyOpen.SetActive (true);
				mouthHappyClosed.SetActive (false);
			} else if(timer <= 0){
				mouthHappyOpen.SetActive (false);
				mouthHappyClosed.SetActive (true);
			} else {
				timer--;
			}
			break;

		case 2:
			mouthNeutral.SetActive (false);
			mouthHappy.SetActive (false);
			mouthSad.SetActive (true);
			if (MicInput.MicLoudness > micThreshold) {
				timer = timerMax;
				mouthSadOpen.SetActive (true);
				mouthSadClosed.SetActive (false);
			} else if(timer <= 0){
				mouthSadOpen.SetActive (false);
				mouthSadClosed.SetActive (true);
			} else {
				timer--;
			}
			break;
		}

	}

}
