using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MicIn : MonoBehaviour {

	//[RequireComponent(typeof(AudioSource))]

	private AudioSource audio;
	private AudioHighPassFilter HPF;
	private Text inputFreq;
	private float convertedFreq;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();

		audio.clip = Microphone.Start(null, true, 10, 44100);

		audio.loop = true; // Set the AudioClip to loop
		//audio.mute = true; // Mute the sound, we don't want the player to hear it
	//	while (!(Microphone.GetPosition("Built-in Microphone") > 0)){} // Wait until the recording has started
		audio.Play(); // Play the audio source!

		HPF = GetComponent<AudioHighPassFilter> ();
		inputFreq = GameObject.Find ("Input Freq").GetComponent<Text> ();


		//listener.GetOutputData (samples);


	}

	// Update is called once per frame
	public void ChangeFreq () {
		HPF.cutoffFrequency = float.Parse(inputFreq.text);
	}
}
