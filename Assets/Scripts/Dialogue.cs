using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialogue : MonoBehaviour {
	private string str;
	public float scrollequation;
	public string Name, opponentName;
	public bool nextIsCont, nextisPara;
	public GameObject DialogueBox;
	public string stringToReveal;
	public bool cantscroll, displaysimmediate;
	//public Text dialoguetext;
	public TextMeshProUGUI dialoguetext;
	public GameObject indicator;
	public bool deactivated;
	public GameObject subdialogue;
	public int taskType;
	public int textSpeed;
	public bool finishedWithTextOverall;
	public bool finishedCurrentTask;
	public Image box;
	public bool finishedThePrompt;
	public Image theindicator;
	public GameObject cursor;
	public int selectedOption;
	public Slots lots;
	public GameObject yesnomenu, slotsmenu, buycoinsmenu;
	public GameObject[] options;
	public Player play;
    public TextMeshProUGUI[] buycoinstext;
	void Start(){
		
		finishedThePrompt = true;
		Name = "RED";
		finishedCurrentTask = true;
		finishedWithTextOverall = true;
		box.enabled = false;
		dialoguetext.enabled = false;
		theindicator.enabled = false;

	}


	IEnumerator AnimateText(string strComplete){
		box.enabled = true;
		dialoguetext.enabled = true;
		theindicator.enabled = true;
		indicator.SetActive (false);

		int i = 0;
		if (taskType == 3) {
			str = stringToReveal + "\n" +  "";
		} if(taskType != 5 && taskType != 3){
			str = "";
		}
		if (taskType == 5) {
			str = stringToReveal;

		}
		
		dialoguetext.text = str;

		if(taskType != 5){
		while( i < strComplete.Length ){
				
		
					yield return new WaitForSeconds (0.001f);
				
			str += strComplete[i++];
			dialoguetext.text = str;
				if (!displaysimmediate || !cantscroll) {
					if (Input.GetKey (KeyCode.Z)) {
						yield return new WaitForSeconds (scrollequation / 2);
					
					}
					if (!Input.GetKey (KeyCode.Z)) {
						yield return new WaitForSeconds (scrollequation);

					}
				}

			}
		}

		if((nextIsCont || taskType == 5 || nextisPara)){
			while (!Input.GetKeyDown (KeyCode.Z)) {
				
				yield return new WaitForSeconds (0.001f);
				if (i == strComplete.Length || taskType == 5) {
					indicator.SetActive (true);
				}
				if (Input.GetKeyDown (KeyCode.Z)) {
					break;
				}

			}

		}
		if (taskType == 5) {
			box.enabled = false;
			dialoguetext.enabled = false;
			theindicator.enabled = false;
			finishedWithTextOverall = true;
			play.WaitToInteract ();
			stringToReveal = "";
		}
		stringToReveal = str;
		if (!cantscroll) {
			finishedCurrentTask = true;	
		}
		nextIsCont = false;
			cantscroll = false;
		displaysimmediate = false;
		nextisPara = false;

	}
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (deactivated) {
			play.disabled = true;

		}
		buycoinstext [0].text = play.money.ToString ();
		buycoinstext [1].text = play.coins.ToString ();
		yesnomenu.SetActive (!finishedThePrompt);
		slotsmenu.SetActive (!finishedThePrompt);
		if(taskType != 6){
			yesnomenu.SetActive(false);
		}
		if(taskType != 7){
			slotsmenu.SetActive(false);
		}
		if (!finishedThePrompt) {
			if (taskType == 6) {
				if (Input.GetKeyDown (KeyCode.Z)) {
					finishedThePrompt = true;
					StopAllCoroutines ();
					dialoguetext.text = "";

					finishedCurrentTask = true;
				}
				if (Input.GetKeyDown (KeyCode.X)) {
					selectedOption = 1;
					StopAllCoroutines ();

					play.WaitToInteract ();
					dialoguetext.text = "";
					finishedThePrompt = true;
					finishedCurrentTask = true;

				}
				options = new GameObject[yesnomenu.transform.childCount];

				for (int i = 0; i < yesnomenu.transform.childCount; i++) {


					options [i] = yesnomenu.transform.GetChild (i).gameObject;
				}

				cursor.transform.position = options [selectedOption].transform.position;

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
				if (selectedOption == options.Length) {
					selectedOption = options.Length - 1;

				}
			}
			if (taskType == 7) {
				if (Input.GetKeyDown (KeyCode.Z)) {
					finishedThePrompt = true;
					StopAllCoroutines ();
					dialoguetext.text = "";
					finishedCurrentTask = true;
					finishedWithTextOverall = true;
				}
				if (Input.GetKeyDown (KeyCode.X)) {
					finishedThePrompt = true;
					Deactivate ();
					StopAllCoroutines ();
					play.WaitToInteract ();
					dialoguetext.text = "";
					finishedCurrentTask = true;
					finishedWithTextOverall = true;
					lots.Exit ();


				}
				options = new GameObject[slotsmenu.transform.childCount];

				for (int i = 0; i < slotsmenu.transform.childCount; i++) {


					options [i] = slotsmenu.transform.GetChild (i).gameObject;
				}

				cursor.transform.position = options [selectedOption].transform.position;

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
				if (selectedOption == options.Length) {
					selectedOption = options.Length - 1;

				}
			}
			} else {
				cursor.SetActive (false);
			}
		 
		if (textSpeed == 1) {
			scrollequation = 1;
		}
		if (textSpeed == 2) {
			scrollequation = 0.75f;
		}
		if (textSpeed == 3) {
			scrollequation = .5f;
		}
	}

	public IEnumerator para(string text){
		finishedCurrentTask = false;
		taskType = 1;
		stringToReveal = "";
		yield return StartCoroutine(AnimateText (text));
	}
/// <summary>
/// Initiates a paragraph text dialogue message signifying the next as a specific type. 0 for continue, 1 for paragraph.
/// </summary>
/// <returns>The text.</returns>
/// <param name="text">Text.</param>
/// <param name="nextypeindex">Nextypeindex.</param>
public IEnumerator para(string text, int nextypeindex)
{
	if (nextypeindex == 0)
		nextIsCont = true;
	else if (nextypeindex == 1)
		nextisPara = true;
				finishedCurrentTask = false;
		taskType = 1;
		stringToReveal = "";
		yield return StartCoroutine(AnimateText (text));
	}
public IEnumerator text(string text){
		finishedWithTextOverall = false;
		finishedCurrentTask = false;
		taskType = 2;
		stringToReveal = "";
		yield return StartCoroutine(AnimateText (text));
	}
	/// <summary>
	/// Initiates a starting text dialogue message signifying the next as a specific type. 0 for continue, 1 for paragraph.
	/// </summary>
	/// <returns>The text.</returns>
	/// <param name="text">Text.</param>
	/// <param name="nextypeindex">Nextypeindex.</param>
public IEnumerator text(string text, int nextypeindex)
{
	if (nextypeindex == 0)
		nextIsCont = true;
	else if (nextypeindex == 1)
		nextisPara = true;
			finishedWithTextOverall = false;
		finishedCurrentTask = false;
		taskType = 2;
		stringToReveal = "";
		yield return StartCoroutine(AnimateText (text));
	}
public IEnumerator line(string text){
					finishedCurrentTask = false;
		taskType = 3;

		yield return StartCoroutine(AnimateText (text));
	}
/// <summary>
/// Initiates a generic text dialogue message signifying the next as a specific type. 0 for continue, 1 for paragraph.
/// </summary>
/// <returns>The text.</returns>
/// <param name="text">Text.</param>
/// <param name="nextypeindex">Nextypeindex.</param>
public IEnumerator line(string text, int nextypeindex)
{
	if (nextypeindex == 0)
		nextIsCont = true;
	else if (nextypeindex == 1)
		nextisPara = true;
	finishedCurrentTask = false;
	taskType = 3;

	yield return StartCoroutine(AnimateText(text));	}
public IEnumerator cont(string text){
					finishedCurrentTask = false;
		taskType = 4;
		stringToReveal =   text;
		yield return StartCoroutine(AnimateText (text));

	}
/// <summary>
/// Initiates a continuing text dialogue message signifying the next as a specific type. 0 for continue, 1 for paragraph.
/// </summary>
/// <returns>The text.</returns>
/// <param name="text">Text.</param>
/// <param name="nextypeindex">Nextypeindex.</param>
public IEnumerator cont(string text, int nextypeindex)
{
	if (nextypeindex == 0)
		nextIsCont = true;
	else if (nextypeindex == 1)
		nextisPara = true;
	finishedCurrentTask = false;
	taskType = 4;
	stringToReveal = text;
	yield return StartCoroutine(AnimateText(text));
	}
public IEnumerator done(){
		taskType = 5;
					finishedCurrentTask = false;
		yield return StartCoroutine(AnimateText (stringToReveal));

	}
	public void prompt(){
		selectedOption = 0;
		taskType = 6;
		finishedCurrentTask = false;
		finishedWithTextOverall = false;
		finishedThePrompt = false;

	}
	public void slots(){
		selectedOption = 0;
		taskType = 7;
		finishedCurrentTask = false;
		finishedWithTextOverall = false;
		finishedThePrompt = false;


	}
	public void Deactivate(){
		StopAllCoroutines ();
		finishedCurrentTask = true;
		finishedWithTextOverall = true;
		stringToReveal = "";
		box.enabled = false;
		dialoguetext.enabled = false;
		theindicator.enabled = false;

	}

}
