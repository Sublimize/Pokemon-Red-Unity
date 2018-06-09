using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	public int bionumber;
	public AnimationClip idleUp, idleDown, idleLeft, idleRight, walkUp, walkDown, walkLeft, walkRight;
	public Animator playerAnim;
	public Dialogue dia;
	public bool moving;
	public bool inBattle;
	public bool HALLEVENT;
	public bool manuallyWalking;
	public bool walkedfromwarp;
	public GameObject credits;
	public int walkSurfBikeState;
	public int direction;
	public GameObject top, bottom;
	public ITEMTEXTDB IDB;
	public GameObject fameoak;
	public  bool canInteractAgain;
	public bool disabled, PCactive;
	public RaycastHit2D itemCheck;
	public bool startmenuup;
	public GameObject startmenu;
	public int money;
	public bool displayingEmotion;
	public int trainerID;
	public bool amenuactive;
	public Sprite[] bubbles;
	public LayerMask CollisionMask, ItemMask;
	public SpriteRenderer emotionbubble;
	public  int coins;
	public MainMenu moon;
	public bool shopup;
	public ViewBio BIO;
	//1 up, 2down, 3 left, 4 right
	public bool cannotMoveLeft, cannotMoveRight, cannotMoveUp, cannotMoveDown;

	public float speed = 2.0f;
	public Vector3 pos;
	Transform tr;
	// Use this for initialization
	void Start () {
		emotionbubble.enabled = false;
		trainerID = Random.Range (0, 65536);
		startmenuup = false;
		canInteractAgain = true;
		direction = 2;
		pos = transform.position;
		tr = transform;
	}
	public void Warp (Vector2 position){
		
		transform.localPosition = position;
		pos = tr.position;
	}
	void FixedUpdate()
	{
		

		if (dia.finishedWithTextOverall && !disabled && !startmenuup && !shopup && !inBattle) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				direction = 1;
				moving = true;

				if (tr.position == pos && !cannotMoveUp) {
					pos += (Vector3.up);
				}
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				direction = 4;
				moving = true;
				if (tr.position == pos && !cannotMoveRight) {
					
					pos += (Vector3.right);
				}

			} else if (Input.GetKey (KeyCode.DownArrow)) {
				direction = 2;
				moving = true;
				if (tr.position == pos && !cannotMoveDown) {
					
					pos += (Vector3.down);
				}
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				direction = 3;
				moving = true;
				if (tr.position == pos && !cannotMoveLeft) {
					
					pos += (Vector3.left);
				}
			}

			transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
			if (moving)
			{
				if (tr.position == pos)
				{
					if(!walkedfromwarp)
					walkedfromwarp = true;
				}

			}
			if (tr.position == pos)
			moving = false;
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
			moving = true;
		if (tr.position != pos)
			moving = true;
		playerAnim.SetFloat("movingfloat", moving? 1 : 0);
		playerAnim.SetFloat("movedir", direction);

		}


	}
	public IEnumerator MovePlayerOneTile(int direction){
		manuallyWalking = true;

		if (direction == 1) {
			direction = 1;
			moving = true;

			if (tr.position == pos) {

				pos += (Vector3.up);
			}
		} else if (direction == 2) {
			direction = 2;
			moving = true;
			if (tr.position == pos) {

				pos += (Vector3.right);
			}

		} else if (direction == 3) {
			direction = 3;
			moving = true;
			if (tr.position == pos) {

				pos += (Vector3.down);
			}
		} else if (direction == 4) {
			direction = 4;
			moving = true;
			if (tr.position == pos) {

				pos += (Vector3.left);
			}
		}

		transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
		while (moving) {
			yield return new WaitForSeconds (.1f);
			if (tr.position == pos) {
				break;
			}
		}
		moving = false;
		manuallyWalking = false;
	}
	// Update is called once per frame

	IEnumerator DoHallEvent(){
		yield return null;
		/*
		fameoak.GetComponent<NPC> ().currentdir = NPC.FacingDirection.South;
		for (int i = 0; i < 5; i++) {
			StartCoroutine (MovePlayerOneTile (1));

			while (manuallyWalking ) {
				yield return new WaitForSeconds (.1f);
				if (!manuallyWalking ) {
					break;
				}

			}
		}
		direction = 4;
		fameoak.GetComponent<NPC> ().currentdir = NPC.FacingDirection.West;
		yield return StartCoroutine(dia.text ("OAK: Er-hem!"));
		yield return StartCoroutine(dia.line ("Congratulations",0));
		yield return StartCoroutine(dia.cont (dia.Name + "!",1));
		yield return StartCoroutine(dia.para ("This floor is the"));
		yield return StartCoroutine(dia.line ("POKeMON HALL OF",0));
		yield return StartCoroutine(dia.cont ("FAME!",1));
		yield return StartCoroutine(dia.para ("POKeMON LEAGUE"));
		yield return StartCoroutine(dia.line ("champions are",0));
		yield return StartCoroutine(dia.cont ("honored for their",0));
		yield return StartCoroutine(dia.cont ("exploits here!",1));
		yield return StartCoroutine(dia.para ("Their POKeMON are"));
		yield return StartCoroutine(dia.line ("also recorded in",0));
		yield return StartCoroutine(dia.cont ("the HALL OF FAME!",1));
		yield return StartCoroutine(dia.para (dia.Name + "! You have"));
		yield return StartCoroutine(dia.line ("endeavored hard",0));
		yield return StartCoroutine(dia.cont ("to become the new",0));
		yield return StartCoroutine(dia.cont ("LEAGUE champion!",1));
		yield return StartCoroutine(dia.para ("Congratulations,"));
		yield return StartCoroutine(dia.line (dia.Name + ", you and",0));
		yield return StartCoroutine(dia.cont ("your POKeMON are",0));
		yield return StartCoroutine(dia.cont ("HALL OF FAMERs!"));
		yield return StartCoroutine(dia.done ());
		disabled = true;
		credits.SetActive (true);

*/
	}
	void Update () {
		playerAnim.SetFloat("walkbikesurfstate", walkSurfBikeState);
		if (BIO.bioscreen.enabled) {

			disabled = true;
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			StartCoroutine (BIO.DisplayABio (bionumber));

		}
		if(transform.localPosition == new Vector3(10, -5,0) && !HALLEVENT){
			
			HALLEVENT = true;
				StartCoroutine(DoHallEvent ());
		}
		startmenu.SetActive (startmenuup);
		if (!disabled && !amenuactive) {
			if (Input.GetKeyDown (KeyCode.Return) && !moving) {
				startmenuup = true;
				moon.Initialize ();
			}
			top.SetActive (!disabled);
			bottom.SetActive (!disabled);

			playerAnim.SetBool ("moving", moving);
			playerAnim.SetInteger ("movedirection", direction);
	
			if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.UpArrow)) {
				moving = false;
			
			}
			if (tr.position == pos) {
				transform.localPosition = new Vector3 (Mathf.Round (transform.localPosition.x), Mathf.Round (transform.localPosition.y), 0);
				pos = tr.position;
			}
	

			

			



			if (direction == 1) {

				itemCheck = Physics2D.Raycast (transform.position, Vector2.up, 8, ItemMask );
			}
			if (direction == 2) {

				itemCheck =	Physics2D.Raycast (transform.position, Vector2.down, 8, ItemMask);
			}
			if (direction == 3) {
				itemCheck = Physics2D.Raycast (transform.position, Vector2.left, 8, ItemMask);

			}
			if (direction == 4) {

				itemCheck =	Physics2D.Raycast (transform.position, Vector2.right, 8, ItemMask);
			}
			if (itemCheck.collider != null) {
				//print (itemCheck.distance.ToString ());
				if (itemCheck.distance <= .5f && !moving) {

					if (!moving && canInteractAgain && !PCactive && !shopup && !disabled && dia.finishedWithTextOverall && !startmenuup && !inBattle && !moving) {
						if (itemCheck.collider.tag.Contains("Interact") && !itemCheck.collider.tag.Contains("Player")) {
							if (Input.GetKeyDown (KeyCode.Z)) {

								if (itemCheck.collider.GetComponent<itemData> ().hasText) {
									if (itemCheck.collider.GetComponent<itemData> ().onlyonce) {
										if (!itemCheck.collider.GetComponent<itemData> ().triggered) {
											itemCheck.collider.GetComponent<itemData> ().triggered = true;
											canInteractAgain = false;
											IDB.PlayText (itemCheck.collider.GetComponent<itemData> ().TextID, itemCheck.collider.GetComponent<itemData> ().coinamount);
										}
									} else{
										if (itemCheck.collider.GetComponent<NPC> ()) {
											if(direction == 1){
												itemCheck.collider.GetComponent<NPC> ().currentdir = NPC.FacingDirection.South;
											}
											if(direction == 2){
												itemCheck.collider.GetComponent<NPC> ().currentdir = NPC.FacingDirection.North;
											}
											if(direction == 3){
												itemCheck.collider.GetComponent<NPC> ().currentdir = NPC.FacingDirection.East;
											}
											if(direction == 4){
												itemCheck.collider.GetComponent<NPC> ().currentdir = NPC.FacingDirection.West;
											}
										}
										canInteractAgain = false;
										IDB.PlayText (itemCheck.collider.GetComponent<itemData> ().TextID, itemCheck.collider.GetComponent<itemData> ().coinamount);


									}
								}


							}
						}
					}
				}

			}
			CheckCollision ();
		}

	}

	public void WaitToInteract(){
		Invoke ("ReenableInteracting", .1f);

	}

	void ReenableInteracting(){
		canInteractAgain = true;
		disabled = false;
	}
	public IEnumerator DisplayEmotiveBubble(int type){
		disabled = true;
		displayingEmotion = true;
		emotionbubble.enabled = true;
		emotionbubble.sprite = bubbles [type];
		yield return new WaitForSeconds (2);
		emotionbubble.enabled = false;
		displayingEmotion = false;

		disabled = false;



	}
	void CheckCollision(){
		RaycastHit2D leftCheck = Physics2D.Raycast (transform.position, Vector2.left, 2, CollisionMask);
		RaycastHit2D rightCheck = Physics2D.Raycast (transform.position, Vector2.right, 2, CollisionMask);
		RaycastHit2D upCheck = Physics2D.Raycast (transform.position, Vector2.up, 2, CollisionMask);
		RaycastHit2D downCheck = Physics2D.Raycast (transform.position, Vector2.down, 2, CollisionMask);

		if (upCheck.collider != null) {
			
			if (upCheck.collider.tag.Contains ("WallObject")) {
				//print (upCheck.distance);
				if (upCheck.distance <= 1) {
					cannotMoveUp = true;
				} else {
					cannotMoveUp = false;

				}
				
			}
		} else {
			cannotMoveUp = false;


		}
		if (downCheck.collider != null) {
			
			if (downCheck.collider.tag.Contains ("WallObject")) {
				//print (downCheck.distance);
				if (downCheck.distance <= 1) {
					cannotMoveDown = true;
				} else {
					cannotMoveDown = false;

				}
			}
			
		} else {

			cannotMoveDown = false;

		}
		if (leftCheck.collider != null) {
			
			if (leftCheck.collider.tag.Contains ("WallObject")) {
				//print (leftCheck.distance);
				if (leftCheck.distance <= 1) {
					cannotMoveLeft = true;
				} else {
					cannotMoveLeft = false;

				}
				
			}
		} else {

			cannotMoveLeft = false;

		}
		if (rightCheck.collider != null) {
			
			if (rightCheck.collider.tag.Contains ("WallObject")) {
				//print (rightCheck.distance);
				if (rightCheck.distance <= 1) {
					cannotMoveRight = true;
				} else {
					cannotMoveRight = false;

				}
				
			}
		} else {
			cannotMoveRight = false;


		}

	}
}
