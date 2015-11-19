using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public int mode = 0; // 0 = neutral, 1 = happy, 2 = sad

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

	}
	
	void Update () {

		mode = communicator.GetComponent<Communicator>().theValue;

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
			if ((int)(Time.fixedTime*6) % 2 == 0) {
				mouthNeutralOpen.SetActive (true);
				mouthNeutralClosed.SetActive (false);
			} else {
				mouthNeutralOpen.SetActive (false);
				mouthNeutralClosed.SetActive (true);
			}
			break;

		case 1:
			mouthNeutral.SetActive (false);
			mouthHappy.SetActive (true);
			mouthSad.SetActive (false);
			if ((int)(Time.fixedTime*6) % 2 == 0) {
				mouthHappyOpen.SetActive (true);
				mouthHappyClosed.SetActive (false);
			} else {
				mouthHappyOpen.SetActive (false);
				mouthHappyClosed.SetActive (true);
			}
			break;

		case 2:
			mouthNeutral.SetActive (false);
			mouthHappy.SetActive (false);
			mouthSad.SetActive (true);
			if ((int)(Time.fixedTime*6) % 2 == 0) {
				mouthSadOpen.SetActive (true);
				mouthSadClosed.SetActive (false);
			} else {
				mouthSadOpen.SetActive (false);
				mouthSadClosed.SetActive (true);
			}
			break;
		}

	}

}
