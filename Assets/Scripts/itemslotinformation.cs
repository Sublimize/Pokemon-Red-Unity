using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class itemslotinformation : MonoBehaviour {
	public bool isKeyItem;
	public TextMeshProUGUI slotNameText, slotQuantityText;
	public string Name;
	public int intquantity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		slotNameText.text = Name;
		if (!isKeyItem) {
			slotQuantityText.text = "*" +(intquantity <= 9 ? " ": "") + intquantity.ToString ();
		} else {

			slotQuantityText.text = "";
		}
	}
}
