using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

	//------------------//
	// Public Variables //
	//------------------//

	public AudioClip clickSound;

	//---------------//
	// On Mouse Down //
	//---------------//

	void OnMouseDown () {
	
		if (HelpText.helpScreen > 0)
			return;
		
		if (!CameraControl.loadLevel) {
			CameraControl.loadLevel = true;
			GetComponent<AudioSource>().PlayOneShot(clickSound);
		}
		
	}
	
}