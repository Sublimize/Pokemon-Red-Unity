using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokemonstats : MonoBehaviour {

	public string[] pokemonnameinslot = new string[6];
	public int[] Defense = new int[6];
	public int[] Attack = new int[6];
	public int[] Speed = new int[6];
	public int[] Special = new int[6];
	public int[] HP = new int[6];
	public int[] maxHP = new int[6];
	public int[] pokemonID = new int[6];
	public int[] monStatus = new int[6];
	public int[] monLevel = new int[6];
	public int[,] monMoves = new int[6,4];

	public GameObject battlemenu;
	public BattleManager bm;
	public Player play;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartBattle(int battleID, int battleType){
		play.inBattle = true;
		play.disabled = true;
		battlemenu.SetActive (true);
		bm.battleoverlay.sprite  = bm.blank;
		bm.Initialize ();
	}
}
