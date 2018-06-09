using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PokemonData : MonoBehaviour {
	public Sprite[] MonImages = new Sprite[151];
	public GameObject mainwindow, switchstats, stats1, stats2;
	public GameObject currentMenu;
	public GameObject[] allmenus;
	public List<GameObject> menuSlots, pokemenuslots, rpkmn;
	public List<GameObject> wpokemenuslots, wrpkmn;
	public int selectedOption;
	public GameObject cursor;
	public int selectedMon;
	public int numberofPokemon;
	public int MoveID;
	public MainMenu moon;
	public bool donewaiting;
	public int loadedpokemonID;
	public int loadedMonStatus;
	public bool switching;
	public pokemonstats poke;

	public float[] savedHealthPixels = new float[6];
	public float loadedhealthpixels; 
	public int[] loadedMonStats = new int[4];
	//STATS1DATA
	public Image[] healthbars = new Image[6];
	public Image stats1portrait;
	public Text pokedexNO,attacktext,speedtext,specialtext,defensetext, MonStatustext;
	// Use this for initialization
	public void Initialize () {
		for (int i = 0; i < 6; i++) {
			savedHealthPixels [i] = Mathf.RoundToInt (poke.HP [i] * 48 / poke.maxHP [i]);
			print (((savedHealthPixels [i]) / 48).ToString());
			healthbars[i].fillAmount = (savedHealthPixels[i])/48;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentMenu == stats1) {
			loadedhealthpixels = savedHealthPixels [selectedMon];
			loadedMonStats [0] = poke.Defense [selectedMon];
			loadedMonStats [1] = poke.Attack [selectedMon];
			loadedMonStats [2] = poke.Speed [selectedMon];
			loadedMonStats [3] = poke.Special [selectedMon];
			loadedMonStatus = poke.monStatus [selectedMon];
			loadedpokemonID = poke.pokemonID [selectedMon];
			stats1portrait.sprite = MonImages[loadedpokemonID - 1];
			pokedexNO.text = loadedpokemonID.ToString ();
			attacktext.text = loadedMonStats[1].ToString ();
			speedtext.text = loadedMonStats[2].ToString ();
			specialtext.text = loadedMonStats[3].ToString ();
			defensetext.text = loadedMonStats[0].ToString ();

		}
		for (int i = 0; i < 6; i++) {
			if (i == 0) {
				
				numberofPokemon = 0;
				rpkmn.Clear ();
				wrpkmn.Clear ();
			}
			if (poke.pokemonID [i] != 0) {
				wpokemenuslots [i].SetActive (true);
				pokemenuslots [i].SetActive (true);
				numberofPokemon++;
				rpkmn.Add (pokemenuslots [i]);
				wrpkmn.Add (wpokemenuslots [i]);
			} else {
				
				pokemenuslots [i].SetActive (false);
				wpokemenuslots [i].SetActive (false);

			}
			if (i == 5) {
				if (numberofPokemon == 0) {
					currentMenu = mainwindow;
					moon.currentmenu = moon.thismenu;
					this.gameObject.SetActive (false);

				}

			}
		}

		if(currentMenu == switchstats) {
			menuSlots.Resize(currentMenu.transform.childCount);
			menuSlots.Clear ();
			for (int i = 0; i < currentMenu.transform.childCount; i++) {


				menuSlots.Add(currentMenu.transform.GetChild (i).gameObject);
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
				if (selectedOption == menuSlots.Count) {
					selectedOption = menuSlots.Count - 1;

				}


		}
		if(currentMenu == mainwindow) {
			


			cursor.SetActive (true);
			cursor.transform.position = pokemenuslots [selectedOption].transform.position;



			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				selectedOption++;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				selectedOption--;
			}
			if (selectedOption < 0) {
				selectedOption = 0;

			}
			if (selectedOption == numberofPokemon) {
				selectedOption = numberofPokemon - 1;

			}


		}
		foreach (GameObject menu in allmenus) {
			if (menu != currentMenu) {
				menu.SetActive (false);
			} else {

				menu.SetActive (true);
			}


			if(menu == switchstats && (currentMenu == mainwindow)){
				menu.SetActive(false);

			}
			if(menu == mainwindow  && (currentMenu == switchstats)){
				menu.SetActive(true);

			}

		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			if (currentMenu == mainwindow) {
				if (!switching) {
					selectedMon = selectedOption;
					currentMenu = switchstats;
				} else {
					StartCoroutine(Switch());
					switching = false;
				}
				StartCoroutine (Wait ());
			}
			if (currentMenu == switchstats) {
				if (donewaiting) {
					if (selectedOption == 0) {
						currentMenu = stats1;

					}
					if (selectedOption == 1) {

						switching = true;
						selectedOption = selectedMon;
						currentMenu = mainwindow;

					}
					StartCoroutine (Wait ());
				}

			}
			if (currentMenu == stats1) {
				if (donewaiting) {
					currentMenu = mainwindow;

				}
				StartCoroutine (Wait ());
			}



		}
	}
	void UseMove(){
		switch (MoveID) {
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		case 8:
			break;
		case 9:
			break;
		case 10:
			break;
		case 11:
			break;
		case 12:
			break;
		case 13:
			break;
		case 14:
			break;
		case 15:
			break;
		case 16:
			break;
		case 17:
			break;
		case 18:
			break;
		case 19:
			break;
		case 20:
			break;
		case 21:
			break;
		case 22:
			break;
		case 23:
			break;
		case 24:
			break;
		
			//etc




		}




	}
	IEnumerator Wait(){
		donewaiting = false;
		yield return new WaitForSeconds (0.1f);
		donewaiting = true;
	}
	IEnumerator Switch(){
		//first we initialize...
		string wpokemonnameinslot = poke.pokemonnameinslot[selectedOption];
		int wDefense = poke.Defense [selectedOption];
		int wAttack = poke.Attack [selectedOption];
		int wSpeed = poke.Speed [selectedOption];
		int wSpecial = poke.Special [selectedOption];
		int wHP = poke.HP [selectedOption];
		int wmaxHP = poke.maxHP [selectedOption];
		int wpokemonID = poke.pokemonID [selectedOption];
		int wmonStatus = poke.monStatus [selectedOption];
		int wmonLevel = poke.monLevel [selectedOption];
		//then transport one
		poke.pokemonnameinslot [selectedOption] = poke.pokemonnameinslot [selectedMon];
		poke.Defense [selectedOption] = poke.Defense [selectedMon];
		poke.Attack [selectedOption] = poke.Attack [selectedMon];
		poke.Speed [selectedOption] = 	poke.Speed [selectedMon];
		poke.Special [selectedOption] = poke.Special [selectedMon];
		poke.HP [selectedOption] = poke.HP [selectedMon];
		poke.maxHP [selectedOption] = poke.maxHP [selectedMon];
		poke.pokemonID [selectedOption] = poke.pokemonID [selectedMon];
		poke.monStatus [selectedOption] = poke.monStatus [selectedMon];
		poke.monLevel [selectedOption] = poke.monLevel [selectedMon];
		//then the other
		poke.pokemonnameinslot [selectedMon] = wpokemonnameinslot;
		poke.Defense [selectedMon] = wDefense;
		poke.Attack [selectedMon] = wAttack;
		poke.Speed [selectedMon] = 	wSpeed;
		poke.Special [selectedMon] = wSpecial;
		poke.HP [selectedMon] = wHP;
		poke.maxHP [selectedMon] = wmaxHP;
		poke.pokemonID [selectedMon] = wpokemonID;
		poke.monStatus [selectedMon] = wmonStatus;
		poke.monLevel [selectedMon] = wmonLevel;

		yield return null;

	}

	IEnumerator AnimateOurHealthDown(){
		for( int i = 0; i < 6; i++){
			int newPixels = Mathf.RoundToInt (poke.HP[i] * 48 / poke.maxHP[i]);
			int result = Mathf.RoundToInt(savedHealthPixels[i] - newPixels);


		for(int l = 0; i < result ; i++){
			yield return new WaitForSeconds (.1f);
				healthbars[i].fillAmount = (savedHealthPixels[i] - l)/48;

		}
			savedHealthPixels[i] = Mathf.RoundToInt(poke.HP[i] * 48 / poke.maxHP[i]);
			healthbars[i].fillAmount = (savedHealthPixels[i])/48;
		yield return null;
	}
	}
	//these animate healing.

	IEnumerator AnimateOurHealthUp(){
		for( int i = 0; i < 6; i++){
			int newPixels = Mathf.RoundToInt (poke.HP[i] * 48 / poke.maxHP[i]);
			int result = Mathf.RoundToInt(savedHealthPixels[i] - newPixels);


			for(int l = 0; i < result ; i++){
				yield return new WaitForSeconds (.1f);
				healthbars[i].fillAmount = (savedHealthPixels[i] - l)/48;

			}
			savedHealthPixels[i] = Mathf.RoundToInt (poke.HP[i] * 48 / poke.maxHP[i]);
			healthbars[i].fillAmount = (savedHealthPixels[i])/48;
			yield return null;
		}
	}
	void HealthCheck(){
		for (int i = 0; i < 6; i++) {

			if (poke.HP[i] < 0) {

				poke.HP[i] = 0;
			}
			if (poke.HP[i] > poke.maxHP[i]) {

				poke.HP[i] = poke.maxHP[i];
			}
		}
	}
}
