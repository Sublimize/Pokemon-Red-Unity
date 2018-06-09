using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWarp : MonoBehaviour {
	public Player play;
	public Vector2 warppos;
	// Use this for initialization
	void Start () {
		play = GameObject.Find("Player").GetComponent<Player>();
	}
	void OnTriggerStay2D(Collider2D col)
	{
		
		if (col.tag == "WallObjectPlayer")
		{
			Debug.Log("Detected player.");
			if (play.transform.position == play.pos)
			{
				play.walkedfromwarp = false;
				play.Warp(warppos);

			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
