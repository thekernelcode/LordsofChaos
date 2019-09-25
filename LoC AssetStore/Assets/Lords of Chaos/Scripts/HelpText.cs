using UnityEngine;
using System.Collections;

public class HelpText : MonoBehaviour {

	//-------------------------//
	// Public Static Variables //
	//-------------------------//
	
	public static int helpScreen;

	//------------------//
	// Public Variables //
	//------------------//

	public AudioClip clickSound;
	public GameObject helpFade;
	public GUIStyle customGUI;
	public Material[]helpMaterial;
	
	//-------------------//
	// Private Variables //
	//-------------------//

	private float currentAlpha;
	private Material currentColor;

	//-------//
	// Start //
	//-------//

	void Start () {
	
		helpScreen = 0;
		useGUILayout = false;
		currentColor = helpFade.GetComponent<Renderer>().material;
		
	}

	//--------//
	// Update //
	//--------//

	void Update () {
	
		if (helpScreen > 0) {
			if (currentAlpha < 0.9f)
				currentAlpha += Time.deltaTime;
			GetComponent<Renderer>().material = helpMaterial[1];
		} else {
			if (currentAlpha > 0.0f)
				currentAlpha -= Time.deltaTime;
			GetComponent<Renderer>().material = helpMaterial[0];
		}
		
		currentColor.color = new Color(0.0f, 0.0f, 0.0f, currentAlpha);
		
	}

	//---------------//
	// On Mouse Down //
	//---------------//

	void OnMouseDown () {
		
		helpScreen++;
		if (helpScreen > 5)
			helpScreen = 0;
		GetComponent<AudioSource>().PlayOneShot(clickSound);
		
	}

	//--------//
	// On GUI //
	//--------//

	void OnGUI () {
	
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1.0f));
		GUI.color = new Color(1.0f, 1.0f, 1.0f, currentAlpha);
		
		switch(helpScreen) {
		case 1 :
			GUI.Label(new Rect(20, 20, 440, 80), "Tutorial 1/5", customGUI);
			GUI.Label(new Rect(20, 60, 440, 80), "Your quest to defeat the Lords of Chaos will begin in the castle. Here you can purchase supplies to aid you on your quest or rest to pass time and heal your wounds.", customGUI);
			GUI.Label(new Rect(20, 180, 440, 80), "Simply tap on adjacent tiles to move to them and follow on-screen prompts to perform actions like opening chests, collecting items, and learning spells.", customGUI);
			break;
		case 2 :
			GUI.Label(new Rect(20, 20, 440, 40), "Tutorial 2/5", customGUI);
			GUI.Label(new Rect(20, 60, 440, 80), "You start your quest as a level 1 adventurer. Enemy levels range from 1-9 and the Lords of Chaos are always level 10. You will need to increase your level by earning experience.", customGUI);
			GUI.Label(new Rect(20, 180, 440, 80), "Experience is earned by defeating enemies. Higher level enemies yield more experience. Be careful tho, higher level enemies hit first in combat, and can withstand and deal more damage.", customGUI);
			break;
		case 3 :
			GUI.Label(new Rect(20, 20, 440, 40), "Tutorial 3/5", customGUI);
			GUI.Label(new Rect(20, 60, 440, 80), "As you defeat the game, the variety of enemies will increase making each quest more challenging than the last. However, more items and gold will be generated to aid your quest.", customGUI);
			GUI.Label(new Rect(20, 180, 440, 80), "Each class of enemy has unique attributes, you will need to work out the best approach for dealing with different types of enemies if you wish to defeat the Lords of Chaos.", customGUI);
			break;
		case 4 :
			GUI.Label(new Rect(20, 20, 440, 40), "Tutorial 4/5", customGUI);
			GUI.Label(new Rect(20, 60, 440, 80), "Your inventory is displayed in the form of a satchel in the upper left hand corner of the screen. Your spell book with learned spells are shown in the upper right hand corner.", customGUI);
			GUI.Label(new Rect(20, 180, 440, 80), "In the lower right hand corner of the screen, you will see your current level, gold, energy, experience, health, and mana levels. Collect and use items to replenish these levels.", customGUI);
			break;
		case 5 :
			GUI.Label(new Rect(20, 20, 440, 40), "Tutorial 5/5", customGUI);
			GUI.Label(new Rect(20, 60, 440, 80), "Take heed to this message. Your quest is fraught with danger, death comes swiftly and often to those who are unprepared. Foolish actions lead to an early grave.", customGUI);
			GUI.Label(new Rect(20, 180, 440, 80), "Defeating the Lords of Chaos will not be easy. Their realm is often cruel and unfair. Only the bravest and most cunning will survive and live to defeat the Lords of Chaos.", customGUI);
			break;
		}
		
	}
	
}