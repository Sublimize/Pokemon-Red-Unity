using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyValues;
public class overworld : MonoBehaviour {


	public static bool IsBikeRidingAllowed(){
	// The bike can be used on Route 23 and Indigo Plateau,
	// or maps with tilesets in BikeRidingTilesets.
	// Return carry if biking is allowed.

		if (GlobalRegisters.wCurMap == 34 || GlobalRegisters.wCurMap == 9) {
			
			return true;
		}

		//check tilesets
		return false;
			}

}