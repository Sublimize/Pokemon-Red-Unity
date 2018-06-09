using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public Player play;

	public int selectedOption;
	public GameObject[] menuSlots;
	public GameObject cursor;
	public GameObject pokemonmenu, bagmenu, badgesmenu, thismenu, optionsmenu;
	public GameObject currentmenu;
	public Options opti;
	public bag lag;
	public bool donewaiting;
	public PokemonData pk;
	// Use this for initialization
	public void Initialize(){
		donewaiting = true;
		currentmenu = thismenu;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Z)) {

			donewaiting = true;
		}
		if (currentmenu == null) {
			cursor.SetActive (false);
		} else if(currentmenu == thismenu){
			menuSlots = new GameObject[currentmenu.transform.childCount];

			for (int i = 0; i < currentmenu.transform.childCount; i++) {
				

				menuSlots [i] = currentmenu.transform.GetChild (i).gameObject;
			}

			cursor.SetActive (true);
			cursor.transform.position = menuSlots [selectedOption].transform.position;



			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				selectedOption++;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				selectedOption--;
			}
			if (selectedOption < 0) {
				selectedOption = menuSlots.Length - 1;

			}
			if (selectedOption == menuSlots.Length) {
				selectedOption = 0;

			}
		}
		if (currentmenu == badgesmenu) {

			cursor.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (currentmenu == thismenu) {
				
				cursor.SetActive (false);
				currentmenu = null;
				play.startmenuup = false;


			}


		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			if (currentmenu == badgesmenu && donewaiting) {
				currentmenu = thismenu;
				badgesmenu.SetActive (false);
				donewaiting = false;

			}

		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			if (donewaiting) {
				
				if (currentmenu == thismenu) {
					if (selectedOption == 0) {
						//dex
					}
					if (selectedOption == 1) {
						if (currentmenu == thismenu) {
							currentmenu = pokemonmenu;
							pk.currentMenu = pk.mainwindow;
							pk.selectedOption = 0;
							pk.Initialize ();
							pokemonmenu.SetActive (true);
							donewaiting = false;
						}
					}
					if (selectedOption == 2) {
					

						if (currentmenu == thismenu) {
							lag.selectBag = -1;
							currentmenu = bagmenu;
							bagmenu.SetActive (true);
                            StartCoroutine(bagmenu.GetComponent<bag>().Wait());
							donewaiting = false;

						}
					}
				}
				if (selectedOption == 3) {
					currentmenu = badgesmenu;
					badgesmenu.SetActive (true);
					donewaiting = false;
				}
				if (selectedOption == 4) {

				}
				if (selectedOption == 5) {
					opti.selectedOption = 0;
					if (currentmenu == thismenu) {
						optionsmenu.SetActive (true);
						currentmenu = optionsmenu;
						donewaiting = false;


					}
				}
				if (selectedOption == 6) {
					if (currentmenu == thismenu) {
						cursor.SetActive (false);
						currentmenu = null;
						play.startmenuup = false;
						donewaiting = false;


					}
				}

			}

		
				if (currentmenu == optionsmenu) {
					if (opti.selectedOption == 3) {
						optionsmenu.SetActive (false);
						currentmenu = thismenu;
					donewaiting = false;

					}

				}

				

			donewaiting = false;
		}
		if (Input.GetKeyDown (KeyCode.H)) {

			StartCoroutine(lag.AddItem ("SPECIAL", 6));

		}
		if (Input.GetKeyDown (KeyCode.X)) {
			if (currentmenu == thismenu) {
				cursor.SetActive (false);
				currentmenu = null;
				play.startmenuup = false;

			

			}
			if (currentmenu == optionsmenu) {

				optionsmenu.SetActive (false);
				currentmenu = thismenu;

			}
		}
	}

}
