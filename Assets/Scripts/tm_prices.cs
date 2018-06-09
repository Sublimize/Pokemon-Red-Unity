using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyValues;
public class tm_prices : MonoBehaviour {
	public int[] TechnicalMachinePrices = new int[51];
	void Start(){
		TechnicalMachinePrices [1] = 3000;
		TechnicalMachinePrices [2] = 2000;
		TechnicalMachinePrices [3] = 2000;
		TechnicalMachinePrices [4] = 1000;
		TechnicalMachinePrices [5] = 3000;
		TechnicalMachinePrices [6] = 4000;
		TechnicalMachinePrices [7] = 2000;
		TechnicalMachinePrices [8] = 4000;
		TechnicalMachinePrices [9] = 3000;
		TechnicalMachinePrices [10] = 4000;
		TechnicalMachinePrices [11] = 2000;
		TechnicalMachinePrices [12] = 1000;
		TechnicalMachinePrices [13] = 4000;
		TechnicalMachinePrices [14] = 5000;
		TechnicalMachinePrices [15] = 5000;
		TechnicalMachinePrices [16] = 5000;
		TechnicalMachinePrices [17] = 3000;
		TechnicalMachinePrices [18] = 2000;
		TechnicalMachinePrices [19] = 3000;
		TechnicalMachinePrices [20] = 2000;
		TechnicalMachinePrices [21] = 5000;
		TechnicalMachinePrices [22] = 5000;
		TechnicalMachinePrices [23] = 5000;
		TechnicalMachinePrices [24] = 2000;
		TechnicalMachinePrices [25] = 5000;
		TechnicalMachinePrices [26] = 4000;
		TechnicalMachinePrices [27] = 5000;
		TechnicalMachinePrices [28] = 2000;
		TechnicalMachinePrices [29] = 4000;
		TechnicalMachinePrices [30] = 1000;
		TechnicalMachinePrices [31] = 2000;
		TechnicalMachinePrices [32] = 1000;
		TechnicalMachinePrices [33] = 1000;
		TechnicalMachinePrices [34] = 2000;
		TechnicalMachinePrices [35] = 4000;
		TechnicalMachinePrices [36] = 2000;
		TechnicalMachinePrices [37] = 2000;
		TechnicalMachinePrices [38] = 5000;
		TechnicalMachinePrices [39] = 2000;
		TechnicalMachinePrices [40] = 4000;
		TechnicalMachinePrices [41] = 2000;
		TechnicalMachinePrices [42] = 2000;
		TechnicalMachinePrices [43] = 5000;
		TechnicalMachinePrices [44] = 2000;
		TechnicalMachinePrices [45] = 2000;
		TechnicalMachinePrices [46] = 4000;
		TechnicalMachinePrices [47] = 3000;
		TechnicalMachinePrices [48] = 4000;
		TechnicalMachinePrices [49] = 4000;
		TechnicalMachinePrices [50] = 2000;
	}
	void GetMachinePrice(int ID){
		GlobalRegisters.hItemPrice = TechnicalMachinePrices [ID];

	}

}
