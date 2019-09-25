using UnityEngine;
using System.Collections;

public class Ripple : MonoBehaviour {

	//-------------------//
	// Private Variables //
	//-------------------//

	private Transform myTransform;
	private float scale;

	//-------//
	// Start //
	//-------//

	void Start () {
	
		myTransform = transform;
		myTransform.localScale = Vector3.zero;
		
	}

	//--------//
	// Update //
	//--------//

	void Update () {
		
		if (scale < 1.0f) {
			scale += Time.deltaTime;
			myTransform.localScale = new Vector3(scale, scale, scale) * 0.5f;
			GetComponent<Renderer>().material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 1.0f - scale));
		} else
			Destroy(gameObject);
		
	}

}