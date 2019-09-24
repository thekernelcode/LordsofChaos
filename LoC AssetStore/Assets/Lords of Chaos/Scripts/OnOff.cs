using UnityEngine;
using System.Collections;

public class OnOff : MonoBehaviour {

	//------------------//
	// Hidden Variables //
	//------------------//

	[HideInInspector] public bool isOn;
	
	//------------------//
	// Public Variables //
	//------------------//

	public GameObject onOffObject;
	public GameObject soundPos;
	public int dir;
	public AudioClip sound;

	//-------------------//
	// Private Variables //
	//-------------------//

	private bool skipSound;
	private bool skipToggle;

	//-------//
	// Start //
	//-------//

	void Start () {
		
		isOn = true;
	
	}

	//---------------//
	// On Mouse Down //
	//---------------//

	void OnMouseDown () {
		
		if (!skipToggle) {
			if (isOn)
				isOn = false;
			else
				isOn = true;
		}

		if (!skipSound)
			soundPos.GetComponent<AudioSource>().PlayOneShot(sound);

		onOffObject.SetActive(isOn);
		skipSound = false;
		skipToggle = false;
		
	}

	//------//
	// Open //
	//------//

	public void Open () {
	
		if (!isOn) {
			skipSound = true;
			skipToggle = true;
			OnMouseDown();
		}
		
	}
	
}