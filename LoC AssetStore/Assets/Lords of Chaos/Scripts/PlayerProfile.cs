using UnityEngine;
using System.Collections;

public class PlayerProfile : MonoBehaviour {

	//-------------------------//
	// Public Static Variables //
	//-------------------------//

	public static bool optionAutoCollect;	//set to true for player to automatically collect items

	//load and save these collectable items
	public static int demonClaw;			//collectable item
	public static int eagleFeather;			//collectable item
	public static int unicornHorn;			//collectable item
	public static int orchid;				//collectable item
	public static int dragonScale;			//collectable item

	//stats
	public static int enemyLevel;			//start at 2 - max is 10 (up by 1)
	public static int goldLevel;			//start at 4 - max is 10 (up by 1)
	public static int itemLevel;			//start at 10 - max is 20+ (up by 2)
	public static int spellLevel;			//start at 1 - max is 4 (up by 1)
	public static bool discount;			//if true then adjust item prices at game start -25% etc.

	//these are set per character
	public static float physicalResist;		//from 0 to 1
	public static float magicalResist;		//from 0 to 1
	public static int evade;				//0-10 (0 = never, 10 = always)
	public static int attackBonus;			
	public static int magicAttackBonus;			
	public static int healthBonus;			
	public static int manaBonus;			
	public static int gold;
	public static float food;

	//variables
	public static int lastX;				
	public static int lastY;				
	public static int currentX;				
	public static int currentY;					
	public static int currentLevel;			
	public static int nextLevel;			
	public static int lastLevel;			
	public static int expGained;			
	public static int attack;
	public static int magicAttack;				
	public static int complete;
	public static float health;				
	public static float maxHealth;			
	public static float mana;					
	public static float maxMana;			
	public static float exp;				
	public static bool levelUp;				
	private static GameLogic mainScript;	
	private static GameObject levelQuad;			

	//------//
	// Init //
	//------//

	public static void Init () {
		
		//reset all static variables
		lastLevel = 0;
		currentLevel = 1;
		exp = 0;
		expGained = 0;
		
		//setup
		mainScript = GameObject.Find("_Map").GetComponent<GameLogic>();
		UpdateLevelQuad();
		
	}

	//-------------------//
	// Increase Complete //
	//-------------------//

	public static void IncreaseComplete () {
	
		complete += 1;

		PlayerPrefs.SetInt("PlayerComplete", complete);
		PlayerPrefs.Save ();

	}

	//--------------//
	// Update Stats //
	//--------------//

	public static void UpdateStats () {

		//add experience
		exp += expGained;
		expGained = 0;
		
		//enough to level up?
		nextLevel = (currentLevel * 5) + currentLevel * 5 * (currentLevel - 1) / 2;
		
		//increase stats
		if (exp >= nextLevel) {
			lastLevel = nextLevel;
			levelUp = true;
			currentLevel++;
			mainScript.CreateMessage("Your level has increased to level " + currentLevel + ".");
			mainScript.PlayLevelUp();
			UpdateLevelQuad();
			return;
		} else {
			levelUp = false;
			return;
		}
		
	}

	//---------------//
	// Refresh Stats //
	//---------------//

	public static void RefreshStats (bool h = false, bool m = false) {
				
		//stats
		attack = (4 * (currentLevel + 1)) + attackBonus;
		magicAttack = (2 * (currentLevel + 1)) + magicAttackBonus;
		maxHealth = (5 * (currentLevel + 1)) + healthBonus;
		maxMana = (5 * (currentLevel + 1)) + manaBonus;
		
		//refill health and mana
		if (h)
			health = maxHealth;
		if (m)
			mana = maxMana;
		
		//called again for multiple leveling
		UpdateStats();
		
	}

	//-------------------//
	// Update Level Quad //
	//-------------------//

	public static void UpdateLevelQuad () {

		if (levelQuad)
			Destroy(levelQuad);
		
		levelQuad = Instantiate(mainScript.levelQuads[currentLevel-1], mainScript.GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		levelQuad.transform.parent = mainScript.statParent.transform;
		levelQuad.transform.Translate(new Vector3(1.55f, 0.25f, -4.0f));
		levelQuad.transform.localScale = new Vector3(0.8f, 0.8f, 1);
		levelQuad.layer = 8;
		
		RefreshStats(true, true);
		
	}
	
}