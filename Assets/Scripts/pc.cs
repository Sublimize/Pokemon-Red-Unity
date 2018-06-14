using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class pc : MonoBehaviour  {
	public GameObject currentMenu;
	public GameObject cursor;
	public GameObject mainwindow, itemwindow,   quantitymenu;
	public GameObject[] menuSlots, itemSelectSlots;
	public Dialogue mylog;
	public Player play;
	public int selectedOption;
	public GameObject[] allMenus;
	public int ItemMode;
	//1 is withdraw;
	//2 is deposit;
	//3 is toss;
	public List<GameObject> Items = new List<GameObject>(51);
	public itemdatabase id;
	public int currentBagPosition;
	public GameObject cancel;
	public int actualslots, wactualslots;
	public List<GameObject> realslots;
	public List<GameObject> fakerealslots;
	public int selectBag;
	public int amountToTask;
	public bool didFirstRunthrough;
	public int maximumItem;
	public TextMeshProUGUI amountText;
	public bool donewaiting;
	public GameObject last;
	public bool alreadyInBag;
	public bool alreadydidtext;

	public bool withdrawing;
    public int offscreenindexup, offscreenindexdown;
    public GameObject content;

	void Start() {
		
	
	}


		
	


	
	public void Initialize(){
		
		mylog.cantscroll = true;
		StartCoroutine(mylog.text ("What do you want to do?"));
		currentMenu = mainwindow;
		play.PCactive = true;

	}
	// Update is called once per frame
	void Update () {
        if (currentBagPosition == 0)
        {
            offscreenindexup = -1;
            offscreenindexdown = 4;
        }
		amountText.text = amountToTask.ToString ();
		if (currentMenu == quantitymenu) {
			
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				amountToTask--;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				amountToTask++;
			}
			if (amountToTask < 1) {
				amountToTask = maximumItem;

			}
			if (amountToTask > maximumItem) {
				amountToTask = 1;

			}


		}
		if (currentMenu == itemwindow) {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentBagPosition++;
                if (currentBagPosition == offscreenindexdown && offscreenindexdown != realslots.Count)
                {
                    offscreenindexup++;
                    offscreenindexdown++;

                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentBagPosition--;
                if (currentBagPosition == offscreenindexup && offscreenindexup > -1)
                {
                    offscreenindexup--;
                    offscreenindexdown--;

                }

            }
            if (currentBagPosition < 0)
            {

                currentBagPosition = realslots.Count - 1;
                if (offscreenindexdown < 0)
                {
                    content.transform.localPosition = new Vector3(0, 16 * (realslots.Count - 4), 0);

                }
                if (realslots.Count >= 4)
                {
                    offscreenindexup = realslots.Count - 5;
                    offscreenindexdown = realslots.Count;
                }
                else
                {
                    offscreenindexup = -1;
                    offscreenindexdown = realslots.Count;
                }


            }
            if (currentBagPosition == realslots.Count)
            {

                currentBagPosition = 0;

                if (offscreenindexdown == realslots.Count)
                {
                    Debug.Log("Set back to 0");
                    content.transform.localPosition = new Vector3(0, 32, 0);
                }


                offscreenindexup = -1;
                offscreenindexdown = 4;
            }
            content.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 16 * (offscreenindexup + 1));


			if (ItemMode == 2) {

					for (int i = 0; i < 20; i++) {
						if (i == 0) {
							wactualslots = 0;
						}
				
						if (id.itemslots [i] != "null") {
							Items [i].SetActive (true);
							wactualslots++; 
							realslots.Resize (wactualslots + 1);
						Items [i].GetComponent<itemslotinformation> ().Name = id.itemslots [i]; 
						Items [i].GetComponent<itemslotinformation> ().isKeyItem = id.KeyItem [i]; 
							realslots [wactualslots - 1] = Items [i];

						} else {
							Items [i].SetActive (false);


						}
						if (i == 19) {
							wactualslots++;
							realslots.Resize (wactualslots);
							realslots [wactualslots - 1] = cancel;
							actualslots = wactualslots;
						}
					}
					for (int i = 0; i < 20; i++) {
					
						if (id.itemslots [i] != "null") {
							Items [i].GetComponent<itemslotinformation> ().intquantity = id.quantity [i]; 

						}
					}
					
			
			}
			if (ItemMode == 1 || ItemMode == 3) {
				for (int i = 0; i < 50; i++) {
					if (i == 0) {
						wactualslots = 0;
					}
					if (id.PCslots [i] != "null") {
						wactualslots++; 
						realslots.Resize(wactualslots + 1);
						Items [i].SetActive (true);
						Items [i].GetComponent<itemslotinformation> ().Name = id.PCslots [i]; 
						Items [i].GetComponent<itemslotinformation> ().isKeyItem = id.PCKeyItem [i]; 
						realslots [wactualslots - 1] = Items [i];
					} else {
						Items [i].SetActive (false);


					}
					if (i == 49) {
						wactualslots++;
						realslots.Resize(wactualslots);
						realslots [wactualslots - 1] = cancel;

						actualslots = wactualslots;
					}
				}

				for (int i = 0; i < 50; i++) {
					if (id.PCslots [i] != "null") {
						Items [i].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [i]; 

					}

				}


			}

			didFirstRunthrough = true;
			itemSelectSlots = new GameObject[realslots.Count];

			for (int i = 0; i < realslots.Count; i++) {

				itemSelectSlots [i] = realslots [i].transform.GetChild (0).gameObject;
			}
			cursor.SetActive (true);
			cursor.transform.position = itemSelectSlots[currentBagPosition].transform.position;
		
			if (currentBagPosition != realslots.Count - 1) {
				maximumItem = realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity;
			} else {
				maximumItem = 0;

			}


		}
		if (currentMenu == null &&( currentMenu != quantitymenu || currentMenu != itemwindow)) {
			cursor.SetActive (false);
		} else {
			menuSlots = new GameObject[currentMenu.transform.childCount];

			for (int i = 0; i < currentMenu.transform.childCount; i++) {
				 

				menuSlots [i] = currentMenu.transform.GetChild (i).gameObject;
			}
			if (currentMenu == mainwindow) {
				

				cursor.SetActive (true);
				cursor.transform.position = menuSlots [selectedOption].transform.position;

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
		}
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			if (selectBag == -1) {
				selectBag = currentBagPosition;
			} else {
				//our bag
				if(ItemMode == 2){
					string selectName = realslots [selectBag].GetComponent<itemslotinformation> ().Name;
					int selectquantity = realslots [selectBag].GetComponent<itemslotinformation> ().intquantity;
					bool isitkey = realslots [selectBag].GetComponent<itemslotinformation> ().isKeyItem;
					realslots [selectBag].GetComponent<itemslotinformation> ().isKeyItem = realslots [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem;
					realslots [selectBag].GetComponent<itemslotinformation> ().Name = realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name;
					realslots [selectBag].GetComponent<itemslotinformation> ().intquantity = realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity;
					realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name = selectName;
					realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity = selectquantity;
					realslots [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem = isitkey;
					selectBag = -1;
				}


				if(ItemMode == 1 || ItemMode == 3){
					string selectName = realslots [selectBag].GetComponent<itemslotinformation> ().Name;
					int selectquantity = realslots [selectBag].GetComponent<itemslotinformation> ().intquantity;
					realslots [selectBag].GetComponent<itemslotinformation> ().Name = realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name;
					realslots [selectBag].GetComponent<itemslotinformation> ().intquantity = realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity;
					realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name = selectName;
					realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity = selectquantity;
					 
					selectBag = -1;
				}



			}


		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			if (donewaiting) {
				if (currentMenu == itemwindow) {
					if (donewaiting) {
						if (currentBagPosition == realslots.Count - 1) {
							mylog.Deactivate ();
							mylog.cantscroll = true;
							mylog.text ("What do you want to do?");
							currentMenu = mainwindow;
						} else {
							if (Items [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem == false || ItemMode != 3) {
								amountToTask = 1;
								mylog.Deactivate ();
								mylog.cantscroll = true;
								mylog.text ("How much?");
								currentMenu = quantitymenu;
							}



						}
						if (Items [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem && ItemMode == 3) {
							StartCoroutine (TooImportantToToss ());
						}
					}
					StartCoroutine (Wait ());
				}

				if (currentMenu == mainwindow) {
					if (donewaiting) {
						if (selectedOption == 0) {
							if (realslots.Count > 1) {
								for (int i = 0; i < realslots.Count - 1; i++) {
									Items [i].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [i];
									Items [i].GetComponent<itemslotinformation> ().isKeyItem  = id.PCKeyItem [i];
									Items [i].GetComponent<itemslotinformation> ().Name = id.PCslots[i];


								}
							}
							ItemMode1 ();


						}
						if (selectedOption == 1) {
							if (realslots.Count > 1) {
								for (int i = 0; i < realslots.Count - 1; i++) {
									Items [i].GetComponent<itemslotinformation> ().intquantity = id.quantity [i];
									Items [i].GetComponent<itemslotinformation> ().isKeyItem  = id.KeyItem [i];
									Items [i].GetComponent<itemslotinformation> ().Name = id.itemslots[i];

								
								}
							}
							ItemMode2 ();

						}
						if (selectedOption == 2) {
							if (realslots.Count > 1) {
								for (int i = 0; i < realslots.Count - 1; i++) {
									Items [i].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [i];
									Items [i].GetComponent<itemslotinformation> ().isKeyItem  = id.PCKeyItem [i];
									Items [i].GetComponent<itemslotinformation> ().Name = id.PCslots[i];


								}
							}
							ItemMode3 ();

						}
						if (selectedOption == 3) {
                            play.overrideRenable = false;
							mylog.Deactivate ();
							mylog.finishedWithTextOverall = true;
							play.PCactive = false;
							play.WaitToInteract ();
							this.gameObject.SetActive (false);

						}

					}
					StartCoroutine (Wait ());
				}
				if (currentMenu == quantitymenu) {
					if (donewaiting) {
						if (ItemMode == 3) {
							if (!Items [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem) {
								StartCoroutine (TossItem ());
							}
						}
						if (ItemMode == 1) {

							StartCoroutine (WithdrawItem ());


						}
				
						if (ItemMode == 2) {
							StartCoroutine (DepositItem ());

						}




					}
					StartCoroutine (Wait ());
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			if (currentMenu == mainwindow) {
                play.overrideRenable = false;
				mylog.Deactivate ();
				play.PCactive = false;
				mylog.finishedWithTextOverall = true;
				play.WaitToInteract ();
				this.gameObject.SetActive (false);

			}
			if (currentMenu == itemwindow) {
				didFirstRunthrough = false;
				mylog.Deactivate ();
				mylog.cantscroll = true;
				mylog.text ("What do you want to do?");
				currentMenu = mainwindow;

			}
						if(currentMenu == quantitymenu){
							if (ItemMode == 1) {
								currentBagPosition = 0;
								selectBag = -1;
								mylog.Deactivate ();
								mylog.cantscroll = true;
								mylog.text ("What do you want to withdraw?");
								currentMenu = itemwindow;

							}
							if (ItemMode == 2) {
								currentBagPosition = 0;
								selectBag = -1;
								mylog.Deactivate ();
								mylog.cantscroll = true;
								mylog.text ("What do you want to deposit?");
								currentMenu = itemwindow;

							}
							if (ItemMode == 3) {
								currentBagPosition = 0;
								selectBag = -1;
								mylog.Deactivate ();
								mylog.cantscroll = true;
								mylog.text ("What do you want to toss?");
								currentMenu = itemwindow;

							}
						}

		}
		foreach (GameObject menu in allMenus) {
			if (menu != currentMenu) {
				menu.SetActive (false);
			} else {

				menu.SetActive (true);
			}
			if (menu == mainwindow && (currentMenu == itemwindow || currentMenu == quantitymenu)) {


				menu.SetActive (true);
			}
			if(menu == quantitymenu && (currentMenu == itemwindow || currentMenu == mainwindow)){
				menu.SetActive(false);

			}
			if(menu == itemwindow  && currentMenu == quantitymenu){
				menu.SetActive(true);

			}

		}

	}
	IEnumerator WithdrawItem(){
		
		alreadyInBag = false;
		mylog.Deactivate ();
		mylog.cantscroll = false;
		mylog.finishedCurrentTask = true;

		string DisplayString = "Withdrew "  + " " + realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name + ".".ToString ();
		mylog.cont (DisplayString);
		while (!mylog.finishedCurrentTask) {
			yield return new WaitForSeconds (0.1f);
			if (mylog.finishedCurrentTask) {
				break;

			}
		}
			
		mylog.finishedWithTextOverall = true;
		for (int i = 0; i < realslots.Count; i++) {
			if (i == 0) {
				fakerealslots.Clear ();
				for (int m = 0; m < realslots.Count; m++) {
					fakerealslots.Add (realslots [m]);
				}
				fakerealslots.Resize (fakerealslots.Count - 1);
			}
			if (id.itemslots [i] == realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name) {
				
				int keep = i;

				alreadyInBag = true;

				id.quantity [keep] += amountToTask;
			
				for (int s = 0; s < 20; s++) {
					if (s == 0) {
						wactualslots = 0;
					}
					if (id.itemslots [s] != "null") {
						wactualslots++; 
						fakerealslots.Resize (wactualslots + 1);
						Items [s].SetActive (true);
						Items [s].GetComponent<itemslotinformation> ().Name = id.itemslots [s]; 
						Items [i].GetComponent<itemslotinformation> ().isKeyItem = id.KeyItem [i]; 
						fakerealslots [wactualslots - 1] = Items [s];
					} else {
						Items [s].SetActive (false);


					}
					if (s == 19) {
						wactualslots++;
						fakerealslots.Resize (wactualslots);
						fakerealslots [wactualslots - 1] = cancel;

						actualslots = wactualslots;
					}
				}

				for (int k = 0; k < 20; k++) {
					if (id.itemslots [k] != "null") {
						Items [k].GetComponent<itemslotinformation> ().intquantity = id.quantity [k]; 

					}

				}
			}
		}
		if (!alreadyInBag) {
			string nametoadd;
			int amounttoadd;
			bool thekey;
			nametoadd = id.PCslots [currentBagPosition];
			amounttoadd = amountToTask;
			thekey = id.PCKeyItem [currentBagPosition];
			for (int s = 0; s < 20; s++) {
				if (s == 0) {
					wactualslots = 0;
				}
				if (id.itemslots [s] != "null") {
					wactualslots++; 
					realslots.Resize (wactualslots + 1);
					Items [s].SetActive (true);
					Items [s].GetComponent<itemslotinformation> ().Name = id.itemslots [s]; 
					Items [s].GetComponent<itemslotinformation> ().isKeyItem = id.KeyItem [s]; 
					realslots [wactualslots - 1] = Items [s];
				} else {
					Items [s].SetActive (false);


				}
				if (s == 19) {
					wactualslots++;
					realslots.Resize (wactualslots);
					realslots [wactualslots - 1] = cancel;

					actualslots = wactualslots;
				}
			}

			for (int k = 0; k < 20; k++) {
				if (id.itemslots [k] != "null") {
					Items [k].GetComponent<itemslotinformation> ().intquantity = id.quantity [k]; 

				}

			}
		
					fakerealslots.Clear ();
					for (int m = 0; m < realslots.Count; m++) {
						fakerealslots.Add (realslots [m]);
					}

					
			id.itemslots [fakerealslots.Count - 1] = nametoadd;
			id.quantity [fakerealslots.Count - 1] = amounttoadd;
			id.KeyItem [fakerealslots.Count - 1] = thekey;
			fakerealslots [fakerealslots.Count - 1] = Items [fakerealslots.Count - 1];
			fakerealslots.Resize (fakerealslots.Count + 1);


		
		for (int s = 0; s < 20; s++) {
			if (s == 0) {
				wactualslots = 0;
			}
			if (id.itemslots [s] != "null") {
				wactualslots++; 
				fakerealslots.Resize (wactualslots + 1);
				Items [s].SetActive (true);
				Items [s].GetComponent<itemslotinformation> ().Name = id.itemslots [s]; 
					Items [s].GetComponent<itemslotinformation> ().isKeyItem = id.KeyItem [s]; 
				fakerealslots [wactualslots - 1] = Items [s];
			} else {
				Items [s].SetActive (false);


			}
			if (s == 19) {
				wactualslots++;
				fakerealslots.Resize (wactualslots);
				fakerealslots [wactualslots - 1] = cancel;

				actualslots = wactualslots;
			}
		}

		for (int k = 0; k < 20; k++) {
			if (id.itemslots [k] != "null") {
				Items [k].GetComponent<itemslotinformation> ().intquantity = id.quantity [k]; 

			}

		}

	}
		if (alreadyInBag) {
			fakerealslots.Resize (fakerealslots.Count + 1);
		}
	
		for (int i = 0; i < 20; i++) {
			if (i == 0) {
				wactualslots = 0;
			}
			if (id.itemslots [i] != "null") {
				wactualslots++; 
				fakerealslots.Resize(wactualslots + 1);
				Items [i].SetActive (true);
				Items [i].GetComponent<itemslotinformation> ().Name = id.itemslots [i]; 
				Items [i].GetComponent<itemslotinformation> ().isKeyItem = id.KeyItem [i]; 
				fakerealslots [wactualslots - 1] = Items [i];
			} else {
				Items [i].SetActive (false);


			}
			if (i == 19) {
				wactualslots++;
				fakerealslots.Resize(wactualslots);
				fakerealslots [wactualslots - 1] = cancel;

				actualslots = wactualslots;
			}
		}

		for (int i = 0; i < 20; i++) {
			if (id.itemslots [i] != "null") {
				Items [i].GetComponent<itemslotinformation> ().intquantity = id.quantity [i]; 

			}

		}
		if (!alreadyInBag) {
			realslots.Resize (realslots.Count + 1);
		}
		realslots [realslots.Count - 1] = cancel;
		for (int l = 0; l < fakerealslots.Count; l++) {
			if (fakerealslots.Count > 1) {
				realslots [l] = fakerealslots [l];

			}

		}

		//id.PCquantity 


		for (int i = 0; i < 20; i++) {
			if (i == 0) {
				wactualslots = 0;
			}
			if (id.PCslots [i] != "null") {
				wactualslots++; 
				realslots.Resize(wactualslots + 1);
				Items [i].SetActive (true);
				Items [i].GetComponent<itemslotinformation> ().Name = id.PCslots [i]; 
				Items [i].GetComponent<itemslotinformation> ().isKeyItem = id.PCKeyItem [i]; 
				realslots [wactualslots - 1] = Items [i];
			} else {
				Items [i].SetActive (false);


			}
			if (i == 19) {
				wactualslots++;
				realslots.Resize(wactualslots);
				realslots [wactualslots - 1] = cancel;

				actualslots = wactualslots;
			}
		}

		for (int i = 0; i < 20; i++) {
			if (id.PCslots [i] != "null") {
				Items [i].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [i]; 

			}

		}
		StartCoroutine(RemoveItem(amountToTask));


				mylog.cantscroll = true;
				mylog.text ("What do you want to do?");
		ItemMode = 0;
		currentMenu = mainwindow;
				


				
		}

	//deposit
	IEnumerator DepositItem(){

		alreadyInBag = false;
		mylog.Deactivate ();
		mylog.cantscroll = false;
		mylog.finishedCurrentTask = true;

		string DisplayString =  realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name + " was stored via PC" +  ".".ToString ();
		mylog.cont (DisplayString);
		while (!mylog.finishedCurrentTask) {
			yield return new WaitForSeconds (0.1f);
			if (mylog.finishedCurrentTask) {
				break;

			}
		}

		mylog.finishedWithTextOverall = true;
		for (int i = 0; i < realslots.Count; i++) {
			if (i == 0) {
				fakerealslots.Clear ();
				for (int m = 0; m < realslots.Count; m++) {
					fakerealslots.Add (realslots [m]);
				}
				fakerealslots.Resize (fakerealslots.Count - 1);
			}
			if (id.PCslots [i] == realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name) {

				int keep = i;

				alreadyInBag = true;

				id.PCquantity [keep] += amountToTask;

				for (int s = 0; s < 20; s++) {
					if (s == 0) {
						wactualslots = 0;
					}
					if (id.PCslots [s] != "null") {
						wactualslots++; 
						fakerealslots.Resize (wactualslots + 1);
						Items [s].SetActive (true);
						Items [s].GetComponent<itemslotinformation> ().Name = id.PCslots [s]; 
						Items [s].GetComponent<itemslotinformation> ().isKeyItem = id.PCKeyItem [s]; 

						fakerealslots [wactualslots - 1] = Items [s];
					} else {
						Items [s].SetActive (false);


					}
					if (s == 19) {
						wactualslots++;
						fakerealslots.Resize (wactualslots);
						fakerealslots [wactualslots - 1] = cancel;

						actualslots = wactualslots;
					}
				}

				for (int k = 0; k < 20; k++) {
					if (id.PCslots [k] != "null") {
						Items [k].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [k]; 

					}

				}
			}
		}
		if (!alreadyInBag) {
			string nametoadd;
			int amounttoadd;
			bool keyitemornot;
			nametoadd = id.itemslots [currentBagPosition];
			amounttoadd = amountToTask;
			keyitemornot = id.KeyItem [currentBagPosition];
			for (int s = 0; s < 20; s++) {
				if (s == 0) {
					wactualslots = 0;
				}
				if (id.PCslots [s] != "null") {
					wactualslots++; 
					realslots.Resize (wactualslots + 1);
					Items [s].SetActive (true);
					Items [s].GetComponent<itemslotinformation> ().Name = id.PCslots [s]; 
					Items [s].GetComponent<itemslotinformation> ().isKeyItem = id.PCKeyItem [s]; 
					realslots [wactualslots - 1] = Items [s];
				} else {
					Items [s].SetActive (false);


				}
				if (s == 19) {
					wactualslots++;
					realslots.Resize (wactualslots);
					realslots [wactualslots - 1] = cancel;

					actualslots = wactualslots;
				}
			}

			for (int k = 0; k < 20; k++) {
				if (id.PCslots [k] != "null") {
					Items [k].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [k]; 

				}

			}

			fakerealslots.Clear ();
			for (int m = 0; m < realslots.Count; m++) {
				fakerealslots.Add (realslots [m]);
			}


			id.PCslots [fakerealslots.Count - 1] = nametoadd;
			id.PCquantity [fakerealslots.Count - 1] = amounttoadd;
			id.PCKeyItem [fakerealslots.Count - 1] = keyitemornot;
			fakerealslots [fakerealslots.Count - 1] = Items [fakerealslots.Count - 1];
			fakerealslots.Resize (fakerealslots.Count + 1);

		


			for (int s = 0; s < 20; s++) {
				if (s == 0) {
					wactualslots = 0;
				}
				if (id.PCslots [s] != "null") {
					wactualslots++; 
					fakerealslots.Resize (wactualslots + 1);
					Items [s].SetActive (true);
					Items [s].GetComponent<itemslotinformation> ().Name = id.PCslots [s]; 
					Items [s].GetComponent<itemslotinformation> ().isKeyItem = id.PCKeyItem [s]; 
					fakerealslots [wactualslots - 1] = Items [s];
				} else {
					Items [s].SetActive (false);


				}
				if (s == 19) {
					wactualslots++;
					fakerealslots.Resize (wactualslots);
					fakerealslots [wactualslots - 1] = cancel;

					actualslots = wactualslots;
				}
			}

			for (int k = 0; k < 20; k++) {
				if (id.PCslots [k] != "null") {
					Items [k].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [k]; 

				}

			}

		}
		if (alreadyInBag) {
			fakerealslots.Resize (fakerealslots.Count + 1);
		}

		for (int i = 0; i < 20; i++) {
			if (i == 0) {
				wactualslots = 0;
			}
			if (id.PCslots [i] != "null") {
				wactualslots++; 
				fakerealslots.Resize(wactualslots + 1);
				Items [i].SetActive (true);
				Items [i].GetComponent<itemslotinformation> ().Name = id.PCslots [i]; 
				Items [i].GetComponent<itemslotinformation> ().isKeyItem = id.PCKeyItem [i]; 
				fakerealslots [wactualslots - 1] = Items [i];
			} else {
				Items [i].SetActive (false);


			}
			if (i == 19) {
				wactualslots++;
				fakerealslots.Resize(wactualslots);
				fakerealslots [wactualslots - 1] = cancel;

				actualslots = wactualslots;
			}
		}

		for (int i = 0; i < 20; i++) {
			if (id.PCslots [i] != "null") {
				Items [i].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [i]; 

			}

		}
		if (!alreadyInBag) {
			realslots.Resize (realslots.Count + 1);
		}
		realslots [realslots.Count - 1] = cancel;
		for (int l = 0; l < fakerealslots.Count; l++) {
			if (fakerealslots.Count > 1) {
				realslots [l] = fakerealslots [l];

			}

		}

		//id.PCquantity 


		for (int i = 0; i < 20; i++) {
			if (i == 0) {
				wactualslots = 0;
			}
			if (id.itemslots [i] != "null") {
				wactualslots++; 
				realslots.Resize(wactualslots + 1);
				Items [i].SetActive (true);
				Items [i].GetComponent<itemslotinformation> ().Name = id.itemslots [i]; 
				Items [i].GetComponent<itemslotinformation> ().isKeyItem = id.KeyItem [i]; 
				realslots [wactualslots - 1] = Items [i];
			} else {
				Items [i].SetActive (false);


			}
			if (i == 19) {
				wactualslots++;
				realslots.Resize(wactualslots);
				realslots [wactualslots - 1] = cancel;

				actualslots = wactualslots;
			}
		}
	
		for (int i = 0; i < 20; i++) {
			if (id.itemslots [i] != "null") {
				Items [i].GetComponent<itemslotinformation> ().intquantity = id.quantity [i]; 

			}

		}
		StartCoroutine(RemoveItem(amountToTask));


		mylog.cantscroll = true;
		mylog.text ("What do you want to do?");
		ItemMode = 0;
		currentMenu = mainwindow;




	}
	IEnumerator TossItem(){

		 
		mylog.Deactivate ();
		mylog.cantscroll = false;
		mylog.finishedCurrentTask = true;
		string DisplayString = "Tossed " + amountToTask + " " + realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name + ".".ToString ();
		mylog.cont (DisplayString);
		while (!mylog.finishedCurrentTask) {
			yield return new WaitForSeconds (0.1f);
			if (mylog.finishedCurrentTask) {
				break;

			}
		}
		mylog.done ();
		StartCoroutine(RemoveItem (amountToTask));
	
		mylog.cantscroll = true;
		mylog.text ("What do you want to do?");
		currentMenu = mainwindow;
		ItemMode = 0;
	}
	IEnumerator Wait(){
		donewaiting = false;
		yield return new WaitForSeconds (0.1f);
		donewaiting = true;
	}
	public IEnumerator ShiftBagLeft ()
	{

		if (ItemMode == 1 || ItemMode == 3) {
			didFirstRunthrough = false;
			for (int i = currentBagPosition; i < realslots.Count; i++) {
				if (i == currentBagPosition) {
					fakerealslots.Clear ();
					for (int m = 0; m < realslots.Count; m++) {
						fakerealslots.Add (realslots [m]);
					}
					fakerealslots.Resize (fakerealslots.Count - 1);
					last = fakerealslots [fakerealslots.Count - 1];

				}
				if (i < fakerealslots.Count - 1) {


					fakerealslots [i] = fakerealslots [i + 1];


				} else {
					yield return null;


				}


			}
			if (fakerealslots.Count > 1) {
				fakerealslots [fakerealslots.Count - 1] = last;
			}
			fakerealslots.Resize (fakerealslots.Count - 1);
			realslots.Resize (realslots.Count - 1);

			realslots [realslots.Count - 1] = cancel;
			for (int l = 0; l < fakerealslots.Count; l++) {
				realslots [l] = fakerealslots [l];



			}




			for (int i = 0; i < 20; i++) {

				if (i < realslots.Count - 1) {
					id.lc.Items [i].GetComponent<itemslotinformation> ().Name = realslots [i].GetComponent<itemslotinformation> ().Name;
				}
				if (i == realslots.Count - 1) {
					id.lc.Items [i].GetComponent<itemslotinformation> ().Name = "null";

				}
				id.PCslots [i] = id.lc.Items [i].GetComponent<itemslotinformation> ().Name;
			}

			for (int i = 0; i < 20; i++) {

				if (i < realslots.Count - 1) {
					id.lc.Items [i].GetComponent<itemslotinformation> ().intquantity = realslots [i].GetComponent<itemslotinformation> ().intquantity;
					id.lc.Items [i].GetComponent<itemslotinformation> ().isKeyItem = realslots [i].GetComponent<itemslotinformation> ().isKeyItem;
				}
				id.PCquantity [i] = id.lc.Items [i].GetComponent<itemslotinformation> ().intquantity;
				id.PCKeyItem [i] = Items [i].GetComponent<itemslotinformation> ().isKeyItem;



			}

		} else {
			didFirstRunthrough = false;
			for (int i = currentBagPosition; i < realslots.Count; i++) {
				if (i == currentBagPosition) {
					fakerealslots.Clear ();
					for (int m = 0; m < realslots.Count; m++) {
						fakerealslots.Add (realslots [m]);
					}
					fakerealslots.Resize (fakerealslots.Count - 1);
					last = fakerealslots [fakerealslots.Count - 1];

				}
				if (i < fakerealslots.Count - 1) {


					fakerealslots [i] = fakerealslots [i + 1];


				} else {
					yield return null;


				}


			}

			if (fakerealslots.Count > 1) {
				fakerealslots [fakerealslots.Count - 1] = last;
			}
			fakerealslots.Resize (fakerealslots.Count - 1);
			realslots.Resize (realslots.Count - 1);

			realslots [realslots.Count - 1] = cancel;
			for (int l = 0; l < fakerealslots.Count; l++) {
				realslots [l] = fakerealslots [l];



			}




			for (int i = 0; i < 20; i++) {

				if (i < realslots.Count - 1) {
					Items [i].GetComponent<itemslotinformation> ().Name = realslots [i].GetComponent<itemslotinformation> ().Name;
				}
				if (i == realslots.Count - 1) {
					Items [i].GetComponent<itemslotinformation> ().Name = "null";

				}
				id.itemslots [i] = id.lc.Items [i].GetComponent<itemslotinformation> ().Name;
			}

			for (int i = 0; i < 20; i++) {

				if (i < realslots.Count - 1) {
					Items [i].GetComponent<itemslotinformation> ().intquantity = realslots [i].GetComponent<itemslotinformation> ().intquantity;
					Items [i].GetComponent<itemslotinformation> ().isKeyItem  = realslots [i].GetComponent<itemslotinformation> ().isKeyItem;
				}
				id.quantity [i] = Items [i].GetComponent<itemslotinformation> ().intquantity;
				id.KeyItem [i] = Items [i].GetComponent<itemslotinformation> ().isKeyItem;




			}



		}

	}



	public IEnumerator RemoveItem(int amount){
		if (ItemMode == 1 || ItemMode == 3) {
			id.PCquantity [currentBagPosition] -= amount;

			realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity = id.PCquantity [currentBagPosition];
			realslots [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem  = id.PCKeyItem [currentBagPosition];
		}
		if (ItemMode == 2) {
			id.quantity [currentBagPosition] -= amount;

			realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity = id.quantity [currentBagPosition];
			realslots [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem  = id.KeyItem [currentBagPosition];
		}
			if (realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity == 0) {
			StartCoroutine (ShiftBagLeft ());
			

		}
		yield return null;
	}
	void ItemMode1(){
		currentBagPosition = 0;
		ItemMode = 1;
		selectBag = -1;
		mylog.Deactivate ();
		mylog.cantscroll = true;
		mylog.text ("What do you want to withdraw?");
		currentMenu = itemwindow;
	}
	void ItemMode2(){
		currentBagPosition = 0;
		ItemMode = 2;
		selectBag = -1;
		mylog.Deactivate ();
		mylog.cantscroll = true;
		mylog.text ("What do you want to deposit?");
		currentMenu = itemwindow;

	}
	void ItemMode3(){
		currentBagPosition = 0;
		ItemMode = 3;
		selectBag = -1;
		mylog.Deactivate ();
		mylog.cantscroll = true;
		mylog.text ("What do you want to toss?");
		currentMenu = itemwindow;

	}
		IEnumerator TooImportantToToss(){

			mylog.Deactivate();
		mylog.cantscroll = false;
		mylog.finishedCurrentTask  = true;
			mylog.text ("That's too important to toss!");

		
		while (!mylog.finishedCurrentTask) {
			yield return new WaitForSeconds (0.1f);
			if (mylog.finishedCurrentTask) {
				break;

			}
		}
	
		currentMenu = itemwindow;
	}
}
