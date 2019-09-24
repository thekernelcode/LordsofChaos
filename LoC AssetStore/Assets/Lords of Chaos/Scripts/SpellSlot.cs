using UnityEngine;
using System.Collections;

public class SpellSlot : MonoBehaviour {

	//------------------//
	// Public Variables //
	//------------------//

	public int slot;					//What slot is this?

	//-------------------//
	// Private Variables //
	//-------------------//

	private GameLogic mainScript;		//Main script

	//-------//
	// Start //
	//-------//

	void Start () {
		
		mainScript = GameObject.Find("_Map").GetComponent<GameLogic>();
		
	}

	//---------------//
	// On Mouse Down //
	//---------------//

	void OnMouseDown () {
	
		mainScript.UseSpell(slot);
		
	}
	
}