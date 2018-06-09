using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTile : MonoBehaviour {
	public Sprite[] tileanimsprites;
	void Update()
	{
		//StartCoroutine(DoAnimation());

	}
	// Update is called once per frame
	IEnumerator DoAnimation() {
		//Cycle through the tile's animation;
		int index = 0;
		while (index <= (tileanimsprites.Length - 1))
		{
			
			if (index == tileanimsprites.Length) break;
			GetComponent<SpriteRenderer>().sprite = tileanimsprites[index];
			index++;
			yield return new WaitForSeconds(1f);
		}

		
	}
}
