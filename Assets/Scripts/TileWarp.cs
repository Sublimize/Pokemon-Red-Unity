using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class TileWarp : MonoBehaviour {
	public Player play;
	public Vector2 warppos;
    // Use this for initialization
    private void Awake()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(0.95f, 0.95f);
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;

    }
    void Start () {
		play = GameObject.Find("Player").GetComponent<Player>();
	}
	void OnTriggerStay2D(Collider2D col)
	{
		
		if (col.tag == "WallObjectPlayer")
		{
			Debug.Log("Detected player.");
			if (play.transform.position == play.pos && play.walkedfromwarp)
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
