using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewBio : MonoBehaviour {
	public Image bioscreen;
	public int currentBioNumber;
	public Inputs INPUT;

	public Sprite[] bios = new Sprite[453];
	// Use this for initialization
	void Start(){
		bios = Resources.LoadAll<Sprite> ("Bios");
		bioscreen.enabled = false;

	}

	public IEnumerator DisplayABio(int whatBio){
		
		bioscreen.enabled = true;
			currentBioNumber = 0;
		for (int i = 0; i < 3; i++) {
			bool DisplayingBio = true;
			bioscreen.sprite = bios [whatBio + (2 * (whatBio - 1)) + (currentBioNumber - 1)];
			currentBioNumber++;
			while (DisplayingBio) {
					yield return new WaitForSeconds (0.01f);
				if (Input.GetKeyDown (INPUT.A) && !INPUT.apressed) {
					DisplayingBio = false;
						break;

				}
			}

		}
		bioscreen.enabled = false;
	}
}

