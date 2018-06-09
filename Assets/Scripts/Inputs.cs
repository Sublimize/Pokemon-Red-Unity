using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
	public  bool apressed, bpressed, selectpressed, startpressed;
	public  KeyCode A, B, START, SELECT;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	StartCoroutine(CheckInput ());

	}
	IEnumerator CheckInput(){
		if (Input.GetKeyUp (A)) {

			apressed = false;
		}
		if (Input.GetKeyUp (B)) {

			bpressed = false;
		}
		if (Input.GetKeyUp (START)) {

			startpressed = false;
		}
		if (Input.GetKeyUp (SELECT)) {

			selectpressed = false;
		}
		yield return new WaitForEndOfFrame ();
		if (Input.GetKeyDown (A)) {

			apressed = true;
		}
		if (Input.GetKeyDown (B)) {

			bpressed = true;
		}
		if (Input.GetKeyDown (START)) {

			startpressed = true;
		}
		if (Input.GetKeyDown (SELECT)) {

			selectpressed = true;
		}
	
	}
}