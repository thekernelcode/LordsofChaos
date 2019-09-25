using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	//------------------//
	// Public Variables //
	//------------------//

	public string itemName;				//Item name
	public string examineName;			//Name when examined
	public string itemDescription;		//Description
	public int qty;						//Quantity
	public int cost;					//Purchase price

	//------------------//
	// Hidden Variables //
	//------------------//

	[HideInInspector] public Transform myTransform;		//Cached
	[HideInInspector] public bool collected;			//Collected yet?

	//-------//
	// Awake //
	//-------//

	void Awake () {
		
		myTransform = transform;

		//item has at least 1 use
		if (qty <= 0)
			qty = 1;
		
	}

	//--------//
	// Update //
	//--------//

	void Update () {
	
		if (!collected)
			myTransform.Rotate(Vector3.forward);

	}
		
}