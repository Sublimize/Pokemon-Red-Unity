using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyValues;
public class items : MonoBehaviour {
	public int ailmentsubtraction;
	// Use this for initialization
	void Start () {
		GlobalRegisters.wcf91 = 2;
		UseItem_ ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void UseItem_(){
		GlobalRegisters.wActionResultOrTookBattleTurn = 1;
		if ((196 - GlobalRegisters.wcf91) < 0) {
			ItemUseTMHM ();

		}
	
		ItemUsePtrTable ();
		}
	void ItemUsePtrTable(){
		 
		switch (GlobalRegisters.wcf91) {
		case 1:
			ItemUseBall ();
			break;
		case 2:
			ItemUseBall ();
			break;
		case 3:
			ItemUseBall ();
			break;
		case 4:
			ItemUseBall ();
			break;


		}


	}
	void ItemUseTMHM(){


	}
	#region //PokeBalls
	void ItemUseBall(){
		//Balls out of battle
		if (GlobalRegisters.wIsInBattle == 0) {
			ItemUseNotTime ();
			return;
		}
		//balls at trainers
		if (GlobalRegisters.wIsInBattle == 2) {

			ThrowBallAtTrainerMon ();
			return;
		}
		//if in old man battle
		if (GlobalRegisters.wBattleType  == 1) {
			canUseBall ();
			return;
		}
		//party full?
		if ((GlobalRegisters.wPartyCount - GlobalRegisters.PARTY_LENGTH) < 0) {
			canUseBall ();
			return;
		}
		//box full?
		if ((GlobalRegisters.wNumInBox - GlobalRegisters.MONS_PER_BOX) == 0) {
			BoxFullCannotThrowBall ();
			return;
		}

		canUseBall ();
	}
	void canUseBall(){
		if (GlobalRegisters.wBattleType != 2) {
			skipSafariZoneCode ();
			return;
		}
		GlobalRegisters.wNumSafariBalls--;
		skipSafariZoneCode ();
	}
	void skipSafariZoneCode(){
		//Call print function here.
		GlobalRegisters.CheckIsGhostBattle(); 
		if (GlobalRegisters.IsGhostBattle){
			//do disable catch code
			return;
		}
		if (GlobalRegisters.wBattleType == 0) {
			notOldManBattle ();
			return;
		}
		//old man code
		captured ();
	}
	void notOldManBattle(){
		if (GlobalRegisters.wCurMap == 147) {
			getrange ();
			return;
		}
		if (GlobalRegisters.wEnemyMonSpecies == 145) {
			//do cant be caught
			return;
		}
		getrange();

	}
	void getrange(){
		GlobalRegisters.b = Random.Range (0, 256);
		//masterball
		if (GlobalRegisters.wcf91 == 1) {
			captured ();
			return;
		}
		//pokeball
		if (GlobalRegisters.wcf91 == 4) {
			checkForAilments ();
			return;
		}
		if (GlobalRegisters.b > 200) {
			getrange ();
			return;

		}
		//great ball
		if (GlobalRegisters.wcf91 == 3) {
			checkForAilments ();
			return;
		}
		if(GlobalRegisters.b > 150){
			getrange ();
			return;
	}
		//ultra ball, safari ball
		checkForAilments();

	
	}
	void checkForAilments(){
		int status;
		if (GlobalRegisters.wEnemyMonStatus == 0) {
			status = 0;
			skipAilmentValueSubtraction (status);
			return;


		}
		if (GlobalRegisters.wEnemyMonStatus == 12) {
			status = 12;
			skipAilmentValueSubtraction (status);
			return;


		}
		status = 25;
		skipAilmentValueSubtraction (status);
	}
	void skipAilmentValueSubtraction(int statusValue){
		if (GlobalRegisters.b - statusValue <= 0) {
			captured ();
			return;
		}
			ailmentsubtraction = GlobalRegisters.b - statusValue;
		GlobalRegisters.b = GlobalRegisters.wEnemyMonMaxHP * 255;
		GlobalRegisters.a = 12;
		if (GlobalRegisters.wcf91 == 3) {
			GlobalRegisters.a = 8;
			skip1 ();
			return;
		}
		skip1 ();
	}
	void skip1(){
		GlobalRegisters.c = Mathf.FloorToInt (GlobalRegisters.b / GlobalRegisters.a);
		GlobalRegisters.a = Mathf.FloorToInt (GlobalRegisters.wEnemyMonHP / 4);
		//quotient code ugh
		skip2 ();
	}
	void skip2(){
		GlobalRegisters.b = Mathf.FloorToInt(GlobalRegisters.c / Mathf.Max (GlobalRegisters.wEnemyMonHP, 1));
		GlobalRegisters.bc = Mathf.Min (GlobalRegisters.b, 255);
		if (ailmentsubtraction > GlobalRegisters.wEnemyMonCatchRate) {
			failedToCapture ();
			return;

		}
		if (GlobalRegisters.b > 255) {
			captured ();
			return;

		}
		int Rand2 = Random.Range (0, 65536);
		if (Rand2 > GlobalRegisters.bc) {
			failedToCapture ();
			return;

		}
		GlobalRegisters.a = GlobalRegisters.wEnemyMonCatchRate * 100;
		if (GlobalRegisters.wcf91 == 4) {
			GlobalRegisters.BallFactor2 = 255;

		}
		if (GlobalRegisters.wcf91 == 3) {
			GlobalRegisters.BallFactor2 = 200;
		}
		if (GlobalRegisters.wcf91 == 2) {
			GlobalRegisters.BallFactor2 = 150;
		}
		skip4 ();
	}
	void skip4(){
		GlobalRegisters.b = Mathf.FloorToInt(GlobalRegisters.a / GlobalRegisters.BallFactor2);
		if (GlobalRegisters.b > 255) {
			GlobalRegisters.numberOfShakes = 3;
		}
		if (GlobalRegisters.wEnemyMonStatus == 0) {
			GlobalRegisters.Status2 = 0;
			skip5 ();
			return;
		}
		if (GlobalRegisters.wEnemyMonStatus == 3 || GlobalRegisters.wEnemyMonStatus == 4 || GlobalRegisters.wEnemyMonStatus == 6) {
			GlobalRegisters.Status2 = 5;
			skip5 ();
			return;
		}
		if (GlobalRegisters.wEnemyMonStatus == 2 ||  GlobalRegisters.wEnemyMonStatus == 5) {
			GlobalRegisters.Status2 = 10;
			skip5 ();
			return;
		}

	}
	void skip5(){
		GlobalRegisters.a = Mathf.FloorToInt(((GlobalRegisters.bc * GlobalRegisters.b)/255)+ GlobalRegisters.Status2);
		if (GlobalRegisters.a >= 0 && GlobalRegisters.a < 10) {
			GlobalRegisters.numberOfShakes = 0;
			setAnimData ();
			return;
		}
		if (GlobalRegisters.a >= 10 && GlobalRegisters.a < 30) {
			GlobalRegisters.numberOfShakes = 1;
			setAnimData ();
			return;
		}
		if (GlobalRegisters.a >= 30 && GlobalRegisters.a < 70) {
			GlobalRegisters.numberOfShakes = 2;
			setAnimData ();
			return;
		}
		if (GlobalRegisters.a >= 70) {
			GlobalRegisters.numberOfShakes = 3;
			setAnimData ();
			return;
		}
	}
	void skip5point(){
		//do the toss animation

		if (GlobalRegisters.wPokeBallAnimData == 0) {
			//00 text
		}
		//etc


		//find if it's transformed code
		if (GlobalRegisters.wEnemyBattleStatus3 == 2) {
			GlobalRegisters.wEnemyMonSpecies = 76; //ditto
			skip6 ();
			return;
		}
		//dont overwrite dvs if not transformed
		GlobalRegisters.wTransformedEnemyMonOriginalDVs = GlobalRegisters.wEnemyMonDVs;
		skip6 ();
	}
	void skip6(){
		//if caught, load the data
		if (GlobalRegisters.wBattleType == 2) {
			oldManCaughtMon ();
			return;
		}
		//print text 05

		//add the pokemon to the dex, check if it's there already

		//print text 06

		//load dex screen

		//if skipping , goto done

		//if sent to box, print sent to box text

		//done

		if (GlobalRegisters.wBattleType == 1) {
			return;
		}
		//do remove code
		}

	void ItemUseNotTime(){
		GlobalRegisters.PrintingString = "Not now!";

		ItemUseFailed ();
	}
	void captured(){

	}
	void failedToCapture(){
		GlobalRegisters.wPokeBallCaptureCalcTemp = GlobalRegisters.bc;
	}
	void setAnimData(){
		GlobalRegisters.wPokeBallAnimData = GlobalRegisters.numberOfShakes;
		print (GlobalRegisters.numberOfShakes);
		skip5point ();

	}
	void skipShakeCalculations(){
		Invoke ("skip5point", .33f);
	}
	void ThrowBallAtTrainerMon(){
		//do animation
		//printtext
		//removeanitem
	}
	void oldManCaughtMon(){
		GlobalRegisters.PrintingString = "OLD MAN caught the POKeMON!";
		//print

	}
	void BoxFullCannotThrowBall(){
		GlobalRegisters.PrintingString = "No space in the PC!";
			ItemUseFailed();
	}
	#endregion

	void ItemUseTownMap(){
		if (GlobalRegisters.wIsInBattle == 0) {
			ItemUseNotTime ();
			return;

		}

		//display town map;
	}
	#region //Bike
	void ItemUseBicycle(){
		if (GlobalRegisters.wIsInBattle == 0 || GlobalRegisters.wWalkBikeSurfState == 2) {
			ItemUseNotTime ();
			return;

		}
		if (GlobalRegisters.wWalkBikeSurfState == 1) {
			tryToGetOnBike ();

		}

	}
	void getOffBike(){
		GlobalRegisters.wWalkBikeSurfState = 0;
		GlobalRegisters.PrintingString = "Player got of the bike!";
		//Printtext;
	}
	void tryToGetOnBike(){
		if (!overworld.IsBikeRidingAllowed() ) {
			//NoCyclingAllowedHere
			return;
		}
		//else, reset keys, put player on bike, and play music


	}
	#endregion
	#region 
	void ItemUseSurfboard(){
		if(GlobalRegisters.wWalkBikeSurfState == 2){
		//	tryToStopSurfing ();
			return;
		}
		//call IsNextTileShoreOrWater
		//if it returns true, call SurfingAttemptFailed;
		//call CheckDorTilePairCollisions
		//if it returns true, call SurfingAttemptFailed;
		makePlayerMoveForward();
		//changetosurfstate, print text, change music;
		return;
	}
	void makePlayerMoveForward(){


	}
	//void  tryToStopSurfing(){
		//get tile id
		//call IsSpriteInFrontOfPlayer
		//if return true,
	//	cannotStopSurfing();
	//	return;
		//if return false, check for collisions in front
		//if return true,
	//	cannotStopSurfing();
//return;
		//if return false, if passable,
	//	stopSurfing();
	//	}
	void stopSurfing(){


	}
	void cannotStopSurfing(){

	}
	#endregion
	#region
	void ItemUsePokedex(){

		//load dex screen
	}
	#endregion
	void ItemUseFailed(){
		GlobalRegisters.wActionResultOrTookBattleTurn = 0;
		//PrintText();
	}

	}
	

