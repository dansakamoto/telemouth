using UnityEngine;
using System.Collections;

public class Communicator : MonoBehaviour {

	public int theValue = 0;
	private GameObject meter;

	// Use this for initialization
	void Start () {
		meter = GameObject.Find ("Meter");
	}
	
	// Update is called once per frame
	void Update () {
		theValue = (int) meter.transform.position.x;
	}

	public void setVal(int x){
		theValue = x;
	}
}