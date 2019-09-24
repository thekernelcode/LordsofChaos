using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	//------------------//
	// Hidden Variables //
	//------------------//
	
	[HideInInspector] public Transform myTransform;			//Cached
	[HideInInspector] public bool opened;					//Open already?
	[HideInInspector] public string chestDescriptionClose;	//Description when closed
	[HideInInspector] public string chestDescriptionOpen;	//Description when open

	//------------------//
	// Public Variables //
	//------------------//

	public string eventName;				//Event title
	public string eventDescription;			//Event details
	
	//-------//
	// Awake //
	//-------//

	void Awake () {
		
		chestDescriptionClose = "You have found a large wooden chest.";
		chestDescriptionOpen = "This chest has been opened already.";
		
	}
		
}