using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//------------------//
	// Hidden Variables //
	//------------------//
	
	[HideInInspector] public int level;			//Level
	[HideInInspector] public float health;		//Health
	[HideInInspector] public float maxHealth;	//Max health
	[HideInInspector] public int attack;		//Attack

	//------------------//
	// Public Variables //
	//------------------//

	public string enemyName;			//Name
	public int attackPercentage;		//Percentage of attack
	public int healthPercentage;		//Percentage of health
	public int evade;					//Chance to evade
	public int deathProtect;			//Protection from killing blow
	public float physicalResist;		//from 0 to 1
	public float magicalResist;			//from 0 to 1
	public bool magicalAttack;			//Uses magical attack?
	public bool firstStrike;			//Always hits first?
	
	//-------------------//
	// Private Variables //
	//-------------------//

	private GameObject levelQuad;		//Level display
	private GameObject maxHealthBar;	//Max health bar
	private GameObject healthBar;		//Current health bar
	private GameLogic mainScript;		//Game logic script
	private bool soundPlayed;			//Played sound already?
	private float exposed;				//For sound playing

	//------//
	// Init //
	//------//

	public void Init () {

		//main game logic script
		mainScript = GameObject.Find("_Map").GetComponent<GameLogic>();

		//stats
		maxHealth = (int)Mathf.Pow((level + 3), 2) * healthPercentage / 100;
		health = maxHealth;
		attack = (int)Mathf.Pow((level), 2) / 2 + (5 * level / 2) * attackPercentage / 100;

		//adjust bars
		maxHealthBar = Instantiate(mainScript.maxHealthBar, transform.position + new Vector3(0, 0.8f, -0.6f), Quaternion.Euler(Vector3.left * 135)) as GameObject;
		maxHealthBar.transform.Translate(new Vector3(-0.05f, 0.5f, -0.01f));
		maxHealthBar.transform.parent = transform;
		healthBar = Instantiate(mainScript.healthBar, transform.position + new Vector3(0, 0.8f, -0.6f), Quaternion.Euler(Vector3.left * 135)) as GameObject;
		healthBar.transform.Translate(new Vector3(0.0f, 0.5f, 0.0f));
		healthBar.transform.parent = transform;
		AdjustBars();
		
		//level mesh
		levelQuad = Instantiate(mainScript.levelQuads[level-1], transform.position + new Vector3(0.0f, 0.8f, -0.6f), Quaternion.Euler(Vector3.left * 135)) as GameObject;
		levelQuad.transform.parent = transform;
		levelQuad.transform.Translate(new Vector3(-0.5f, 0.5f, 0.0f));
		levelQuad.transform.localScale = new Vector3(0.8f, 0.8f, 1);
		
		//animation
		// GetComponent<Animation>()["Default Take"].speed = Random.Range(0.75f, 1.25f);  //REMOVED ANIMATION FOR NOW
		
		//boss
		if (level == 10)
			gameObject.tag = "Boss";
		
	}

	//---------------//
	// Change Health //
	//---------------//

	public void ChangeHealth (int change) {
		
		health += change;
		AdjustBars();
		
	}

	//-------------//
	// Adjust Bars //
	//-------------//

	void AdjustBars () {
		
		float healthPercent = (health / maxHealth);
				
		maxHealthBar.transform.localScale = new Vector3(0.4f + 0.05f, 0.05f + 0.05f, 1);
		healthBar.transform.localScale = new Vector3(healthPercent * 0.4f, 0.05f, 1);
		
	}

	//--------//
	// Update //
	//--------//

	void Update () {
	
		if (level < 10)
			return;
		
		if (exposed < 0.01f)
			exposed += Time.deltaTime;
		else {
			if (!soundPlayed) {
				//mainScript.GetComponent<AudioSource>().PlayOneShot(mainScript.uncoverSound);
				soundPlayed = true;
			}
		}
		
	}
	
}