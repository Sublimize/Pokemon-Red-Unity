using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class pokemart : MonoBehaviour {
	public GameObject currentMenu;
	public GameObject cursor;
	public GameObject buysellwindow, martwindow, itemwindow,   quantitymenu;
	public GameObject[] menuSlots, itemSelectSlots;
	public Dialogue mylog;
	public Player play;
	public int selectedOption;
	public GameObject[] allMenus;
	public int ItemMode;
	public int ItemPrice;
	public int fullPrice;
	//1 is withdraw;
	//2 is deposit;
	//3 is toss;
	public List<GameObject> Items = new List<GameObject>(21);
	public List<GameObject> ItemsToBuy = new List<GameObject>(10);
	public itemdatabase id;
	public int currentBagPosition;
	public GameObject cancel, buycancel;
	public int actualslots, wactualslots;
	public int buyactualslots, buywactualslots;
	public int MartID;
	public List<GameObject> realslots;
	public List<GameObject> fakerealslots;
	public List<string> martlist;
	public List<GameObject> buyrealslots;
	public List<GameObject> buyfakerealslots;
	public int selectBag;
	public int amountToTask;
	public bool didFirstRunthrough;
	public int maximumItem;
	public TextMeshProUGUI amountText, moneytext, pricetext;
	public bool donewaiting;
	public GameObject last;
	public bool alreadyInBag;
	public bool alreadydidtext;
	public int keep;


	public bool withdrawing;


	void Start() {


	}








	// Update is called once per frame
	void Update () {
		pricetext.text = fullPrice.ToString ();
		moneytext.text = play.money.ToString ();
		amountText.text = amountToTask.ToString ();
		if (currentMenu == quantitymenu) {
			if (ItemMode == 1) {


				ItemPrice = buyrealslots [currentBagPosition].GetComponent<shopitemslotinfo> ().intPrice;
				maximumItem = 99;
			}
			if (ItemMode == 2) {

				if (realslots [currentBagPosition].GetComponent<itemslotinformation> ().Name == "POTION") {

					ItemPrice = 100;
				}
				maximumItem = realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity;

			}
			fullPrice = amountToTask * ItemPrice;
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
		if (currentMenu == martwindow) {

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				currentBagPosition++;

			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				currentBagPosition--;

			}
			if (currentBagPosition < 0) {
				currentBagPosition = buyrealslots.Count - 1;


			}
			if (currentBagPosition ==  buyrealslots.Count) {
				currentBagPosition = 0;


			}



			for (int i = 0; i < 9; i++) {
				if (i == 0) {
					buywactualslots = 0;
				}

				if (i < martlist.Count) {
					ItemsToBuy [i].SetActive (true);
					buywactualslots++; 
					buyrealslots.Resize (buywactualslots + 1);
					ItemsToBuy [i].GetComponent<shopitemslotinfo> ().Name = martlist [i]; 

					buyrealslots [buywactualslots - 1] = ItemsToBuy [i];

				}
				if(i > martlist.Count - 1){
					ItemsToBuy [i].SetActive (false);


				}
				if (i == 8) {
					buywactualslots++;
					buyrealslots.Resize (buywactualslots);
					buyrealslots [buywactualslots - 1] = buycancel;
					buyactualslots = buywactualslots;
				}
			}






			didFirstRunthrough = true;
			itemSelectSlots = new GameObject[buyrealslots.Count];

			for (int i = 0; i < buyrealslots.Count; i++) {

				itemSelectSlots [i] = buyrealslots [i].transform.GetChild (0).gameObject;
			}
			cursor.SetActive (true);
			cursor.transform.position = itemSelectSlots [currentBagPosition].transform.position;
		


		}
		if (currentMenu == itemwindow) {

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				currentBagPosition++;

			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				currentBagPosition--;

			}
			if (currentBagPosition < 0) {
				currentBagPosition = realslots.Count - 1;


			}
			if (currentBagPosition == realslots.Count) {
				currentBagPosition = 0;


			}



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





			didFirstRunthrough = true;
			itemSelectSlots = new GameObject[realslots.Count];

			for (int i = 0; i < realslots.Count; i++) {

				itemSelectSlots [i] = realslots [i].transform.GetChild (0).gameObject;
			}


			if (currentBagPosition != realslots.Count - 1) {
				maximumItem = realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity;
			} else {
				maximumItem = 0;

			}
			cursor.transform.position = itemSelectSlots [currentBagPosition].transform.position;
			cursor.SetActive (true);

		}
		if (currentMenu == null && (currentMenu != quantitymenu || currentMenu != itemwindow)) {

		} else {
			menuSlots = new GameObject[currentMenu.transform.childCount];

			for (int i = 0; i < currentMenu.transform.childCount; i++) {


				menuSlots [i] = currentMenu.transform.GetChild (i).gameObject;
			}
			if (currentMenu == buysellwindow) {

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

		}
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			if (currentMenu == itemwindow) {
				if (selectBag == -1) {
					selectBag = currentBagPosition;
				} else {
					//our bag

					string selectName = id.itemslots [selectBag];
					int selectquantity = id.quantity [selectBag];
					bool thatkey = id.KeyItem [selectBag];
					id.itemslots [selectBag] = id.itemslots [currentBagPosition];
					id.quantity [selectBag] = id.quantity [currentBagPosition];
					id.KeyItem [selectBag] = id.KeyItem [currentBagPosition];
					id.itemslots [currentBagPosition] = selectName;
					id.quantity [currentBagPosition] = selectquantity;
					id.KeyItem [currentBagPosition] = thatkey;
					selectBag = -1;




				}
			}

		}
		if (mylog.finishedWithTextOverall) {

			if (Input.GetKeyDown (KeyCode.Z)) {
				
					if (currentMenu == buysellwindow) {
					
						if (selectedOption == 0) {
							currentMenu = martwindow;

						}
						if (selectedOption == 1) {
							currentMenu = itemwindow;
						currentBagPosition = 0;

						}
					if (selectedOption == 2) {
							play.shopup = false;
						this.gameObject.SetActive (false);



					}
				
					StartCoroutine (Wait ());


					
				}
				if (currentMenu == martwindow) {
					if (donewaiting) {
						if (currentBagPosition == buyrealslots.Count - 1) {


							currentMenu = buysellwindow;



						} else {



							currentMenu = quantitymenu;


							ItemMode1 ();

						}
						StartCoroutine (Wait ());
					}
				
				}
				if (currentMenu == itemwindow) {
					if (donewaiting) {
						if (currentBagPosition == realslots.Count - 1) {


							currentMenu = buysellwindow;



						} else {
							


							currentMenu = quantitymenu;


							ItemMode2 ();

						}
						StartCoroutine (Wait ());
					}

				}


				if (currentMenu == quantitymenu) {
					if (donewaiting) {


						if (ItemMode == 2) {
							if (!Items [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem) {
								play.money += fullPrice;
								StartCoroutine (TossItem ());
							} else {
								StartCoroutine (TooImportantToToss ());


							}
						}

						if (ItemMode == 1) {
							if (play.money >= fullPrice) {
								play.money -= fullPrice;
								StartCoroutine(AddItem (buyrealslots [currentBagPosition].GetComponent<shopitemslotinfo> ().Name, amountToTask));
							} else {

								StartCoroutine(NotEnoughMoney());

							}

						}
						}
						StartCoroutine (Wait ());
					}

				}
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				if (currentMenu == martwindow) {


				currentMenu = buysellwindow;

				}
				if (currentMenu == itemwindow) {
					didFirstRunthrough = false;
					currentMenu = buysellwindow;

				}
			if (currentMenu == quantitymenu) {

				if (ItemMode == 1) {
					currentBagPosition = 0;
					selectBag = -1;
					currentMenu = martwindow;

				
			}
				if (ItemMode == 2) {
					currentBagPosition = 0;
					selectBag = -1;
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
			if(menu == martwindow  &&( currentMenu ==  quantitymenu && ItemMode == 1)){
				menu.SetActive (true);
			}
				if(menu == itemwindow &&( currentMenu ==  quantitymenu && ItemMode == 2)){
					menu.SetActive (true);
				}

				if(menu == quantitymenu && (currentMenu == itemwindow || currentMenu == martwindow)){
					menu.SetActive(false);

				}
				if(menu == buysellwindow  && (currentMenu == quantitymenu || currentMenu == itemwindow || currentMenu == martwindow)){
					menu.SetActive(true);

				}

			}
		}



	public IEnumerator AddItem(string name, int quantity){

		alreadyInBag = false;

		for (int i = 0; i < 20; i++) {
			if (i == 0) {
				fakerealslots.Clear ();
				for (int m = 0; m < realslots.Count; m++) {
					fakerealslots.Add (realslots [m]);
				}
				fakerealslots.Resize (fakerealslots.Count - 1);
			}
			if (id.itemslots[i] == name) {

				keep = i;
				alreadyInBag = true;
				yield return null;
			}
		}

		if (alreadyInBag) {
			id.quantity [keep] += quantity;

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
		if (!alreadyInBag) {
			string nametoadd;
			int amounttoadd;
			nametoadd = name;
			amounttoadd = quantity;

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
			print (fakerealslots.Count.ToString ());

			id.itemslots [fakerealslots.Count - 1] = nametoadd;
			id.quantity [fakerealslots.Count - 1] = amounttoadd;
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



		ItemMode = 0;
		currentMenu = martwindow;




	}

	//deposit

	public IEnumerator TossItem(){

		print (currentBagPosition.ToString ());

		mylog.Deactivate ();
		mylog.cantscroll = false;
		mylog.finishedCurrentTask = true;

		string DisplayString = "Tossed " + amountToTask + " " + id.itemslots [currentBagPosition] + ".".ToString ();
		mylog.cont (DisplayString);
		while (!mylog.finishedCurrentTask) {
			yield return new WaitForSeconds (0.1f);
			if (mylog.finishedCurrentTask) {
				break;

			}
		}
		mylog.done ();
		StartCoroutine(RemoveItem (amountToTask));

		currentMenu = itemwindow;
		ItemMode = 0;
	}
	IEnumerator Wait(){
		donewaiting = false;
		yield return new WaitForSeconds (0.1f);
		donewaiting = true;
	}
	public IEnumerator ShiftBagLeft ()
	{

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
			if (i  < fakerealslots.Count - 1) {


				fakerealslots [i] = fakerealslots [i + 1];


			} else {
				yield return null;


			}


		}	

		fakerealslots [fakerealslots.Count - 1] = last;



		if(realslots.Count > 1){
			realslots [realslots.Count - 1] = cancel;
		}
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
			id.itemslots [i] = id.lc.Items [i].GetComponent<itemslotinformation> ().Name;
		}

		for (int i = 0; i < 20; i++) {

			if (i < realslots.Count - 1) {
				id.lc.Items [i].GetComponent<itemslotinformation> ().intquantity = realslots [i].GetComponent<itemslotinformation> ().intquantity;
				id.lc.Items [i].GetComponent<itemslotinformation> ().isKeyItem  = realslots [i].GetComponent<itemslotinformation> ().isKeyItem ;

			}
			id.quantity [i] = id.lc.Items [i].GetComponent<itemslotinformation> ().intquantity;
			id.KeyItem  [i] = id.lc.Items [i].GetComponent<itemslotinformation> ().isKeyItem ;



		}
	}

	public IEnumerator RemoveItem(int amount){

		id.quantity [currentBagPosition] -= amount;

		realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity = id.quantity [currentBagPosition];
		realslots [currentBagPosition].GetComponent<itemslotinformation> ().isKeyItem  = id.KeyItem [currentBagPosition];
		if (realslots [currentBagPosition].GetComponent<itemslotinformation> ().intquantity == 0) {
			StartCoroutine (ShiftBagLeft ());


		}
		yield return null;
	}
	void ItemMode1(){
		ItemMode = 1;
		selectBag = -1;
	}
	void ItemMode2(){
		ItemMode = 2;
		selectBag = -1;

	}
	IEnumerator TooImportantToToss(){

		mylog.Deactivate();
		yield return StartCoroutine(mylog.text ("That's too important to toss!"));
		yield return StartCoroutine(mylog.done ());
		currentMenu = itemwindow;
	}
	IEnumerator NotEnoughMoney(){

		mylog.Deactivate();
		yield return StartCoroutine(mylog.text ("You don't have enough money."));
		yield return StartCoroutine(mylog.done ());
		currentMenu = martwindow;
	}
}
