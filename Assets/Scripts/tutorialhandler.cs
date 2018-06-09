using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tutorialhandler : MonoBehaviour {
	public Dialogue mylog;
	public GameObject cursor, rednamemenu, garynamemenu,nameselectionmenu, currentmenu, oak, gary, red;
	public Animator tutanim;
	public int selectedOption;
	public GameObject[] menuSlots;
	public GameObject[] allmenus;
	public GameObject overworld, white;
	public bool givingRedAName, givingGaryAName;
	public Dialogue dia;
	public Player play;
	public NameSelection names;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentmenu == null && currentmenu != nameselectionmenu) {
			cursor.SetActive (false);
		} else {
			menuSlots = new GameObject[currentmenu.transform.childCount];
		
			for (int i = 0; i < currentmenu.transform.childCount; i++) {
				if (i == 4) {
					break;
				}

				menuSlots [i] = currentmenu.transform.GetChild (i).gameObject;
			}
			cursor.transform.position = menuSlots [selectedOption].transform.position;
		
			cursor.SetActive (true);
		
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				selectedOption++;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				selectedOption--;
			}
			if (selectedOption < 0) {
				selectedOption = 0;

			}
			if (selectedOption == menuSlots.Length) {
				selectedOption = menuSlots.Length - 1;

			}
		}
			foreach (GameObject menu in allmenus) {
				if (menu != currentmenu) {
					menu.SetActive (false);
				} else {

					menu.SetActive (true);
				}

			
			}

		if (Input.GetKeyDown (KeyCode.Z)) {
			
			if (currentmenu == rednamemenu && selectedOption == 	0) {
				currentmenu = nameselectionmenu;
				nameselectionmenu.SetActive (true);
				names.futureName = "";
			}
			if (currentmenu == rednamemenu && selectedOption == 	1) {
				currentmenu = null;
				dia.Name = "RED";
				tutanim.SetBool ("fourthpass", true);
				mylog.enabled = true;
				givingRedAName = false;
			}
			if (currentmenu == rednamemenu && selectedOption == 	2) {
				currentmenu = null;
				dia.Name = "ASH";
				tutanim.SetBool ("fourthpass", true);
				mylog.enabled = true;
				givingRedAName = false;

			}
			if (currentmenu == rednamemenu && selectedOption == 	3) {
				currentmenu = null;
				dia.Name = "JACK";
				tutanim.SetBool ("fourthpass", true);
				mylog.enabled = true;
				givingRedAName = false;
			}
			if (currentmenu == garynamemenu && selectedOption == 	0) {
				currentmenu = nameselectionmenu;
				nameselectionmenu.SetActive (true);
				names.futureName = "";
			}
			if (currentmenu == garynamemenu && selectedOption == 	1) {
				currentmenu = null;
				dia.opponentName = "BLUE";
				tutanim.SetBool ("seventhpass", true);
				mylog.enabled = true;
				givingRedAName = false;
			}
			if (currentmenu == garynamemenu && selectedOption == 	2) {
				currentmenu = null;
				dia.opponentName = "GARY";
				tutanim.SetBool ("seventhpass", true);
				mylog.enabled = true;
				givingRedAName = false;

			}
			if (currentmenu == garynamemenu && selectedOption == 	3) {
				currentmenu = null;
				dia.opponentName = "JOHN";
				tutanim.SetBool ("seventhpass", true);
				mylog.enabled = true;
				givingRedAName = false;
			}
		}
	}

	public IEnumerator FirstOakDialogue(){
		play.amenuactive = true;
		mylog.deactivated = true;
		currentmenu = null;
		yield return StartCoroutine(mylog.text ("Hello there!"));
		yield return StartCoroutine(mylog.line ("Welcome to the",0));
		yield return StartCoroutine(mylog.cont ("world of POKeMON!",1));
		yield return StartCoroutine(mylog.para ("My name is OAK!"));
		yield return StartCoroutine(mylog.line("People call me",0));
		yield return StartCoroutine(mylog.cont ("the POKeMON PROF!"));
		yield return StartCoroutine(mylog.done ());
		tutanim.SetBool ("firstpass", true);

	}
	public IEnumerator SecondOakDialogue(){
		yield return StartCoroutine(mylog.text ("This world is"));
		yield return StartCoroutine(mylog.line ("inhabited by",0));
		yield return StartCoroutine(mylog.cont ("creatures called"));
		yield return StartCoroutine(mylog.line ("POKeMON!",1));
		yield return StartCoroutine(mylog.para("For some people,"));
		yield return StartCoroutine(mylog.line ("POKeMON are",0));
		yield return StartCoroutine(mylog.cont ("pets. Others use"));
		yield return StartCoroutine(mylog.line ("them for fights.",1));
		yield return StartCoroutine(mylog.para("Myself...",1));
		yield return StartCoroutine(mylog.para ("I study POKeMON"));
		yield return StartCoroutine(mylog.line ("as a profession."));
		yield return StartCoroutine(mylog.done ());
		tutanim.SetBool ("secondpass", true);

	}
	public IEnumerator ThirdOakDialogue(){
		
		yield return StartCoroutine(mylog.text ("First, what is"));
		yield return StartCoroutine(mylog.line ("your name?"));
		yield return StartCoroutine(mylog.done ());
		tutanim.SetBool ("thirdpass", true);
		mylog.enabled = false;

		currentmenu = rednamemenu;
		selectedOption = 0;
		givingRedAName = true;
}
	public IEnumerator FourthOakDialogue(){

		yield return StartCoroutine(mylog.text ("Right! So your"));
		yield return StartCoroutine(mylog.line ("name is " + dia.Name + "!"));
		yield return StartCoroutine(mylog.done ());
		tutanim.SetBool ("fifthpass", true);

	}
	public IEnumerator FifthOakDialogue(){

		yield return StartCoroutine(mylog.text ("This is my grand-"));
		yield return StartCoroutine(mylog.line ("son. He's been",0));
		yield return StartCoroutine(mylog.cont ("your rival since"));
		yield return StartCoroutine(mylog.line ("you were a baby.",1));
		yield return StartCoroutine(mylog.para ("...Erm, what is"));
		yield return StartCoroutine(mylog.line ("his name again?"));
		yield return StartCoroutine(mylog.done ());
		tutanim.SetBool ("sixthpass", true);
		mylog.enabled = false;

		currentmenu = garynamemenu;
		selectedOption = 0;
		givingGaryAName = true;
	}
	public IEnumerator SixthOakDialogue(){

		yield return StartCoroutine(mylog.text ("That's right! I"));
		yield return StartCoroutine(mylog.line ("remember now! His",0));
		yield return StartCoroutine(mylog.cont ("name is " + dia.opponentName + "!"));
		yield return StartCoroutine(mylog.done());
		tutanim.SetBool ("eighthpass", true);
	}
	public IEnumerator SeventhOakDialogue(){

		yield return StartCoroutine(mylog.text (dia.Name + "!",1));
		yield return StartCoroutine(mylog.para ("Your very own"));
		yield return StartCoroutine(mylog.line ("POKeMON legend is",0));
		yield return StartCoroutine(mylog.cont("about to unfold!",1));
		yield return StartCoroutine(mylog.para ("A world of dreams"));
		yield return StartCoroutine(mylog.line ("and adventures",0));
		yield return StartCoroutine(mylog.cont ("with POKeMON"));
		yield return StartCoroutine(mylog.line ("awaits! Let's go!"));
		yield return StartCoroutine(mylog.done());
		tutanim.SetBool ("ninthpass", true);
	}
	void DisableOak(){

		oak.GetComponent<Image> ().enabled = false;
	}
	void DisableGary(){

		gary.GetComponent<Image> ().enabled = false;
	}
	void EnableGary(){

		gary.GetComponent<Image> ().enabled = true;
	}
	void DisableRed(){

		red.GetComponent<Image> ().enabled = false;
	}
	void EnableRed(){

		red.GetComponent<Image> ().enabled = true;
	}
	void GotoOverworld(){
		overworld.SetActive (true);
		white.SetActive (false);
		play.amenuactive = false;
		mylog.deactivated = false;
			play.disabled = false;

		this.gameObject.SetActive (false);

	}
}
