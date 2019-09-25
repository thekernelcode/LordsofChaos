using UnityEngine;
using System.Collections;

public class ShopSlot : MonoBehaviour {

	//------------------//
	// Public Variables //
	//------------------//

	public int slot;					//What slot is this?

	//-------------------//
	// Private Variables //
	//-------------------//

	private Item itemScript;			//Item script

	//-------//
	// Start //
	//-------//

	void Start () {
		
		itemScript = GetComponentInChildren<Item>();
		itemScript.collected = true;
		
	}

	//---------------//
	// On Mouse Down //
	//---------------//

	void OnMouseDown () {
	
		GameLogic.shopClicked = slot;
		
	}
	
}