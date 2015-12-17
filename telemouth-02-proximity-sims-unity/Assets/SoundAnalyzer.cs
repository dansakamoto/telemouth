using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundAnalyzer : MonoBehaviour {

	private AudioListener listener;
	private float[] spectrum = new float[256];
	private float max;
	private int level, countdown, countMax = 100;
	private int threshold = 30;
	private Controller controller;
	private Text inputThresh;

	public AudioClip[] disgustedSounds = new AudioClip[9];
	private AudioSource voiceBox;

	// Use this for initialization
	void Start () {

		listener = GetComponent<AudioListener> ();
		controller = GameObject.Find ("Controller").GetComponent<Controller>();

		//whatToSay = GameObject.Find ("Speaker").GetComponent<AudioClip> ();
		voiceBox = GameObject.Find ("Speaker").GetComponent<AudioSource> ();

		inputThresh = GameObject.Find ("Input Thresh").GetComponent<Text> ();
	
	}

	public void changeThresh(){
		threshold = (int) float.Parse(inputThresh.text);
	}

	// Update is called once per frame
	void Update () {
		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

		max = 0f;

		foreach(float x in spectrum){
			if(x > max)
				max = x;
		}

		level = (int) (max * 10000);

		Debug.Log (level);

		if (level > threshold) {
			//countdown = countMax;
			if (!voiceBox.isPlaying) {
				voiceBox.PlayOneShot (disgustedSounds[Random.Range(0,8)]);
			}
		}

		if (voiceBox.isPlaying)
			controller.active1 = true;
		else
			controller.active1 = false;






		/*
		int i = 1;
		while (i < spectrum.Length-1) {
			Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
			i++;
		}
		*/
	}
}
