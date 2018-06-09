using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdatabase : MonoBehaviour {
	//both share the same index;
	//for items
	public List<string> itemslots =  new List<string>(20);
	public List<int> quantity =  new List<int>(20);
	public List<bool> KeyItem = new List<bool> (20);
	//for PC
	public List<string> PCslots =  new List<string>(50);
	public List<int> PCquantity =  new List<int>(50);
	public List<bool> PCKeyItem = new List<bool> (50);
	public pc lc;
	public List<string> ViridianItems = new List<string> (5);
	public List<string> PewterItems = new List<string> (7);
	public List<string> CeruleanItems = new List<string> (8);
	public List<string> VermilionItems = new List<string> (6);
	public List<string> LavenderItems = new List<string> (9);
	public List<string> SaffronItems = new List<string> (6);
	public List<string> FuchsiaItems = new List<string> (7);
	public List<string> CinnabarItems = new List<string> (7);
	public List<string> IndigoItems = new List<string> (7);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ViridianItems [0] = "POKE BALL";
		ViridianItems [1] = "POTION";
		ViridianItems [2] = "ANTIDOTE";
		ViridianItems [3] = "PARLYZ HEAL";
		ViridianItems [4] = "BURN HEAL";


		PewterItems [0] = "POKE BALL";
		PewterItems [1] = "POTION";
		PewterItems [2] = "ESCAPE ROPE";
		PewterItems [3] = "ANTIDOTE";
		PewterItems [4] = "BURN HEAL";
		PewterItems [5] = "AWAKENING";
		PewterItems [6] = "PARLYZ HEAL";


		CeruleanItems [0] = "POKE BALL";
		CeruleanItems [1] = "POTION";
		CeruleanItems  [2] = "ESCAPE ROPE";
		CeruleanItems [3] = "REPEL";
		CeruleanItems [4] = "ANTIDOTE";
		CeruleanItems [5] = "BURN HEAL";
		CeruleanItems [6] = "AWAKENING";
		CeruleanItems [7] = "PARLYZ HEAL";




		VermilionItems [0] = "POKE BALL";
		VermilionItems [1] = "SUPER POTION";
		VermilionItems  [2] = "ICE HEAL";
		VermilionItems [3] = "AWAKENING";
		VermilionItems [4] = "PARLYZ HEAL";
		VermilionItems [5] = "REPEL";


		LavenderItems [0] = "GREAT BALL";
		LavenderItems [1] = "SUPER POTION";
		LavenderItems [2] = "REVIVE";
		LavenderItems  [3] = "ESCAPE ROPE";
		LavenderItems [4] = "SUPER REPEL";
		LavenderItems [5] = "ANTIDOTE";
		LavenderItems [6] = "BURN HEAL";
		LavenderItems [7] = "ICE HEAL";
		LavenderItems [8] = "PARLYZ HEAL";


		SaffronItems [0] = "GREAT BALL";
		SaffronItems[1] = "HYPER  POTION";
		SaffronItems[2] = "MAX REPEL";
		SaffronItems[3] = "ESCAPE ROPE";
		SaffronItems[4] = "FULL HEAL";
		SaffronItems[5] = "REVIVE";



		FuchsiaItems [0] = "ULTRA BALL";
		FuchsiaItems [1] = "GREAT BALL";
		FuchsiaItems [2] = "SUPER POTION";
		FuchsiaItems [3] = "HYPER POTION";
		FuchsiaItems [4] = "REVIVE";
		FuchsiaItems [5] = "FULL HEAL";
		FuchsiaItems [6] = "SUPER REPEL";



		CinnabarItems [0] = "ULTRA BALL";
		CinnabarItems [1] = "GREAT BALL";
		CinnabarItems [2] = "HYPER POTION";
		CinnabarItems [3] = "MAX REPEL";
		CinnabarItems [4] = "ESCAPE ROPE";
		CinnabarItems [5] = "FULL HEAL";
		CinnabarItems [6] = "REVIVE";


		IndigoItems [0] = "ULTRA BALL";
		IndigoItems [1] = "GREAT BALL";
		IndigoItems [2] = "FULL RESTORE";
		IndigoItems [3] = "MAX POTION";
		IndigoItems [4] = "FULL HEAL";
		IndigoItems [5] = "REVIVE";
		IndigoItems [6] = "MAX REPEL";


			StartCoroutine (check1 ());
			StartCoroutine (check2 ());
			StartCoroutine (check3 ());
			StartCoroutine (check4 ());


		}
	IEnumerator check1(){
		for (int i = 0; i < 20; i++) {
			if (itemslots [i] != "null") {
				if (itemslots[i] == "BIKE VOUCHER") {
					if (quantity[i] != 1) {
						KeyItem[i] = true;
						quantity[i] = 1;
					}
				}
				if (lc.ItemMode == 2 && lc.didFirstRunthrough) {
					if (lc.Items [i].GetComponent<itemslotinformation> ().Name != "") {
						KeyItem [i] = lc.Items [i].GetComponent<itemslotinformation> ().isKeyItem;
						itemslots [i] = lc.Items [i].GetComponent<itemslotinformation> ().Name;
					}
				}
			}
			if (itemslots [i] == "null"  ) {
				while (i + 1 != 20) {
					//yield return new WaitForSeconds (0.0001f);
					i++;
					itemslots [i] = "null";

				}
				yield return null;


			}

		}
	}

	IEnumerator check2(){
		for (int i = 0; i < 20; i++) {
			if (quantity [i] == 0) {
				itemslots [i] = "null";

			}
			if (itemslots [i] == "null"  ) {
				quantity[i] = -1;
			} else {
				if (quantity [i] == -1) {
					quantity [i] = 0;

				} else {
					if (lc.ItemMode == 2 && lc.didFirstRunthrough) {
						quantity [i] = lc.Items [i].GetComponent<itemslotinformation> ().intquantity;
					}
				}

			}



		}
		yield return null;
	}
	IEnumerator check3(){
		for (int i = 0; i < 50; i++) {
			if (PCslots [i] != "null") {
				if (PCslots[i] == "BIKE VOUCHER") {
					if (PCquantity[i] != 1) {
						PCKeyItem[i] = true;
					PCquantity[i] = 1;
					}
				}
				if ((lc.ItemMode == 1 || lc.ItemMode == 3) && lc.didFirstRunthrough) {
					if (lc.Items [i].GetComponent<itemslotinformation> ().Name != "") {
						PCKeyItem [i] = lc.Items [i].GetComponent<itemslotinformation> ().isKeyItem;
						PCslots [i] = lc.Items [i].GetComponent<itemslotinformation> ().Name;
					}
				}
			}
			if (PCslots [i] == "null") {
				while (i + 1 != 50) {
					//yield return new WaitForSeconds (0.0001f);
					i++;
					PCslots [i] = "null";

				}
				yield return null;


			}

		}
	}
	IEnumerator check4(){
		for (int i = 0; i < 50; i++) {
			if (PCquantity [i] == 0) {
				PCslots [i] = "null";

			}
			if (PCslots [i] == "null") {
				PCquantity[i] = -1;
			} 


			}




		yield return null;
	}
	}

