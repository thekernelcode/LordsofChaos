using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	//------------------//
	// Public Variables //
	//------------------//

	public int value;					//Value is used during map generation
	public int xPos;					//X position used for moving player
	public int yPos;					//Y position used for moving player
	public int holding;					//What is on this tile?
	public int collectable;				//Collectable item on this tile
	public bool visible;				//Is this tile visible?
	public Transform myTransform;		//Cached transform

	//-------//
	// Awake //
	//-------//

	void Awake () {
		
		myTransform = transform;
		holding = 0;
		
	}

	//---------------//
	// On Mouse Down //
	//---------------//

	void OnMouseDown () {
	
		GameLogic.playerMoved = false;
		GameLogic.newPlayerX = xPos;
		GameLogic.newPlayerY = yPos;
		GameLogic.lastTileClicked = GameLogic.tileClicked;
		GameLogic.tileClicked = gameObject;
		
	}
	
}