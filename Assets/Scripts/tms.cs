﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tms : MonoBehaviour {
	public MonLearnYesNo MON;
	// Use this for initialization
	void Start () {
		
	}
	
	public bool CanLearnTM(int MonNumber, int TechnicalMachine){
		if (MON.AbilityToLearn [MonNumber, TechnicalMachine]) {
			return true;
		} else {
			return false;
		}

	}
}
