using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEMTEXTDB : MonoBehaviour {
	public Dialogue mylog;
	public GameObject itemPCMenu, shopmenu, slotmenu;
	public bag lag;
	public itemdatabase id;
	public pokemart pm;
	public Player play;
	public pokemonstats pk;
	public Slots sl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayText(int ID, int amount){
		switch (ID) {
		case 1:
		//	if (play.direction == 3 || play.direction == 4) {
				StartCoroutine (Text1 ());
		//	}
			break;
		case 2:
			StartCoroutine (Text2 ());
			break;
		case 3:
			StartCoroutine (Text3 ());
			break;
		case 4:
			StartCoroutine (Text4 ());
			break;
		case 5:
			StartCoroutine (Text5 ());
			break;
		
		case 6:
			StartCoroutine (Text6 (amount));
			break;
		case 7:
			StartCoroutine (Text7 ());
			break;
		}

	


	}


	IEnumerator Text1(){
		if (play.direction == 3 || play.direction == 4) {
			if (play.coins > 0) {
				yield return StartCoroutine(mylog.text ("A slot machine!"));
				yield return StartCoroutine(mylog.line ("Want to play?"));
				mylog.prompt ();
				while (!mylog.finishedThePrompt) {
					yield return new WaitForSeconds (0.1f);
					if (mylog.finishedThePrompt) {
						break;

					}
				}
				if (mylog.selectedOption == 0) {
					mylog.Deactivate ();
					play.disabled = true;
					StartCoroutine (play.DisplayEmotiveBubble (1));
					while (play.displayingEmotion) {
						yield return new WaitForSeconds (0.1f);
						if (!play.displayingEmotion) {
							break;
						}
					}
					play.disabled = true;
					slotmenu.SetActive (true);
					StartCoroutine (sl.Initialize ());

				} else {
					mylog.Deactivate ();
					play.WaitToInteract ();
				}

			} else {
				yield return StartCoroutine(mylog.text ("You don't have any"));
				yield return StartCoroutine(mylog.line ("coins!"));
				yield return StartCoroutine(mylog.done ());


			}
		} else {
			play.canInteractAgain = true;
		}
	}

	IEnumerator Text2(){
		Debug.Log("Turning on PC.");
		mylog.Deactivate ();
		mylog.cantscroll = false;
		mylog.finishedWithTextOverall = true;
		yield return StartCoroutine(mylog.para (mylog.Name + " turned on"));
		yield return StartCoroutine(mylog.line ("the PC!"));
		yield return StartCoroutine(mylog.done());
		itemPCMenu.SetActive (true);
		itemPCMenu.GetComponent<pc> ().Initialize ();
	}
	IEnumerator Text3(){
		mylog.Deactivate ();
		mylog.cantscroll = false;
		mylog.finishedWithTextOverall = true;
		yield return StartCoroutine(mylog.para ("Battle!"));
		yield return StartCoroutine(mylog.done());
		pk.StartBattle (1,0);


	}
	IEnumerator Text4(){
		mylog.Deactivate ();
		mylog.cantscroll = false;
		mylog.finishedWithTextOverall = true;
		yield return StartCoroutine(mylog.para ("Hi there! How may I help you?"));
		yield return StartCoroutine(mylog.done());
		play.shopup = true;

		pm.martlist = id.IndigoItems;
		shopmenu.SetActive (true);
		pm.currentMenu = pm.buysellwindow;


	}

IEnumerator Text5()
{
	mylog.buycoinsmenu.SetActive(true);
	yield return StartCoroutine(mylog.text("Welcome to ROCKET"));
	yield return StartCoroutine(mylog.line("GAME CORNER!",1));
	yield return StartCoroutine(mylog.para("Do you need some"));
	yield return StartCoroutine(mylog.line("game coins?",1));
	yield return StartCoroutine(mylog.para("It's $1000 for 50"));
	yield return StartCoroutine(mylog.line("coins. Would you",0));
	yield return StartCoroutine(mylog.cont("like some?"));
	mylog.prompt();
	while (!mylog.finishedThePrompt)
	{
		yield return new WaitForSeconds(0.1f);
		if (mylog.finishedThePrompt)
		{
			break;
		}
	}
	if (mylog.selectedOption == 0)
	{
		if (play.coins <= 9949 && play.money >= 1000)
		{
			play.money -= 1000;
			play.coins += 50;
			yield return StartCoroutine(mylog.text("Thanks! Here are"));
			yield return StartCoroutine(mylog.line("your 50 coins!"));
			yield return StartCoroutine(mylog.done());
		}
		else
		{
			if (play.money < 1000)
			{
				yield return StartCoroutine(mylog.text("You can't afford"));
				yield return StartCoroutine(mylog.line("the coins!"));
				yield return StartCoroutine(mylog.done());
				mylog.buycoinsmenu.SetActive(false);
				yield break;


			}
			if (play.coins > 9949)
			{
				yield return StartCoroutine(mylog.text("Oops! Your COIN"));
				yield return StartCoroutine(mylog.line("CASE is full."));
				yield return StartCoroutine(mylog.done());
				mylog.buycoinsmenu.SetActive(false);
				yield break;

			}



		}
	}
	else
	{
		yield return StartCoroutine(mylog.text("No? Please come"));
		yield return StartCoroutine(mylog.line("play sometime!"));
		yield return StartCoroutine(mylog.done());


	}
	if (play.coins >= 500 && !lag.itemInInventory("BIKE VOUCHER"))
	{
		yield return StartCoroutine(mylog.text("Hey, by the"));
		yield return StartCoroutine(mylog.line("way...",1));
		yield return StartCoroutine(mylog.para("You have enough"));
		yield return StartCoroutine(mylog.line("coins to buy",0));
		yield return StartCoroutine(mylog.cont("this BIKE VOUCHER!",1));
		yield return StartCoroutine(mylog.para("Interested?"));
		mylog.prompt();
		while (!mylog.finishedThePrompt)
		{
			yield return new WaitForSeconds(0.1f);
			if (mylog.finishedThePrompt)
			{
				break;
			}
		}
		if (mylog.selectedOption == 0)
		{

			play.coins -= 500;
            StartCoroutine(lag.AddItem("BIKE VOUCHER", -2));
			yield return StartCoroutine(mylog.text("Here you go!",1));
			yield return StartCoroutine(mylog.para("You recieved a BIKE VOUCHER!"));
			yield return StartCoroutine(mylog.done());


		}
		else
		{
			mylog.Deactivate();


		}

	}

	mylog.buycoinsmenu.SetActive(false);
}

IEnumerator Text6(int coinamount)
{
	play.coins += coinamount;
	yield return StartCoroutine(mylog.text("Found " + coinamount + " coins!"));
	yield return StartCoroutine(mylog.done());



}
IEnumerator Text7()
{
	yield return StartCoroutine(mylog.text("I'm a rocket"));
	yield return StartCoroutine(mylog.line("scientist!"));
	yield return StartCoroutine(mylog.done());


}

}
