using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	//------------------//
	// Hidden Variables //
	//------------------//
	
	[HideInInspector] public Transform myTransform;		//Cached transform
	[HideInInspector] public bool collected;			//Has been collected?

	//------------------//
	// Public Variables //
	//------------------//

	public string spellName;			//Name of spell
	public string examineName;			//Name when examined
	public string spellDescription;		//Description when examined
	public int manaCost;				//Cost to cast
	public int level;					//What level spell is this?
	
	//-------//
	// Start //
	//-------//

	void Start () {
		
		myTransform = transform;
		
	}

	//--------//
	// Update //
	//--------//

	void Update () {
	
		if (!collected)
			myTransform.Rotate(Vector3.forward);

	}
		
}