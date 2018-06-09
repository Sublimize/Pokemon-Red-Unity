using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour {


	public int[] enemyDefense = new int[6];
	public int[] enemyAttack = new int[6];
	public int[] enemySpeed = new int[6];
	public int[] enemySpecial = new int[6];
	public int[] enemyHP = new int[6];
	public int[] enemymaxHP = new int[6];
	public int[] enemypokemonID = new int[6];
	public int[] enemymonStatus = new int[6];
	public int[] enemyMonLevel = new int[6];
	public Dialogue mylog;
	public pokemonstats pkmr;
	public GameObject actualscene, ourstats, opponentstats;
	public Animator battletransitionAnim, otheranim;
	public bool donetransition;
	public GameObject ourpokeballs, opponentballs;
	public Image battleoverlay, frontportrait, backportrait;
	public Sprite[] backmon, frontmon;
	public Sprite blank, initial, enemystats, allstats;
	//current loaded your mon stats
	public string friendpokemonnameinslot;
	public int friendDefense;
	public int friendAttack;
	public int friendSpeed;
	public int friendSpecial;
	public int friendHP;
	public int friendmaxHP;
	public int friendpokemonID;
	public int friendmonStatus;
	public int friendmonLevel;
	public Text friendHPtext;
	public Text friendmaxHPtext;
	public Text friendmonLeveltext;
	public int oldfriendhealth;
	public Image friendHPBar;
	public float friendsavedhealthpixels;
	//current loaded enemymon stats

	public string enemypokemonnameinslot;
	public int foeDefense;
	public int foeAttack;
	public int foeSpeed;
	public int foeSpecial;
	public int foeHP;
	public int foemaxHP;
	public int foepokemonID;
	public int foemonStatus;
	public int foemonLevel;
	public int oldfoehealth;
	public Text foemonLeveltext;
	public Image foeHPBar;
	public float foesavedhealthpixels;
	//
	public bool readytobattle;
	public GameObject currentmenu;
	public GameObject battlemenu, movesmenu;
	public GameObject[] allmenus;
	public GameObject cursor;
	public GameObject[] menuSlots;
	public int selectedOption;
	public int currentLoadedMon;
	// Use this for initialization
	void Start(){
		frontmon = Resources.LoadAll <Sprite> ("frontmon");
		this.gameObject.SetActive (false);
	}
	public void Initialize(){
		currentLoadedMon = 0;
		foepokemonID = enemypokemonID [0];
		foemonLevel = enemyMonLevel [0];
		foemaxHP = enemymaxHP [0];
		foeHP = foemaxHP;

		friendpokemonID = pkmr.pokemonID [0];
		friendmonLevel = pkmr.monLevel [0];
		friendmaxHP = pkmr.maxHP[0];
		friendHP = pkmr.HP[0];

		friendsavedhealthpixels = Mathf.Round (friendHP * 48 / friendmaxHP);
		foesavedhealthpixels = Mathf.Round (foeHP * 48 / foemaxHP);
		foeHPBar.fillAmount = (Mathf.Round(foeHP * 48 / foemaxHP))/48;
		friendHPBar.fillAmount = (Mathf.Round(friendHP * 48 / friendmaxHP))/48;
		ourstats.SetActive (false);
		opponentstats.SetActive (false);
		ourpokeballs.SetActive(false);
		opponentballs.SetActive (false);
		if (pkmr.monLevel [0] - enemyMonLevel [0] <= -3) {
			battletransitionAnim.SetInteger ("transitiontype",1);
		}
		if (pkmr.monLevel [0] - enemyMonLevel [0] >= -2) {
			battletransitionAnim.SetInteger ("transitiontype",2);
		}




	}
	void DoneWithTransition(){

		donetransition = true;

	}
	public IEnumerator PokeballShow(){
		battleoverlay.sprite = initial;

		ourpokeballs.SetActive(true);
		opponentballs.SetActive (true);
		yield return StartCoroutine(mylog.text ("TRAINER wants to battle!"));
		yield return StartCoroutine(mylog.done ());

		ourpokeballs.SetActive(false);
		opponentballs.SetActive (false);
		otheranim.SetInteger ("currentpass", 1);

	}
	
	// Update is called once per frame
	void Update () {
		
		foreach (GameObject menu in allmenus) {
			if (menu != currentmenu) {
				menu.SetActive (false);
			} else {

				menu.SetActive (true);
			}


		}
		if (donetransition) {
			if (Input.GetKeyDown (KeyCode.R)) {
				friendHP -= 10;
				HealthCheck ();
				StartCoroutine(AnimateOurHealthDown ());
			}
			if (Input.GetKeyDown (KeyCode.T)) {
				foeHP -= 10;
				HealthCheck ();
				StartCoroutine(AnimateEnemyHealthDown ());
			//
			}
			if (Input.GetKeyDown (KeyCode.Y)) {
				friendHP += 10;
				HealthCheck ();
				StartCoroutine(AnimateOurHealthUp ());
			}
			if (Input.GetKeyDown (KeyCode.U)) {
				foeHP += 10;
				HealthCheck ();
				StartCoroutine(AnimateEnemyHealthUp ());
				//
			}



			foemonLeveltext.text = foemonLevel.ToString ();
			friendmonLeveltext.text = friendmonLevel.ToString ();
			friendHPtext.text = friendHP.ToString ();
			friendmaxHPtext.text = friendmaxHP.ToString (); 

			actualscene.SetActive (true);
			if (readytobattle) {
				
				currentmenu = battlemenu;
				if (currentmenu == battlemenu) {

					menuSlots = new GameObject[currentmenu.transform.childCount];

					for (int i = 0; i < currentmenu.transform.childCount; i++) {


						menuSlots [i] = currentmenu.transform.GetChild (i).gameObject;
					}
				
				}
				if (currentmenu == battlemenu) {
					
					cursor.SetActive (true);
					cursor.transform.position = menuSlots [selectedOption].transform.position;




					if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						
						if (selectedOption == 1) {
							selectedOption = 0;
							return;
						}

						if (selectedOption == 3) {
							selectedOption = 2;
							return;
						}
					}
					if (Input.GetKeyDown (KeyCode.RightArrow)) {
						
						if (selectedOption == 0) {
							selectedOption = 1;
							return;
						}

						if (selectedOption == 2) {
							selectedOption = 3;
							return;
						}
					}
					if (Input.GetKeyDown (KeyCode.UpArrow)) {
						if (selectedOption == 2) {
							selectedOption = 0;
							return;
						}
						if (selectedOption == 3) {
							selectedOption = 1;
							return;
						}




					}
					if (Input.GetKeyDown (KeyCode.DownArrow)) {
						if (selectedOption == 0) {
							selectedOption = 2;
							return;
						}
						if (selectedOption == 1) {
							selectedOption = 3;
							return;
						}



					}



				}
			} else {

				currentmenu = null;

			}
		}
	
	}
	public void DetermineFrontSprite(){
		frontportrait.overrideSprite = frontmon [foepokemonID - 1];

	}

	public void DetermineBackSprite(){
		backportrait.overrideSprite = backmon [friendpokemonID - 1];

	}
	public void ActivateOurStats(){
		ourstats.SetActive (true);
		battleoverlay.sprite = allstats;
	}
	public void ActivateTheirStats(){
		opponentstats.SetActive (true);
		battleoverlay.sprite = enemystats;
	}
	//these functions animate damage, not healing.
	IEnumerator AnimateEnemyHealthDown(){
		float newPixels = Mathf.Round (foeHP * 48 / foemaxHP);
		int result = Mathf.RoundToInt(foesavedhealthpixels - newPixels);


		for(int i = 0; i < result ; i++){
			yield return new WaitForSeconds (.1f);
		foeHPBar.fillAmount = (foesavedhealthpixels - i)/48;


	}
		foesavedhealthpixels = Mathf.Round (foeHP * 48 / foemaxHP);
		foeHPBar.fillAmount = (Mathf.Round(foeHP * 48 / foemaxHP))/48;
		yield return null;
	}
	IEnumerator AnimateOurHealthDown(){

		float newPixels = Mathf.Round (friendHP * 48 / friendmaxHP);
		int result = Mathf.RoundToInt(friendsavedhealthpixels - newPixels);


		for(int i = 0; i < result ; i++){
			yield return new WaitForSeconds (.1f);
			friendHPBar.fillAmount = (friendsavedhealthpixels - i)/48;

		}
		friendsavedhealthpixels = Mathf.Round (friendHP * 48 / friendmaxHP);
		friendHPBar.fillAmount = (Mathf.Round(friendHP * 48 / friendmaxHP))/48;
		pkmr.HP[currentLoadedMon] = friendHP;
		yield return null;
	}
	//these animate healing.
	IEnumerator AnimateEnemyHealthUp(){
		float newPixels = Mathf.Round (foeHP * 48 / foemaxHP);
		int result = Mathf.RoundToInt(newPixels - foesavedhealthpixels);


		for(int i = 0; i < result ; i++){
			yield return new WaitForSeconds (.1f);
			foeHPBar.fillAmount = (foesavedhealthpixels + i)/48;

		}
		foesavedhealthpixels = Mathf.Round (foeHP * 48 / foemaxHP);
		foeHPBar.fillAmount = (Mathf.Round(foeHP * 48 / foemaxHP))/48;

		yield return null;
	}
	IEnumerator AnimateOurHealthUp(){

		float newPixels = Mathf.Round (friendHP * 48 / friendmaxHP);
		int result = Mathf.RoundToInt(newPixels - friendsavedhealthpixels);


		for(int i = 0; i < result ; i++){
			yield return new WaitForSeconds (.1f);
			friendHPBar.fillAmount = (friendsavedhealthpixels + i)/48;

		}
		friendsavedhealthpixels = Mathf.Round (friendHP * 48 / friendmaxHP);

		friendHPBar.fillAmount = (Mathf.Round(friendHP * 48 / friendmaxHP))/48;
		pkmr.HP[currentLoadedMon] = friendHP;
		yield return null;
	}
	void HealthCheck(){
		if (foeHP < 0) {
			foeHP = 0;

		}
		if (foeHP > foemaxHP) {
			foeHP = foemaxHP;

		}
		if (friendHP < 0) {

			friendHP = 0;
		}
		if (friendHP > friendmaxHP) {

			friendHP = friendmaxHP;
		}
		pkmr.HP [currentLoadedMon] = friendHP;
		}


	}

