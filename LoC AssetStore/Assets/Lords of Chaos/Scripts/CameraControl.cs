using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	//-------------------------//
	// Public Static Variables //
	//-------------------------//

	public static bool loadLevel;				//Load level?
	public static bool goingToTitle;			//Go to title?
	public static bool replayGame;				//Go to main level?
	public static float wait;					//Delay
	public static float currentAlpha;			//Current alpha for fading quad

	//------------------//
	// Public Variables //
	//------------------//

	public bool onTitle;						//On title?

	//-------------------//
	// Private Variables //
	//-------------------//

	private GameObject fadeQuad;				//Fading quad
	private Material currentColor;				//Material for fading quad

	//-------//
	// Start //
	//-------//

	void Start () {
	
		fadeQuad = transform.Find("Fade").gameObject;
		currentAlpha = 1.0f;
		currentColor = fadeQuad.GetComponent<Renderer>().material;
		
		if (onTitle)
			RenderSettings.ambientLight = Color.white;
		
	}

	//-------------//
	// Late Update //
	//-------------//

	void LateUpdate () {
		
		AudioListener.volume = 1 - currentAlpha;
		
		if (onTitle) {
			if (loadLevel) {
				if (currentAlpha < 1) {
					currentAlpha += Time.deltaTime * 0.5f;
					currentColor.color = new Color(0.0f, 0.0f, 0.0f, currentAlpha);
				} else {
					loadLevel = false;
					Application.LoadLevel("Main");
				}
			} else {
				wait += Time.deltaTime;
				if (currentAlpha > 0 && wait > 0.5f) {
					currentAlpha -= Time.deltaTime * 0.5f;
					currentColor.color = new Color(0.0f, 0.0f, 0.0f, currentAlpha);
				}
			}
		} else {
			//for time advance
			if (loadLevel) {
				if (currentAlpha < 1) {
					currentAlpha += Time.deltaTime * 0.5f;
					currentColor.color = new Color(0.0f, 0.0f, 0.0f, currentAlpha);
				}
				if (wait > 0.0f)
					wait -= Time.deltaTime;
				else {
					loadLevel = false;
					if (goingToTitle) {
						goingToTitle = false;
						Application.LoadLevel("Title");
					}
					if (replayGame) {
						replayGame = false;
						Application.LoadLevel("Main");
					}
				}
			} else {
				if (currentAlpha > 0) {
					currentAlpha -= Time.deltaTime * 0.5f;
					currentColor.color = new Color(0.0f, 0.0f, 0.0f, currentAlpha);
				}
			}
		}
		
	}
	
}