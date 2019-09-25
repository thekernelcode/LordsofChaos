using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	//------------------//
	// Hidden Variables //
	//------------------//
	
	[HideInInspector] public Camera mainCamera;			//Game camera
	[HideInInspector] public GameObject statParent;		//Stats parent

	//-------------------------//
	// Public Static Variables //
	//-------------------------//

	public static bool playerMoved;				//Should we move the player?
	public static int newPlayerX;				//New X position for player
	public static int newPlayerY;				//New Y position for player
	public static int shopClicked;				//Shop slot clicked
	public static GameObject tileClicked;		//Last tile to be clicked
	public static GameObject lastTileClicked;	//Previous tile to be clicked
	
	//------------------//
	// Public Variables //
	//------------------//

	public ParticleSystem particles;			//Rain etc.
	public GUIStyle customGUI;					//Custom font for main text
	public GUIStyle customGUISmall;				//Custom font for smaller text i.e. quest log etc.
	public int size;							//Maximum level size
	public int maxTiles;						//Maximum number of tiles to use
	public GameObject[] tile;					//Array of land tiles
	public GameObject[] sceneryArray;			//Array of scenery models
	public GameObject[] enemyArray;				//Array of enemy models
	public GameObject[] chestArray;				//Array of chest models/events
	public GameObject[] itemArray;				//Array of item models
	public GameObject[] fishArray;				//Array of fishing item models
	public GameObject[] spellArray;				//Array of spell models
	public GameObject[] levelQuads;				//Array of level quads
	public Item[] shopItems;					//Items in shop
	public Transform playerInventory;			//Player's backpack
	public Transform playerSpellbook;			//Player's spellbook
	public Transform playersBelt;				//Player's belt
	public GameObject fishingSpot;				//For fishing
	public GameObject playerCharacter;			//Player avatar
	public GameObject playerCharacterHorse;		//Player avatar on horse
	public GameObject castle;					//Castle model
	public GameObject tomb;						//Tomb model to use for slain enemies
	public GameObject goldPile;					//Gold
	public GameObject shadowQuad;				//Quad for all shadows
	public GameObject itemGUI;					//GUI for items
	public GameObject examineGUI;				//GUI for the examine bar
	public GameObject pairGUI;					//GUI for pairs of options
	public GameObject shopGUI;					//GUI for the castle
	public GameObject fadeGUI;					//GUI for the fade screen
	public GameObject overGUI;					//GUI for game over
	public GameObject maxHealthBar;				//Maximum health bar used for player and enemies
	public GameObject healthBar;				//Health bar used for player and enemies
	public GameObject maxEnergyBar;				//Maximum energy bar used for player only
	public GameObject energyBar;				//Energy bar used for player only
	public GameObject maxExpBar;				//Maximum experience bar used for player only
	public GameObject expBar;					//Experience bar used for player only
	public GameObject maxManaBar;				//Maximum mana bar used for player only
	public GameObject manaBar;					//Mana bar used for player only
	public GameObject dayAmbient;				//For ambient sounds and effects
	public GameObject nightAmbient;				//For ambient sounds and effects
	public GameObject rainAmbient;				//For ambient sounds and effects
	public GameObject rippleObject;				//For weather
	public GameObject splashObject;				//For weather
	public Camera GUICamera;					//GUI camera
	public AudioClip[] fightSounds;				//Array of fight sounds
	public AudioClip[] lightningSounds;			//For weather
	public AudioClip shopSound;					//Purchase sound
	public AudioClip itemSound;					//Item sound
	public AudioClip horseSound;				//Horse sound
	public AudioClip mapSound;					//Map and spell sound
	public AudioClip foodSound;					//Eat sound
	public AudioClip potionSound;				//Drink sound
	public AudioClip noSound;					//No sound
	public AudioClip moveSound;					//Move sound
	public AudioClip equipSound;				//Equip belt sound
	public AudioClip fireSound;					//Fire spell sound
	public AudioClip cheerSound;				//Won game sound
	public AudioClip menuSound;					//Menu button sound
	public AudioClip missedSound;				//Missed combat sound
	public AudioClip chestSound;				//Open chest sound
	public AudioClip discardSound;				//Discard item sound
	public AudioClip sickSound;					//Ate poison sound
	public AudioClip fishSound;					//Fishing sound
	public AudioClip spellPowerSound;			//Power spell sound
	public AudioClip spellHealSound;			//Healing spell sound
	public AudioClip spellCureSound;			//Cure spell sound
	public AudioClip goldSound;					//Gold sound
	public AudioClip phoenixSound;				//Death protect
	public AudioClip snoreSound;				//Snore sound
	public AudioClip deathSound;				//Death of player sound
	public AudioClip backToLifeSound;			//Death protect
	public AudioClip levelUpSound;				//Level up
	public AudioClip learnSound;				//Learn a spell
	public AudioClip prepSound;					//Cast fireball
	public AudioClip uncoverSound;				//For boss
	public Color dayColour;						//Day
	public Color nightColour;					//Night
	public OnOff onOffInventory;				
	public OnOff onOffBook;					
	public OnOff onOffStats;					
	public OnOff onOffQuestJournal;					

	//-------------------//
	// Private Variables //
	//-------------------//

	private Transform myTransform;				//Map transform
	private Transform rainParticles;			//Rain effects
	private RaycastHit rayHit;					//Ray information for weather
	private GameObject[] allObjects;			//Objects to be removed
	private GameObject playerChar;				//The player's avatar
	private GameObject playerCharHorse;			//The player's avatar on horse
	private GameObject newTile;					//Newly created tile
	private GameObject guiParent;				//GUI parent
	private GameObject playerExpBar;			//Player's experience bar
	private GameObject playerMaxExpBar;			//Player's maximum experience bar
	private GameObject playerHealthBar;			//Player's health bar
	private GameObject playerMaxHealthBar;		//Player's maximum experience bar
	private GameObject playerManaBar;			//Player's maximum mana bar
	private GameObject playerMaxManaBar;		//Player's maxumum health bar
	private GameObject playerEngBar;			//Player's energy bar
	private GameObject playerMaxEngBar;			//Player's maxumum energy bar
	private GameObject newEnemy;				//Used for making numerous game objects
	private GameObject newShadow;				//Used for making numerous game objects
	private GameObject newItem;					//Used for making numerous game objects
	private GameObject thisCastle;				//Castle model
	private Enemy enemyScript;					//Used for attack code
	private Enemy bossScript;					//For healing boss
	private Item itemScript;					//Used for item/shop code
	private Spell spellScript;					//Used for spell code
	private Chest chestScript;					//Used for chest events
	private GameObject[,] mapArray;				//Array of map tiles
	private GameObject[] inventory;				//Array for game objects for items in player's inventory
	private GameObject[] spellbook;				//Array for game objects for spells in player's spellbook
	private Tile[,] scriptArray;				//Array of tile scripts
	private Item[] inventoryScript;				//Array for scripts for items in player's inventory
	private Spell[] spellbookScript;			//Array for scripts for spells in player's spellbook
	private int pairClicked;					//Which button was clicked in a pair of options?
	private int itemsCarried;					//Number of items in players inventory
	private int spellsCarried;					//Number of spells in players spellbook
	private int showingGUI;						//Which GUI layout to show
	private int SX;								//Temporary X value
	private int SY;								//Temporary Y value
	private int bossX;							//Boss X position
	private int bossY;							//Boss Y position
	private int newX;							//New item X position
	private int newY;							//New item Y position
	private int startX;							//Castle X
	private int startY;							//Castle Y
	private int count;							//Temporary counter
	private int side;							//Temporary counter
	private int makeOK;							//Temporary random value
	private int randomNumber;					//Temporary random value
	private int expBonus;						//Temporary value used for experince
	private int tilesUsed;						//Number of used tiles
	private int usingItemFromSlot;				//For using inventory items
	private int usingSpellFromSlot;				//For using spellbook spells
	private int damageDealt;					//For combat
	private int foodCounter;					//For deducting food
	private int maxFightSounds;					//Total fighting sounds
	private int maxLightningSounds;				//Total lightning sounds
	private int showMessage;					//Item message to display
	private int nextAttackBonus;				//Item and spell to increase melee attack
	private int nextAvoidBonus;					//Item and spell increase chance to dodge next attack
	private int dayTime;						//Time of day
	private int drizzle;						//For rain
	private int maxItems;						//For inventory
	private int randomBias;						//For random items etc.
	private int randomBiasHalf;					//For random items etc.
	private int enemyKilled;					//For stats
	private int movesMade;						//For stats
	private int dir;							//For scenery
	private float offset;						//Offset for tile creation
	private float overWait;						//Temp counter used for game over
	private float hideWait;						//Temp counter used to hide examine GUI
	private float useDelay;						//Prevent double clicking
	private float nextDefenceBonus;				//Item and spell reduce damage from enemy - physical and magical resist
	private float stormTime;					//For weather
	private float lightTime;					//For weather
	private float splashTime;					//For weather
	private float splashX;						//For weather
	private float splashZ;						//For weather
	private float expPercent;					//For bars
	private float healthPercent;				//For bars
	private float manaPercent;					//For bars
	private float foodPercent;					//For bars
	private float switchIn;						//Switch delay
	private bool switchedDay;					//Switch day/night
	private bool strike;						//For weather
	private bool usingSpell;					//For spell casting
	private bool canRotate;						//Used for random scenery
	private bool isFishing;						//Is the player fishing?
	private bool playerCreated;					//Did we create the player?
	private bool enemyCreated;					//Did we create an enemy?
	private bool switchedGUI;					//Has the game over GUI been switched for the stats screen?
	private bool examineOnly;					//Examine item on ground after using item from full pack
	private bool itemCreated;					//For map creation
	private bool taken;							//For taking items
	private bool hasBelt;						//Is the player wearing a belt with 2 extra inventory slots?
	private bool hasHorse;						//Player bought a horse?
	private bool nextHitFirst;					//Item and spell to allow first strike
	private bool deathProtect;					//Item and spell to resurrect
	private bool clipText;						//For quest journal
	private bool gameIsOver;					//Game is complete
	private bool resized;						//Resized the castle?
	private bool sleepInCastle;					//Slept in castle
	private string gameOverText;				//Text to be displayed when player dies
	private string wonGameText;					//Text to be displayed when player defeats the boss
	private string foundText;					//Text to display when finding a collectable item
	private string message01;					//For adventure log
	private string message02;					//For adventure log
	private string message03;					//For adventure log
	private string goldToDraw;					//For player's gold

	//----------------------------//
	// Private Constant Variables //
	//----------------------------//

	private const int textHeight = 20;			//Line of text height (LEAVE ALONE!)
	private const int textWidth = 300;			//Line of text width (LEAVE ALONE!)
	
	//-------//
	// Start //
	//-------//
	
	void Start () {

		//cache camera
     	mainCamera = Camera.main;

		//render settings
		useGUILayout = false;
		RenderSettings.fog = true;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogStartDistance = 2.0f;

		//gui
		guiParent = new GameObject("GUI");
		itemGUI.transform.parent = guiParent.transform;
		examineGUI.transform.parent = guiParent.transform;
		pairGUI.transform.parent = guiParent.transform;
		fadeGUI.transform.parent = guiParent.transform;
		overGUI.transform.parent = guiParent.transform;
		shopGUI.transform.parent = guiParent.transform;
		statParent = GameObject.Find("_GUICamera").transform.Find("Stats").gameObject;//= new GameObject("Stats");
		
		//reference for scripts
     	inventory = new GameObject[6];
     	inventoryScript = new Item[6];
     	spellbook = new GameObject[4];
     	spellbookScript = new Spell[4];
		
		//adjust fade strength
		fadeGUI.GetComponent<Renderer>().material.SetColor ("_Color", new Vector4(1, 1, 1, 0.5f));
		
		//reset static variables
		playerCreated = false;
		playerMoved = false;
		gameIsOver = false;
		switchedDay = true;
		sleepInCastle = true;
		newPlayerX = 0;
		newPlayerY = 0;
		shopClicked = -1;
		tileClicked = null;
		lastTileClicked = null;
		message01 = "A new adventure begins.";
		message02 = "";
		message03 = "";
		playersBelt.gameObject.SetActive(false);
		maxFightSounds = fightSounds.Length;
		maxLightningSounds = lightningSounds.Length;
		dayTime = 1;
		drizzle = 0;
		rainAmbient.SetActive(false);
		rainParticles = rainAmbient.transform.Find("RainParticles");
		dayAmbient.SetActive(true);
		nightAmbient.SetActive(false);
		
		//create map
		GenerateMap();
		UpdateCamera(true);
		
	}

	//--------------//
	// Generate Map //
	//--------------//

	void GenerateMap (bool repopulate = false) {
		
		if (!repopulate) {
			//cache
			myTransform = transform;
			mapArray = new GameObject[size, size];
			scriptArray = new Tile[size, size];
			//create tiles and get scripts
			for (SX = 0 ; SX < size ; SX++) {
				for (SY = 0 ; SY < size ; SY++) {
					CalculateOffset(SX);
					mapArray[SX, SY] = Instantiate(tile[0], new Vector3(SX * 1.5f , 0.1f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 180, 0))) as GameObject;
					scriptArray[SX, SY] = mapArray[SX, SY].GetComponent<Tile>();
					scriptArray[SX, SY].myTransform.parent = myTransform;
					scriptArray[SX, SY].xPos = SX;
					scriptArray[SX, SY].yPos = SY;
				}
			}
			//small island to build from
			for (SX = -1 ; SX < 1 ; SX++) {
				for (SY = -1 ; SY < 1 ; SY++) {
					SetValue((int)(size * 0.5f) + SX, (int)(size * 0.5f + SY), 1);
				}
			}
			//extend island until max tiles are reached
			while (tilesUsed < maxTiles) {
				for (SY = (int)(size * 0.5f) ; SY < size-3 ; SY++) {
					for (SX = (int)(size * 0.5f) ; SX < size-3 ; SX++) {
						RandomTile();
					}
				}
				for (SY = (int)(size * 0.5f) ; SY < size-3 ; SY++) {
					for (SX = (int)(size * 0.5f) ; SX > 3 ; SX--) {
						RandomTile();
					}
				}
				for (SY = (int)(size * 0.5f) ; SY > 3 ; SY--) {
					for (SX = (int)(size * 0.5f) ; SX < size-3 ; SX++) {
						RandomTile();
					}
				}
				for (SY = (int)(size * 0.5f) ; SY > 3 ; SY--) {
					for (SX = (int)(size * 0.5f) ; SX > 3 ; SX--) {
						RandomTile();
					}
				}
			}
			//delete unused tiles
			for (SX = 0 ; SX < size ; SX++) {
				for (SY = 0 ; SY < size ; SY++) {
					if (scriptArray[SX, SY].value == 0) {
						SetHold(SX, SY, 10);
						Destroy(mapArray[SX, SY]);
					}
				}
			}
			//surround island with water tiles
			for (SX = 1 ; SX < size-1 ; SX++) {
				for (SY = 1 ; SY < size-1 ; SY++) {
					if (scriptArray[SX, SY].value == 0) {
						count = 0;
						makeOK = 0;
						while (count < 6) {
							count++;
							CalculateOffset(SX);
							if (count == 1 && scriptArray[SX, SY-1].value > 0)
								makeOK = 1;
							if (count == 2 && scriptArray[SX, SY+1].value > 0)
								makeOK = 1;
							if (offset == 1) {
								if (count == 3 && scriptArray[SX-1, SY+1].value > 0)
									makeOK = 1;
								if (count == 4 && scriptArray[SX-1, SY].value > 0)
									makeOK = 1;
								if (count == 5 && scriptArray[SX+1, SY+1].value > 0)
									makeOK = 1;
								if (count == 6 && scriptArray[SX+1, SY].value > 0)
									makeOK = 1;
							} else {
								if (count == 3 && scriptArray[SX-1, SY-1].value > 0)
									makeOK = 1;
								if (count == 4 && scriptArray[SX-1, SY].value > 0)
									makeOK = 1;
								if (count == 5 && scriptArray[SX+1, SY-1].value > 0)
									makeOK = 1;
								if (count == 6 && scriptArray[SX+1, SY].value > 0)
									makeOK = 1;
							}
							if (makeOK > 0) {
								mapArray[SX, SY] = Instantiate(tile[1], new Vector3(SX * 1.5f , -0.4f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 180, 0))) as GameObject;
								scriptArray[SX, SY] = mapArray[SX, SY].GetComponent<Tile>();
								scriptArray[SX, SY].myTransform.parent = myTransform;
								scriptArray[SX, SY].xPos = SX;
								scriptArray[SX, SY].yPos = SY;
								SetHold(SX, SY, 11);
								SetValue(SX, SY, -20);
								break;
							}
						}
					}
				}
			}
		} else {
			//prepare water for fishing
			for (SX = 0 ; SX < size ; SX++) {
				for (SY = 0 ; SY < size ; SY++) {
					if (scriptArray[SX, SY].value == -20)
						SetHold(SX, SY, 11);
				}
			}
			//preserve player and boss data
			SetHold(PlayerProfile.currentX, PlayerProfile.currentY, 10);
			SetHold(bossX, bossY, 10);
			SetHold(startX, startY, 10);
			//activate hidden items, enemies, etc.
			for (SX = 0 ; SX < size ; SX++) {
				for (SY = 0 ; SY < size ; SY++) {
					if (mapArray[SX, SY])
						SetActiveRecursively(mapArray[SX, SY], true);
				}
			}
			//find and remove items, enemies, etc.
			allObjects = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject go in allObjects)
				Destroy(go);
			allObjects = GameObject.FindGameObjectsWithTag("Item");
			foreach (GameObject go in allObjects)
				Destroy(go);
			//remove data from map
			for (SX = 0 ; SX < size ; SX++) {
				for (SY = 0 ; SY < size ; SY++) {
					if (scriptArray[SX, SY].holding < 10) {
						if (mapArray[SX, SY])
							SetHold(SX, SY, 0);
					}
				}
			}
			//restore boss data
			SetHold(bossX, bossY, 1);
			//hide and show tiles
			for (SX = 0 ; SX < size ; SX++) {
				for (SY = 0 ; SY < size ; SY++) {
					if (mapArray[SX, SY])
						mapArray[SX, SY].SetActive(scriptArray[SX, SY].visible);
				}
			}

		}
		
		//get player info
		
		if (PlayerPrefs.GetInt("PlayerComplete") == 0)
			PlayerPrefs.SetInt("PlayerComplete", 1);
		
		PlayerProfile.complete = PlayerPrefs.GetInt("PlayerComplete");
		randomBias = Mathf.Clamp(PlayerProfile.complete, 1, 10);
		randomBiasHalf = (int)Mathf.Ceil(randomBias * 0.5f);
		
		//enemies
		for (count = 0 ; count < 4 ; count++) {
			CreateEnemy(1);
			CreateEnemy(2);
		}
		for (count = 0 ; count < 3 ; count++) {
			CreateEnemy(3);
			CreateEnemy(4);
			CreateEnemy(5);
		}
		for (count = 0 ; count < 2 ; count++) {
			CreateEnemy(6);
			CreateEnemy(7);
			CreateEnemy(8);
			CreateEnemy(9);
		}
		//boss
		if (!repopulate)
			CreateEnemy(10);
		//gold, items, spells, chests, and scenery pieces
		for (count = 0 ; count < (8 + randomBias) ; count++)
			CreateGold();
		for (count = 0 ; count < (8 + randomBiasHalf) ; count++)
			CreateItem();
		for (count = 0 ; count < Random.Range(1, spellArray.Length + 1) ; count++)
			CreateSpell(count);
		for (count = 0 ; count < (5 + randomBiasHalf) ; count++)
			CreateChest();
		for (count = 0 ; count < Random.Range(randomBiasHalf, randomBias) ; count++)
			CreateFishingSpot();
		
		//start hidden
		HideAllGUI();
		
		if (!repopulate) {
			HideAll();
			CreatePlayer();
			GenerateText();
		} else {
			//restore player data
			SetHold(PlayerProfile.currentX, PlayerProfile.currentY, 0);
			SetHold(startX, startY, 2);
		}
		
		CreateScenery();
		CancelUsed();
		
		//collectables created last
		for (count = 0 ; count < randomBiasHalf ; count++)
			CreateCollectable();
		
	}

	//------------------------//
	// Set Active Recursively //
	//------------------------//

	void SetActiveRecursively (GameObject go, bool active) {

		go.SetActive(active);
		
		foreach (Transform child in go.transform)
			SetActiveRecursively(child.gameObject, active);

	}

	//-------------//
	// Random Tile //
	//-------------//

	void RandomTile () {
	
		//random number
		count = 0;
		randomNumber = Random.Range(1, 2);
		
		//create tile in random position
		if (scriptArray[SX, SY].value > 0 && tilesUsed < 100) {
			tilesUsed++;
			while (count < 6) {
				count++;
				makeOK = Random.Range(0, scriptArray[SX, SY].value + randomNumber);
				if (makeOK < 1) {
					CalculateOffset(SX);
					if (count == 1)
						SetValue(SX, SY-1, 1);
					if (count == 2)
						SetValue(SX, SY+1, 1);
					if (count == 5)
						SetValue(SX-1, SY, 1);
					if (count == 6)
						SetValue(SX+1, SY, 1);					
					if (offset == 1) {
						if (count == 3)
							SetValue(SX-1, SY+1, 1);
						if (count == 5)
							SetValue(SX+1, SY+1, 1);
					} else {
						if (count == 3)
							SetValue(SX-1, SY-1, 1);
						if (count == 5)
							SetValue(SX+1, SY-1, 1);
					}
				}
			}
		}
		
	}

	//-----------//
	// Set Value //
	//-----------//

	void SetValue (int x, int y, int valueAdjust) {

		scriptArray[x, y].value += valueAdjust;

	}

	//----------//
	// Set Hold //
	//----------//

	void SetHold (int x, int y, int hold) {
		
		scriptArray[x, y].holding = hold;
		
	}

	//------------------//
	// Calculate Offset //
	//------------------//

	void CalculateOffset (int x) {

		if ((float)(x * 0.5f) == (int)(x * 0.5f))
			offset = 1;
		else
			offset = 0.565f;

	}

	//-------------//
	// Set Visible //
	//-------------//

	void SetVisible (int x, int y, bool visible) {
		
		if (!mapArray[x, y])
			return;
		
		SetActiveRecursively(mapArray[x, y], visible);
		scriptArray[x, y].visible = visible;
						
	}

	//-------------------//
	// Calculate Visible //
	//-------------------//

	void CalculateVisible () {
		
		//player position
		SX = PlayerProfile.currentX;
		SY = PlayerProfile.currentY;
		
		//make player tile visible
		CalculateOffset(SX);
		SetVisible(SX, SY, true);
		
		//make surrounding tiles visible
		SetVisible(SX, SY+1, true);
		SetVisible(SX, SY-1, true);
		SetVisible(SX+1, SY, true);
		SetVisible(SX-1, SY, true);
		if (offset == 1) {
			SetVisible(SX-1, SY+1, true);
			SetVisible(SX+1, SY+1, true);
		} else {
			SetVisible(SX-1, SY-1, true);
			SetVisible(SX+1, SY-1, true);
		}
		
	}

	//---------------//
	// Generate Text //
	//---------------//

	void GenerateText () {
						
		gameOverText = "News of your epic failure spreads throughout the land. All hope is lost...";
		wonGameText = "Letting out a mighty battle cry, you raise the severed head of " + GenerateName.firstName + " " + GenerateName.lastName + "!";
		
	}

	//----------//
	// Hide All //
	//----------//

	void HideAll () {
		
		//hide all map pieces
		SetActiveRecursively(gameObject, false);
		gameObject.SetActive(true);
		
	}

	//---------------//
	// Create Player //
	//---------------//
	
	void CreatePlayer () {
	     
		//find a free tile to create player on
		while (!playerCreated) {
			newPlayerX = Random.Range(1, size);
			newPlayerY = Random.Range(1, size);
			if (scriptArray[newPlayerX, newPlayerY].holding == 0) {
				CalculateOffset(newPlayerX);
				playerChar = Instantiate(playerCharacter, new Vector3(newPlayerX * 1.5f , 0.75f, newPlayerY * 1.7324f + (2 * offset - 0.05f)), Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
				playerCharHorse = Instantiate(playerCharacterHorse, new Vector3(newPlayerX * 1.5f , 0.8f, newPlayerY * 1.7324f + (2 * offset) - 0.35f), Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
				rainParticles.position = playerChar.transform.position + Vector3.up * 4;
				newShadow = Instantiate(shadowQuad, new Vector3(newPlayerX * 1.5f , 0.37f, newPlayerY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newShadow.transform.localScale = new Vector3(0.6f, 0.5f, 0);
				newShadow.transform.parent = playerChar.transform;
				playerCharHorse.transform.parent = playerChar.transform;
				playerCharHorse.SetActive(false);
	            PlayerProfile.currentX = newPlayerX;
				PlayerProfile.currentY = newPlayerY;
				PlayerProfile.lastX = newPlayerX;
	            PlayerProfile.lastY = newPlayerY;
				startX = newPlayerX;
				startY = newPlayerY;
	            CalculateVisible();
	            playerCreated = true;
			}
		}
		
		CreateCastle();
		
		//parent gui to camera
		statParent.transform.parent = GUICamera.transform;
		guiParent.transform.parent = GUICamera.transform;

		//energy bar
		playerMaxEngBar = Instantiate(maxEnergyBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerMaxEngBar.transform.Translate(new Vector3(1.9f, 0.365f, -4.0f-0.01f));
		playerMaxEngBar.transform.parent = statParent.transform;
		playerMaxEngBar.layer = 8;
		playerEngBar = Instantiate(energyBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerEngBar.transform.Translate(new Vector3(1.95f, 0.365f, -4.0f));
		playerEngBar.transform.parent = statParent.transform;
		playerEngBar.layer = 8;		
		
		//experience bar
		playerMaxExpBar = Instantiate(maxExpBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerMaxExpBar.transform.Translate(new Vector3(1.3f, 0.8f, -4.0f-0.01f));
		playerMaxExpBar.transform.parent = statParent.transform;
		playerMaxExpBar.layer = 8;
		playerExpBar = Instantiate(expBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerExpBar.transform.Translate(new Vector3(1.35f, 0.8f, -4.0f));
		playerExpBar.transform.parent = statParent.transform;
		playerExpBar.layer = 8;
		
		//health bar
		playerMaxHealthBar = Instantiate(maxHealthBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerMaxHealthBar.transform.Translate(new Vector3(1.3f, 1.2f, -4.0f-0.01f));
		playerMaxHealthBar.transform.parent = statParent.transform;
		playerMaxHealthBar.layer = 8;
		playerHealthBar = Instantiate(healthBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerHealthBar.transform.Translate(new Vector3(1.35f, 1.2f, -4.0f));
		playerHealthBar.transform.parent = statParent.transform;
		playerHealthBar.layer = 8;
		
		//mana bar
		playerMaxManaBar = Instantiate(maxManaBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerMaxManaBar.transform.Translate(new Vector3(1.3f, 1.6f, -4.0f-0.01f));
		playerMaxManaBar.transform.parent = statParent.transform;
		playerMaxManaBar.layer = 8;
		playerManaBar = Instantiate(manaBar, GUICamera.transform.position + new Vector3(0.0f, 0.0f, -0.8f), Quaternion.Euler(Vector3.left * 180)) as GameObject;
		playerManaBar.transform.Translate(new Vector3(1.35f, 1.6f, -4.0f));
		playerManaBar.transform.parent = statParent.transform;
		playerManaBar.layer = 8;

		//adjust camera
		mainCamera.transform.position = playerChar.transform.position + new Vector3(0, 4f, -4f);
		mainCamera.transform.LookAt(playerChar.transform.position - Vector3.up);
		mainCamera.transform.parent = playerChar.transform;

		//adjust stats
		PlayerProfile.attackBonus = 2;
		PlayerProfile.healthBonus = 5;
		PlayerProfile.gold = Random.Range(5, 16) * randomBiasHalf;
		PlayerProfile.food = 20;
		
		//scale bars
		PlayerProfile.Init();
		AdjustBars();
		
	}

	//--------------//
	// Create Enemy //
	//--------------//

	void CreateEnemy (int level) {
		
		//random enemy type
		randomNumber = Random.Range(0, randomBias);
		enemyCreated = false;

		//create at random location
		while (!enemyCreated) {			
			SX = Random.Range(1, size);
			SY = Random.Range(1, size);
			if (scriptArray[SX, SY].holding == 0) {
				CalculateOffset(SX);
				SetHold(SX, SY, 1);
				newEnemy = Instantiate(enemyArray[randomNumber], new Vector3(SX * 1.5f , 0.75f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
				newEnemy.transform.parent = mapArray[SX, SY].transform;				
				newShadow = Instantiate(shadowQuad, new Vector3(SX * 1.5f , 0.36f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newShadow.transform.localScale = new Vector3(0.6f, 0.5f, 0);
				newShadow.transform.parent = newEnemy.transform;
				enemyScript = newEnemy.GetComponent<Enemy>();
				enemyScript.level = level;
				enemyScript.Init();
				newEnemy.SetActive(scriptArray[SX, SY].visible);
				enemyCreated = true;
				if (level == 10) {
					bossX = SX;
					bossY = SY;
					bossScript = enemyScript;
					switch(randomNumber) {
					case 0 :
						GenerateName.Goblin();
						break;
					case 1 :
						GenerateName.Hobgoblin();
						break;
					case 2 :
						GenerateName.Gnome();
						break;
					case 3 :
						GenerateName.Troll();
						break;
					case 4 :
						GenerateName.GoblinWolfRider();
						break;
					case 5 :
						GenerateName.Ogre();
						break;
					case 6 :
						GenerateName.Witch();
						break;
					case 7 :
						GenerateName.Banshee();
						break;
					case 8 :
						GenerateName.Dragon();
						break;
					case 9 :
						GenerateName.Demon();
						break;
					}
				}
			}
		}		
		
	}

	//-------------//
	// Create Item //
	//-------------//

	void CreateItem () {
		
		//random item
		itemCreated = false;
		randomNumber = Random.Range(0, 12 + randomBias);
	
		//create item
		while (!itemCreated) {
			SX = Random.Range(1, size);
			SY = Random.Range(1, size);
			if (scriptArray[SX, SY].holding == 0) {
				CalculateOffset(SX);
				SetHold(SX, SY, 3);
				newItem = Instantiate(itemArray[randomNumber], new Vector3(SX * 1.5f , 0.25f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newItem.transform.parent = mapArray[SX, SY].transform;
				newShadow = Instantiate(shadowQuad, new Vector3(SX * 1.5f , 0.36f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newShadow.transform.localScale = new Vector3(0.4f, 0.4f, 0);
				newShadow.transform.parent = newItem.transform;
				newItem.SetActive(scriptArray[SX, SY].visible);
				itemCreated = true;
			}
		}
	
	}

	//-------------//
	// Create Gold //
	//-------------//
	
	void CreateGold (int newGoldX = 0, int newGoldY = 0) {
		
		//random unless stated otherwise
		if (newGoldX == 0 && newGoldY == 0) {
			newGoldX = Random.Range(1, size);
			newGoldY = Random.Range(1, size);
		}
		
		//create
		if (scriptArray[newGoldX, newGoldY].holding == 0) {
			CalculateOffset(newGoldX);
			SetHold(newGoldX, newGoldY, 5);
			newItem = Instantiate(goldPile, new Vector3(newGoldX * 1.5f , 0.25f, newGoldY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
			newItem.transform.parent = mapArray[newGoldX, newGoldY].transform;
			newShadow = Instantiate(shadowQuad, new Vector3(newGoldX * 1.5f , 0.36f, newGoldY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
			newShadow.transform.localScale = new Vector3(0.4f, 0.4f, 0);
			newShadow.transform.parent = newItem.transform;
			newItem.SetActive(scriptArray[newGoldX, newGoldY].visible);
		}
	
	}

	//--------------------//
	// Create Collectable //
	//--------------------//

	void CreateCollectable () {
		
		randomNumber = Random.Range(1, 6);
	
		newX = Random.Range(1, size);
		newY = Random.Range(1, size);
		if (scriptArray[newX, newY].holding == 0) {
			SetHold(newX, newY, 8);
			scriptArray[newX, newY].collectable = randomNumber;
		}
	
	}

	//--------------//
	// Create Spell //
	//--------------//

	void CreateSpell (int level) {
			
		for (int i = 0 ; i < 4 ; i++) {
			if (spellbookScript[count] && spellbookScript[count].level == level + 1) {
				return;
			}
		}
		
		itemCreated = false;
			
		while (!itemCreated) {
			newX = Random.Range(1, size);
			newY = Random.Range(1, size);
			if (scriptArray[newX, newY].holding == 0) {
				CalculateOffset(newX);
				SetHold(newX, newY, 4);
				newItem = Instantiate(spellArray[level], new Vector3(newX * 1.5f , 0.25f, newY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newItem.transform.parent = mapArray[newX, newY].transform;
				newShadow = Instantiate(shadowQuad, new Vector3(newX * 1.5f , 0.36f, newY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newShadow.transform.localScale = new Vector3(0.4f, 0.4f, 0);
				newShadow.transform.parent = newItem.transform;
				newItem.SetActive(scriptArray[newX, newY].visible);
				itemCreated = true;
			}
		}
		
	}

	//---------------//
	// Create Castle //
	//---------------//

	void CreateCastle () {
		
		CalculateOffset(PlayerProfile.currentX);
		SetHold(PlayerProfile.currentX, PlayerProfile.currentY, 2);
		thisCastle = Instantiate(castle, new Vector3(PlayerProfile.currentX * 1.5f , 0.365f, PlayerProfile.currentY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
		thisCastle.transform.parent = mapArray[PlayerProfile.currentX, PlayerProfile.currentY].transform;

	}
		
	//--------------//
	// Create Chest //
	//--------------//

	void CreateChest () {
	
		//random item
		itemCreated = false;
		randomNumber = Random.Range(0, chestArray.Length);
	
		//create item
		while (!itemCreated) {
			SX = Random.Range(1, size);
			SY = Random.Range(1, size);
			if (scriptArray[SX, SY].holding == 0) {
				CalculateOffset(SX);
				SetHold(SX, SY, 6);
				newItem = Instantiate(chestArray[randomNumber], new Vector3(SX * 1.5f , 0.23f, SY * 1.7324f + (2 * offset) + 0.2f), Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
				newItem.transform.parent = mapArray[SX, SY].transform;
				newItem.SetActive(scriptArray[SX, SY].visible);
				itemCreated = true;
			}
		}
						
	}

	//----------------//
	// Create Scenery //
	//----------------//

	void CreateScenery () {
		
		//create scenery
		for (count = 0 ; count < 40 ; count++ ) {
			SX = Random.Range(1, size);
			SY = Random.Range(1, size);
			canRotate = false;
			if (mapArray[SX, SY] && scriptArray[SX, SY].holding < 9 && scriptArray[SX, SY].holding != 2 && scriptArray[SX, SY].holding != 6) {
				randomNumber = Random.Range(0, sceneryArray.Length);
				if (randomNumber > 1)
					canRotate = true;
				CalculateOffset(SX);
				SetHold(SX, SY, scriptArray[SX, SY].holding + 100);
				newItem = Instantiate(sceneryArray[randomNumber], new Vector3(SX * 1.5f , 0.1f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				if (canRotate)
					newItem.transform.Rotate(Vector3.up * 180.0f, Space.World);
				if (randomNumber == 0) {
					dir = Random.Range(0, 2);
					if (dir == 0)
						dir = -1;
					newItem.transform.Translate(Vector3.left * 0.3f * dir, Space.World);
				}
				newItem.transform.parent = mapArray[SX, SY].transform;
				newItem.SetActive(scriptArray[SX, SY].visible);
			}
		}
		
		//reset holding to old value
		for (SX = 0 ; SX < size ; SX++) {
			for (SY = 0 ; SY < size ; SY++) {
				if (scriptArray[SX, SY].holding > 11) {
					if (mapArray[SX, SY])
						SetHold(SX, SY, scriptArray[SX, SY].holding - 100);
				}
			}
		}
		
	}

	//---------------------//
	// Create Fishing Spot //
	//---------------------//

	void CreateFishingSpot () {
		
		//random item
		itemCreated = false;
		randomNumber = Random.Range(0, fishArray.Length);
	
		//create item
		while (!itemCreated) {
			SX = Random.Range(1, size);
			SY = Random.Range(1, size);
			if (scriptArray[SX, SY].holding == 11) {
				CalculateOffset(SX);
				SetHold(SX, SY, 9);
				newItem = Instantiate(fishArray[randomNumber], new Vector3(SX * 1.5f, 50f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newItem.transform.parent = mapArray[SX, SY].transform;
				newItem.SetActive(scriptArray[SX, SY].visible);
				newShadow = Instantiate(fishingSpot, new Vector3(SX * 1.5f, -0.07f, SY * 1.7324f + (2 * offset)), Quaternion.Euler(new Vector3(270, 0, 0))) as GameObject;
				newShadow.transform.parent = newItem.transform;
				newShadow.SetActive(scriptArray[SX, SY].visible);
				itemCreated = true;
			}
		}
		
	}

	//-------------//
	// Create Tomb //
	//-------------//

	void CreateTomb (bool forPlayer = false) {
	
		if (!forPlayer) {
			CalculateOffset(newPlayerX);
			newItem = Instantiate(tomb, new Vector3(newPlayerX * 1.5f, 0.4f, newPlayerY * 1.7324f + (2 * offset) + 0.5f), Quaternion.Euler(new Vector3(270, 180, 0))) as GameObject;
			newItem.transform.parent = mapArray[newPlayerX, newPlayerY].transform;
		} else {
			CalculateOffset(PlayerProfile.currentX);
			newItem = Instantiate(tomb, new Vector3(PlayerProfile.currentX * 1.5f , 0.4f, PlayerProfile.currentY * 1.7324f + (2 * offset) + 0.5f), Quaternion.Euler(new Vector3(270, 180, 0))) as GameObject;
			mainCamera.transform.parent = null;
			Destroy(playerChar);
		}
		
	}

	//----------------//
	// Create Message //
	//----------------//

	public void CreateMessage (string message) {
		
		message03 = message02;
		message02 = message01;
		message01 = message;
		
	}
	
	//--------//
	// Update //
	//--------//
	
	void Update () {
		
		//lightning
		if (drizzle > 3) {
			if (stormTime > 0.0f) {
				stormTime -= Time.deltaTime;
				strike = false;
			} else {
				if (!strike) {
					RenderSettings.ambientLight = new Color(1.0f, 1.0f, 1.0f, 1.0f);
					GetComponent<AudioSource>().PlayOneShot(lightningSounds[Random.Range(0, maxLightningSounds)]);
					lightTime = Random.Range(0.1f, 0.5f);
					strike = true;
				}
				if (lightTime > 0.0f)
					lightTime -= Time.deltaTime;
				else {
					if (dayTime == 1)
						RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f, 0.8f);
					else
						RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f, 0.5f);
					stormTime = Random.Range(2.0f, 60.0f);
				}
			}
		}
		
		//rain splashes and ripples
		if (drizzle > 2) {
			if (splashTime > 0.0f)
				splashTime -= Time.deltaTime * drizzle;
			else {
				splashX = rainParticles.transform.position.x + Random.Range(-4.0f, 4.0f);
				splashZ = rainParticles.transform.position.z + Random.Range(-4.0f, 4.0f);
				if (Physics.Raycast(new Vector3(splashX, 4.0f, splashZ), -Vector3.up, out rayHit, 6.0f)) {
					if (rayHit.transform.gameObject.tag == "Grass")
						newItem = Instantiate(splashObject, new Vector3(splashX , 0.4f, splashZ), Quaternion.identity) as GameObject;
					else
						newItem = Instantiate(rippleObject, new Vector3(splashX , -0.1f, splashZ), Quaternion.identity) as GameObject;
					newItem.transform.eulerAngles = -Vector3.left * 270;
				}
				splashTime = Random.Range(0.1f, 0.25f);
			}
		}
		
		//switch day/night
		if (switchIn > 0.0f) {
			switchIn -= Time.deltaTime;
			return;
		} else {	
			if (!switchedDay)
				UpdateCamera();
		}
		
		//game over
		if (PlayerProfile.health <= 0 || gameIsOver) {
			if (!switchedGUI) {
				if (overWait > 0)
					overWait -= Time.deltaTime;
				else {
					ShowStatsGUI();
					switchedGUI = true;
				}
			}
			return;
		}
		
		//prevent double clicking
		if (useDelay > 0.0f)
			useDelay -= Time.deltaTime;
		
		//hide examine gui
		if (showingGUI == 13) {
			if (hideWait > 0)
				hideWait -= Time.deltaTime;
			else
				HideAllGUI();
		}
		
		//move player
		if (!playerMoved) {
			if (!Adjacent(newPlayerX, newPlayerY)) {
				GetComponent<AudioSource>().PlayOneShot(noSound);
				playerMoved = true;
				return;
			}
			//move player to free visible tile
			if (scriptArray[newPlayerX, newPlayerY].visible) {
				switch (scriptArray[newPlayerX, newPlayerY].holding) {
				case 0://blank
					HideAllGUI();
					MoveTo(newPlayerX, newPlayerY);
					CancelUsed();
					break;
				case 1://enemy
					enemyScript = tileClicked.GetComponentInChildren<Enemy>();
					if (!Adjacent(newPlayerX, newPlayerY))
						MoveNextTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					//using item
					if (usingItemFromSlot > -1) {
						//Update quest log
						if (inventoryScript[usingItemFromSlot].qty > 1)
							CreateMessage("You have used a " + inventoryScript[usingItemFromSlot].examineName + ".");
						else
							CreateMessage("You have used the " + inventoryScript[usingItemFromSlot].examineName + ".");
						switch(inventoryScript[usingItemFromSlot].itemName) {
						case "Throwing Knife":
							PlayerHitEnemy(PlayerProfile.attack, false);
							break;
						case "Wand of Fireball":
							PlayerHitEnemy(PlayerProfile.magicAttack, false, true);
							GetComponent<AudioSource>().PlayOneShot(fireSound);
							break;
						}
						DeductItem(usingItemFromSlot);
						CancelUsed();
						CheckGround();
						return;
					}
					//using spell
					if (usingSpellFromSlot > -1) {
						PlayerProfile.mana -= spellbookScript[usingSpellFromSlot].manaCost;
						switch(spellbookScript[usingSpellFromSlot].spellName) {
						case "Fireball":
							PlayerHitEnemy(PlayerProfile.magicAttack, false, true);
							GetComponent<AudioSource>().PlayOneShot(fireSound);
							break;
						}
						AdjustBars();
						CancelUsed();
						CheckGround();
						return;
					}
					//melee attack
					if (PlayerStrikeFirst())
						PlayerHitEnemy(PlayerProfile.attack, true);
					else
						EnemyHitPlayer(true);
					AdjustBars();
					CheckGround();
					break;
				case 2://castle
					resized = false;
					MoveTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					CancelUsed();
					CheckItemsCarried();
					showingGUI = 6;
					ShowExamineGUI();
					break;
				case 3://item
					MoveTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					CancelUsed();
					itemScript = tileClicked.GetComponentInChildren<Item>();
					if (!itemScript)
						itemScript = lastTileClicked.GetComponentInChildren<Item>();
					if (!itemScript)
						return;
					CheckItemsCarried();
					if (PlayerProfile.optionAutoCollect) {
						if (itemsCarried < 4 && !hasBelt || itemsCarried < 6 && hasBelt)
							TakeItem();
					} else {
						if (itemsCarried < 4 && !hasBelt || itemsCarried < 6 && hasBelt) {
							if (!examineOnly) {
								ShowItemGUI();
								ShowPairGUI();
							} else {
								examineOnly = false;
								showingGUI = 5;
								ShowExamineGUI();
							}
						} else {
							showingGUI = 1;
							ShowExamineGUI();
						}
					}
					break;
				case 4://spell
					MoveTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					CancelUsed();
					CheckSpellsCarried();
					if (PlayerProfile.optionAutoCollect) {
						if (spellsCarried < 4)
							LearnSpell();
					} else {
						spellScript = tileClicked.GetComponentInChildren<Spell>();
						if (!spellScript)
							spellScript = lastTileClicked.GetComponentInChildren<Spell>();
						if (spellsCarried < 4) {
							if (!examineOnly) {
								ShowSpellGUI();
								ShowPairGUI();
							} else {
								examineOnly = false;
								showingGUI = 7;
								ShowExamineGUI();
							}
						} else {
							showingGUI = 3;
							ShowExamineGUI();
						}
					}
					break;
				case 5://gold
					MoveTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					CancelUsed();
					ShowExamineGUI();
					SetHold(newPlayerX, newPlayerY, 0);
					showingGUI = 13;
					randomNumber = Random.Range(5, 11 + randomBias);
					PlayerProfile.gold += randomNumber;
					foundText = "Found " + randomNumber + " gold coins!";
					GetComponent<AudioSource>().PlayOneShot(goldSound);
					CreateMessage(foundText);						
					itemScript = tileClicked.GetComponentInChildren<Item>();
					Destroy(itemScript.gameObject);
					hideWait = 2.5f;
					break;
				case 6://chest
					MoveTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					CancelUsed();
					chestScript = tileClicked.GetComponentInChildren<Chest>();
					if (!chestScript)
						chestScript = lastTileClicked.GetComponentInChildren<Chest>();
					if (!chestScript)
						return;
					if (!chestScript.opened) {
						if (!examineOnly)
							ShowChestGUI();
						else {
							examineOnly = false;
							showingGUI = 8;
							ShowExamineGUI();
						}
					} else {
						showingGUI = 8;
						ShowExamineGUI();
					}
					break;
				case 7://tomb
					HideAllGUI();
					MoveTo(newPlayerX, newPlayerY);
					CancelUsed();
					break;
				case 8://collectable
					MoveTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					CancelUsed();
					CollectItem(newPlayerX, newPlayerY);
					hideWait = 2.5f;
					break;
				case 9://fishing spot
					if (!Adjacent(newPlayerX, newPlayerY))
						MoveNextTo(newPlayerX, newPlayerY);
					if (PlayerProfile.health <= 0)
						return;
					CancelUsed();
					itemScript = tileClicked.GetComponentInChildren<Item>();
					isFishing = true;
					CheckItemsCarried();
					if (PlayerProfile.optionAutoCollect) {
						if (itemsCarried < 4 && !hasBelt || itemsCarried < 6 && hasBelt)
							TakeItem();
					} else {
						if (itemsCarried < 4 && !hasBelt || itemsCarried < 6 && hasBelt) {
							GetComponent<AudioSource>().PlayOneShot(fishSound);
							ShowItemGUI();
							ShowPairGUI();
						} else {
							showingGUI = 1;
							ShowExamineGUI();
						}
					}
					break;
				default://something else
					GetComponent<AudioSource>().PlayOneShot(noSound);
					CancelUsed();
					break;
				}
				playerMoved = true;
				examineOnly = false;
			}
		}
				
	}

	//-------------//
	// Cancel Used //
	//-------------//

	void CancelUsed () {
		
		usingItemFromSlot = -1;
		usingSpellFromSlot = -1;
		
	}

	//---------------------//
	// Player Strike First //
	//---------------------//

	bool PlayerStrikeFirst () {

		//enemy with first strike ability
		if (enemyScript.firstStrike)
			return false;

		//player used item or spell
		if (nextHitFirst) {
			nextHitFirst = false;
			return true;
		}
		
		//enemy same or higher level
		if (enemyScript.level >= PlayerProfile.currentLevel)
			return false;
		
		//player is a higher level
		return true;
					
	}

	//------------------//
	// Player Hit Enemy //
	//------------------//

	int PlayerHitEnemy (int playerAttack, bool retaliate, bool magical = false) {

		//reset
		damageDealt = 0;
		
		ActivateBoons();
		
		//deduct health
		if (enemyScript.evade > Random.Range(0, 11) && !magical) {
			CreateMessage("You missed!");
			GetComponent<AudioSource>().PlayOneShot(missedSound);
		} else {
			if (magical)
				damageDealt = (int)Mathf.Ceil(playerAttack * (1.0f - enemyScript.magicalResist));
			else
				damageDealt = (int)Mathf.Ceil(playerAttack * (1.0f - enemyScript.physicalResist));
			damageDealt = Mathf.Clamp(damageDealt, 1, 1000);
			if (enemyScript.level < 10)
				CreateMessage("You hit the " + enemyScript.enemyName + " (LVL " + enemyScript.level + ")" + ", dealing " + damageDealt + " damage!");
			else
				CreateMessage("You hit " + GenerateName.firstName + " " + GenerateName.lastName + ", dealing " + damageDealt + " damage!");
			enemyScript.ChangeHealth(-damageDealt);
			if (!magical)
				GetComponent<AudioSource>().PlayOneShot(fightSounds[Random.Range(0, maxFightSounds)]);
		}
		
		DeActivateBoons();
				
		//enemy was killed
		if (enemyScript.health <= 0) {
			enemyKilled++;
			if (enemyScript.level != 10)
				CreateMessage("You have defeated the " + enemyScript.enemyName + " (LVL " + enemyScript.level + ")!");
			else
				CreateMessage("You have defeated " + GenerateName.firstName + " " + GenerateName.lastName + "!");
			//death protect
			if (enemyScript.deathProtect > 0) {
				enemyScript.health = 1;
				enemyScript.deathProtect -= 1;
				enemyScript.ChangeHealth(0);
				if (enemyScript.level < 10)
					CreateMessage("The " + enemyScript.enemyName + " has come back to life!");
				else
					CreateMessage(GenerateName.firstName + " " + GenerateName.lastName + " has come back to life!");
				EnemyHitPlayer(false);
			} else {
				//level 10 defeated, game over
				if (enemyScript.level == 10) {
					PlayerProfile.IncreaseComplete();
					GetComponent<AudioSource>().PlayOneShot(cheerSound);
					ShowStatsGUI();
				}
				//make tombstone
				CreateTomb();
				//make gold
				if (Random.Range(0, 3) == 0)
					CreateGold(newPlayerX, newPlayerY);
				//gain exp
				if (enemyScript.level > PlayerProfile.currentLevel)
					expBonus = Mathf.Abs(PlayerProfile.currentLevel - enemyScript.level);
				else
					expBonus = 0;
				//update player
				PlayerProfile.expGained = (expBonus * (expBonus + 1)) + enemyScript.level;
				if (PlayerProfile.expGained == 1)
					CreateMessage("You have gained 1 experience point.");
				else
					CreateMessage("You have gained " + PlayerProfile.expGained + " experience points.");
				PlayerProfile.UpdateStats();
				//delete enemy
				Destroy(enemyScript.gameObject);
				SetHold(newPlayerX, newPlayerY, 7);
			}
		} else {
			//hit back
			if (retaliate)
				EnemyHitPlayer(false);
		}
		
		return damageDealt;
		
	}

	//------------------//
	// Enemy Hit Player //
	//------------------//
	
	void EnemyHitPlayer (bool retaliate) {
		
		//reset
		damageDealt = 0;
		
		ActivateBoons();
		
		//deduct health
		if (PlayerProfile.evade > Random.Range(0, 11)) {
			if (enemyScript.level < 10)
				CreateMessage("The " + enemyScript.enemyName + " missed!");
			else
				CreateMessage(GenerateName.firstName + " " + GenerateName.lastName + " missed!");
		} else {		
			if (enemyScript.magicalAttack)
				damageDealt = (int)Mathf.Ceil(enemyScript.attack * (1.0f - PlayerProfile.magicalResist));
			else
				damageDealt = (int)Mathf.Ceil(enemyScript.attack * (1.0f - PlayerProfile.physicalResist));
			damageDealt = Mathf.Clamp(damageDealt, 1, 1000);
			if (enemyScript.level < 10)
				CreateMessage("The " + enemyScript.enemyName + " (LVL " + enemyScript.level + ")" + " hit you, dealing " + damageDealt + " damage!");
			else
				CreateMessage(GenerateName.firstName + " " + GenerateName.lastName + " hit you, dealing " + damageDealt + " damage!");
			PlayerProfile.health -= damageDealt;
	    }
		
		DeActivateBoons();
		
		//player was killed
		if (PlayerProfile.health <= 0) {
			if (deathProtect) {
				GetComponent<AudioSource>().PlayOneShot(backToLifeSound);
				PlayerProfile.health = 1;
				deathProtect = false;
				CreateMessage("You died and were brought back to life!");
				PlayerHitEnemy(PlayerProfile.attack, false);
			} else {
				GetComponent<AudioSource>().PlayOneShot(deathSound);
				if (enemyScript.level < 10)
					CreateMessage("You were killed by the " + enemyScript.enemyName + " (LVL " + enemyScript.level + ")" + "!");
				else
					CreateMessage("You were killed by " + GenerateName.firstName + " " + GenerateName.lastName + "!");
				ShowGameOverGUI();
				CreateTomb(true);
			}
		} else {
			//hit back
			if (retaliate)
				PlayerHitEnemy(PlayerProfile.attack, false);
		}
			
	}

	//----------------//
	// Activate Boons //
	//----------------//

	void ActivateBoons () {
		
		//add
		PlayerProfile.attack += nextAttackBonus;
		PlayerProfile.physicalResist += nextDefenceBonus;
		PlayerProfile.magicalResist += nextDefenceBonus;
		PlayerProfile.evade += nextAvoidBonus;
		
		//adjust for horse
		if (hasHorse) {
			PlayerProfile.attack += PlayerProfile.currentLevel;
			PlayerProfile.physicalResist += 0.15f;
		}
		
	}

	//------------------//
	// DeActivate Boons //
	//------------------//

	void DeActivateBoons () {
		
		//deduct
		PlayerProfile.attack -= nextAttackBonus;
		PlayerProfile.physicalResist -= nextDefenceBonus;
		PlayerProfile.magicalResist -= nextDefenceBonus;
		PlayerProfile.evade -= nextAvoidBonus;
		
		//zero bonus'
		nextAttackBonus = 0;
		nextDefenceBonus = 0;
		nextAvoidBonus = 0;
		nextHitFirst = false;
		
		//adjust for horse
		if (hasHorse) {
			PlayerProfile.attack -= PlayerProfile.currentLevel;
			PlayerProfile.physicalResist -= 0.15f;
		}
		
	}

	//-------------//
	// Adjust Bars //
	//-------------//

	void AdjustBars () {
		
		PlayerProfile.health = Mathf.Clamp(PlayerProfile.health, 0, PlayerProfile.maxHealth);
		PlayerProfile.mana = Mathf.Clamp(PlayerProfile.mana, 0, PlayerProfile.maxMana);
		PlayerProfile.food = Mathf.Clamp(PlayerProfile.food, 0, 20);
		
		expPercent = ((PlayerProfile.exp - PlayerProfile.lastLevel) / (PlayerProfile.nextLevel - PlayerProfile.lastLevel));
		healthPercent = (PlayerProfile.health / PlayerProfile.maxHealth);
		manaPercent = (PlayerProfile.mana / PlayerProfile.maxMana);
		foodPercent = (PlayerProfile.food / 20);
		
		playerMaxExpBar.transform.localScale = new Vector3(0.65f + 0.05f, 0.1f + 0.05f, 1);
		playerExpBar.transform.localScale = new Vector3(expPercent * 0.65f, 0.1f, 1);
		playerMaxHealthBar.transform.localScale = new Vector3(0.65f + 0.05f, 0.1f + 0.05f, 1);
		playerHealthBar.transform.localScale = new Vector3(healthPercent * 0.65f, 0.1f, 1);
		playerMaxManaBar.transform.localScale = new Vector3(0.65f + 0.05f, 0.1f + 0.05f, 1);
		playerManaBar.transform.localScale = new Vector3(manaPercent * 0.65f, 0.1f, 1);
		playerMaxEngBar.transform.localScale = new Vector3(0.35f + 0.05f, 0.1f + 0.05f, 1);
		playerEngBar.transform.localScale = new Vector3(foodPercent * 0.35f, 0.1f, 1);
		
	}

	//-----------//
	// Test Move //
	//-----------//

	bool TestMove (int x, int y) {
	
		if (scriptArray[x, y].holding == 0 && scriptArray[x, y].visible) {
			MoveTo(x, y);
			return true;
		} else
			return false;
		
	}

	//----------//
	// Adjacent //
	//----------//

	bool Adjacent (int x, int y) {
		
		count = 0;
		CalculateOffset(x);
		
		if (PlayerProfile.currentX == x && PlayerProfile.currentY == y)
			return true;
		
		while (count < 6) {
			count++;
			if (count == 1) {
				if (PlayerProfile.currentX == x && PlayerProfile.currentY == y-1)
					return true;
			}
			if (count == 2) {
				if (PlayerProfile.currentX == x && PlayerProfile.currentY == y+1)
					return true;
			}
			if (count == 5) {
				if (PlayerProfile.currentX == x-1 && PlayerProfile.currentY == y)
					return true;
			}
			if (count == 6) {
				if (PlayerProfile.currentX == x+1 && PlayerProfile.currentY == y)
					return true;
			}
			if (offset == 1) {
				if (count == 3) {
					if (PlayerProfile.currentX == x-1 && PlayerProfile.currentY == y+1)
						return true;
				}
				if (count == 4) {
					if (PlayerProfile.currentX == x+1 && PlayerProfile.currentY == y+1)
						return true;
				}
			} else {
				if (count == 3) {
					if (PlayerProfile.currentX == x-1 && PlayerProfile.currentY == y-1)
						return true;
				}
				if (count == 4) {
					if (PlayerProfile.currentX == x+1 && PlayerProfile.currentY == y-1)
						return true;
				}
			}
		}		
		
		return false;
		
	}

	//---------//
	// Move To //
	//---------//

	void MoveTo (int x, int y) {

		//don't move to same tile
		if (x == PlayerProfile.currentX && y == PlayerProfile.currentY)
			return;

		//resize castle
		if (scriptArray[x, y].holding != 2) {
			if (!resized) {
				thisCastle.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				resized = true;
			}
		} else
			thisCastle.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		//offset
		CalculateOffset(x);
		
		//move
		playerChar.transform.position = new Vector3(x * 1.5f , 0.75f, y * 1.7324f + (2 * offset));
		rainParticles.position = playerChar.transform.position + Vector3.up * 5;
		PlayerProfile.lastX = PlayerProfile.currentX;
        PlayerProfile.lastY = PlayerProfile.currentY;
        PlayerProfile.currentX = x;
		PlayerProfile.currentY = y;
		movesMade++;
		
		//visible area
		CalculateVisible();

		//food
		if (PlayerProfile.lastX != PlayerProfile.currentX || PlayerProfile.lastY != PlayerProfile.currentY)
			DeductFood();
		
		//sound
		GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
		GetComponent<AudioSource>().PlayOneShot(moveSound);
		GetComponent<AudioSource>().pitch = 1.0f;
		
	}

	//--------------//
	// Move Next To //
	//--------------//

	void MoveNextTo (int x, int y) {
				
		SX = PlayerProfile.currentX;
		SY = PlayerProfile.currentY;
		count = 0;
		
		CalculateOffset(x);
		
		if (SY > y) {
			if (SX < x) {
				if (offset == 1)
					side = 2;
				else
					side = 4;
			} else if (SX > x) {
				if (offset == 1)
					side = 3;
				else
					side = 5;
			} else
				side = 1;
		} else {
			if (SX < x) {
				if (offset == 1)
					side = 4;
				else
					side = 2;
			} else if (SX > x) {
				if (offset == 1)
					side = 5;
				else
					side = 3;
			} else
				side = 0;
		}
		
		while (count < 6) {
			count++;
			side++;
			if (side > 6)
				side = 1;
			if (side == 1) {
				if (TestMove(x, y-1))
					break;
			}
			if (side == 2) {
				if (TestMove(x, y+1))
					break;
			}
			if (side == 5) {
				if (TestMove(x-1, y))
					break;
			}
			if (side == 6) {
				if (TestMove(x+1, y))
					break;
			}
			if (offset == 1) {
				if (side == 3) {
					if (TestMove(x-1, y+1))
						break;
				}
				if (side == 4) {
					if (TestMove(x+1, y+1))
						break;
				}
			} else {
				if (side == 3) {
					if (TestMove(x-1, y-1))
						break;
				}
				if (side == 4) {
					if (TestMove(x+1, y-1))
						break;
				}
			}
		}
		
	}

	//-------------//
	// Deduct Food //
	//-------------//

	void DeductFood () {
		
		foodCounter++;
		
		if (hasHorse && foodCounter >= 5 || !hasHorse && foodCounter > 3) {
			if (PlayerProfile.food > 0)
				PlayerProfile.food--;
			else {
				GetComponent<AudioSource>().PlayOneShot(deathSound);
				PlayerProfile.health = 0;
				ShowGameOverGUI();
				CreateTomb(true);
			}
			foodCounter = 0;
		}
		
		AdjustBars();
		
	}

	//--------------//
	// Collect Item //
	//--------------//

	void CollectItem (int x, int y) {
		
		switch(scriptArray[x, y].collectable) {
		case 1:
			foundText = "Found a Demon Claw";
			PlayerProfile.demonClaw++;
			break;
		case 2:
			foundText = "Found an Eagle Feather";
			PlayerProfile.eagleFeather++;
			break;
		case 3:
			foundText = "Found a Unicorn Horn";
			PlayerProfile.unicornHorn++;
			break;
		case 4:
			foundText = "Found an Orchid";
			PlayerProfile.orchid++;
			break;
		case 5:
			foundText = "Found a Dragon Scale";
			PlayerProfile.dragonScale++;
			break;				
		}
		
		if (scriptArray[x, y].collectable > 0) {
			ShowExamineGUI();
			SetHold(x, y, 0);
			showingGUI = 13;
			scriptArray[x, y].collectable = 0;
		}
		
		CreateMessage(foundText);
		
	}

	//-----------//
	// Take Item //
	//-----------//

	void TakeItem (bool fromShop = false) {
		
		//hide all gui
		if (!fromShop)
			HideAllGUI();
		
		if (itemScript.name == "Belt") {
			EquipBelt();
			return;
		}
		
		if (itemScript.name == "Horse") {
			EquipHorse();
			return;
		}
		
		//is player wearing a belt?
		maxItems = 4;
		if (hasBelt)
			maxItems = 6;

		//add qty if player already has item
		taken = false;
		for (count = 0 ; count < maxItems ; count++) {
			if (inventory[count]) {
				if (inventoryScript[count].itemName == itemScript.itemName) {
					if (!fromShop) {
						inventoryScript[count].qty += itemScript.qty;
						Destroy(itemScript.gameObject);
					} else
						inventoryScript[count].qty++;
					taken = true;
				}
			}
		}
				
		//give item to player
		if (!taken) {
			for (count = 0 ; count < maxItems ; count++) {
				if (!inventory[count]) {
					//reuse object if collecting, make new if bought
					if (fromShop)
						inventory[count] = Instantiate(itemScript.gameObject) as GameObject;
					else
						inventory[count] = itemScript.gameObject;
					//move item into inventory
					inventory[count].layer = 8;
					inventory[count].tag = "Inventory";
					inventoryScript[count] = inventory[count].GetComponent<Item>();
					inventoryScript[count].myTransform.position = playerInventory.position;
					inventoryScript[count].myTransform.rotation = playerInventory.rotation;
					inventoryScript[count].myTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
					inventoryScript[count].myTransform.parent = playerInventory.Find("Slot" + count);
					inventoryScript[count].collected = true;
					//position in correct slot
					switch (count) {
					case 0:
						inventoryScript[count].transform.Translate(new Vector3(-0.3f, -0.07f, 0.25f));
						break;
					case 1:
						inventoryScript[count].transform.Translate(new Vector3(0.5f, -0.07f, 0.25f));
						break;
					case 2:
						inventoryScript[count].transform.Translate(new Vector3(-0.3f, 0.75f, 0.25f));
						break;
					case 3:
						inventoryScript[count].transform.Translate(new Vector3(0.5f, 0.75f, 0.25f));
						break;
					case 4:
						inventoryScript[count].transform.Translate(new Vector3(-0.3f, 1.75f, 0.25f));
						break;
					case 5:
						inventoryScript[count].transform.Translate(new Vector3(0.5f, 1.75f, 0.25f));
						break;
					}
					//fix rotation
					inventoryScript[count].transform.Rotate(Vector3.left * 270);
					break;
				}
			}
		}

		//clear tile
		if (!isFishing) {
			if (!fromShop)
				SetHold(PlayerProfile.currentX, PlayerProfile.currentY, 0);
		} else
			SetHold(newPlayerX, newPlayerY, 10);
		isFishing = false;
		
		//update quest journal
		if (!fromShop)
			CreateMessage("You take the " + itemScript.examineName + ".");
		else
			CreateMessage("You have bought a " + itemScript.examineName + ".");
		
		//sound
		GetComponent<AudioSource>().PlayOneShot(itemSound);
		onOffInventory.Open();
			
	}

	//---------------//
	// Process Event //
	//---------------//

	void ProcessEvent () {
		
		//play chest open animation
		chestScript.gameObject.GetComponent<Animation>().Play();
		
		switch(chestScript.eventName) {
		case "Empty" : case "Spiders" :
			break;
		case "Magic" :
			PlayerProfile.health = PlayerProfile.maxHealth;
			PlayerProfile.mana = PlayerProfile.maxMana;
			PlayerProfile.food = 20;
			break;
		case "Ambush" :
			PlayerProfile.gold = 0;
			break;
		case "Locked" :
			PlayerProfile.expGained = PlayerProfile.currentLevel;
			if (PlayerProfile.expGained == 1)
				CreateMessage("You have gained 1 experience point.");
			else
				CreateMessage("You have gained " + PlayerProfile.expGained + " experience points.");
			PlayerProfile.UpdateStats();
			break;
		case "Trap" :
			PlayerProfile.health = 1;
			break;
		case "Gold" :
			PlayerProfile.gold += Random.Range(50, 100);
			break;
		}
		
		CreateMessage("You open the chest.");
		chestScript.opened = true;
		ShowEventGUI();
		AdjustBars();
		
	}

	//---------------------//
	// Check Items Carried //
	//---------------------//

	void CheckItemsCarried () {
		
		//reset counter
		itemsCarried = 0;

		//is player wearing a belt?
		maxItems = 4;
		if (hasBelt)
			maxItems = 6;
		
		//count items in inventory
		for (count = 0 ; count < maxItems ; count++) {
			if (inventory[count]) {
				if (inventoryScript[count].itemName != itemScript.itemName)
					itemsCarried++;
			}
		}
		
	}

	//----------------------//
	// Check Spells Carried //
	//----------------------//

	void CheckSpellsCarried () {
		
		//reset counter
		spellsCarried = 0;
		
		//count spells in spellbook
		for (count = 0 ; count < 4 ; count++) {
			if (spellbook[count]) {
				spellsCarried++;
			}
		}
		
	}
		
	//-------------//
	// Learn Spell //
	//-------------//

	void LearnSpell () {
		
		//hide all gui
		HideAllGUI();
		
		//give spell to player
		for (count = 0 ; count < 4 ; count++) {
			if (!spellbook[count]) {
				//move item into spellbook
				spellbook[count] = spellScript.gameObject;
				spellbook[count].tag = "Inventory";
				spellbook[count].transform.Find("Image").gameObject.layer = 8;
				spellbookScript[count] = spellbook[count].GetComponent<Spell>();
				spellbookScript[count].myTransform.position = playerSpellbook.position;
				spellbookScript[count].myTransform.rotation = playerSpellbook.rotation;
				spellbookScript[count].myTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
				spellbookScript[count].myTransform.parent = playerSpellbook.Find("Slot" + count);
				spellbookScript[count].collected = true;
				//position in correct slot
				switch (count) {
				case 0:
					spellbookScript[count].transform.Translate(new Vector3(-0.475f, 0.25f, -0.05f));
					break;
				case 1:
					spellbookScript[count].transform.Translate(new Vector3(-0.475f, 1, -0.05f));
					break;
				case 2:
					spellbookScript[count].transform.Translate(new Vector3(0.45f, 0.25f, -0.05f));
					break;
				case 3:
					spellbookScript[count].transform.Translate(new Vector3(0.45f, 1, -0.05f));
					break;
				}
				//fix rotation
				spellbookScript[count].transform.Rotate(Vector3.left * 270);
				break;
			}
		}
		
		//clear tile and update quest journal
		SetHold(PlayerProfile.currentX, PlayerProfile.currentY, 0);
		CreateMessage("You learn the spell of " + spellScript.examineName + ".");
		GetComponent<AudioSource>().PlayOneShot(learnSound);
		onOffBook.Open();
		
	}

	//------------//
	// Equip Belt //
	//------------//

	void EquipBelt () {
				
		hasBelt = true;
		playersBelt.gameObject.SetActive(true);
		
	}

	//-------------//
	// Equip Horse //
	//-------------//

	void EquipHorse () {
		
		hasHorse = true;
		HidePlayer();
		playerCharHorse.SetActive(true);
		GetComponent<AudioSource>().PlayOneShot(horseSound);
		
	}

	//-------------//
	// Hide Player //
	//-------------//

	void HidePlayer () {
	
		playerChar.transform.Find("Tube").gameObject.SetActive(false);
		playerChar.transform.Find("Tube_001").gameObject.SetActive(false);
		
	}

	//------------//
	// Cast Spell //
	//------------//

	void CastSpell (int slot) {
		
		//no double clicking
		useDelay = 0.1f;
		
		//cast spell
		if (PlayerProfile.mana >= spellbookScript[slot].manaCost) {
			usingSpell = true;
			switch(spellbookScript[slot].spellName) {
			case "Fireball" :
				GetComponent<AudioSource>().PlayOneShot(prepSound);
				break;
			case "Full Cure":
				deathProtect = true;
				PlayerProfile.health = PlayerProfile.maxHealth;
				PlayerProfile.food = 20;
				AdjustBars();
				usingSpell = false;
				GetComponent<AudioSource>().PlayOneShot(spellCureSound);
				break;
			case "Healing":
				PlayerProfile.health += (int)Mathf.Ceil(PlayerProfile.maxHealth * 0.5f);
				usingSpell = false;
				GetComponent<AudioSource>().PlayOneShot(spellHealSound);
				break;
			case "Power":
				nextHitFirst = true;
				nextDefenceBonus = 0.5f;//50% less damage
				nextAttackBonus = PlayerProfile.currentLevel * 3;//extra damage
				nextAvoidBonus = 5;//avoid 50%
				usingSpell = false;
				GetComponent<AudioSource>().PlayOneShot(spellPowerSound);
				break;
			}
			if (usingSpell) {
				usingSpellFromSlot = slot;
				CreateMessage("You prepare to cast the spell of " + spellbookScript[slot].examineName + "!");
			} else {
				PlayerProfile.mana -= spellbookScript[slot].manaCost;
				CreateMessage("You cast the spell of " + spellbookScript[slot].examineName + "!");
			}
		} else {
			CreateMessage("Not enough mana to cast the spell of " + spellbookScript[slot].examineName + "!");
			GetComponent<AudioSource>().PlayOneShot(noSound);
		}
		
	}

	//--------------//
	// Check Ground //
	//--------------//

	void CheckGround () {
		
		SX = scriptArray[PlayerProfile.currentX, PlayerProfile.currentY].holding;
		
		if (showingGUI > 0) {
			examineOnly = true;
			playerMoved = false;
			newPlayerX = PlayerProfile.currentX;
			newPlayerY = PlayerProfile.currentY;
		} else
			playerMoved = true;

	}

	//---------------//
	// Play Level Up //
	//---------------//

	public void PlayLevelUp () {
	
		GetComponent<AudioSource>().PlayOneShot(levelUpSound);
		
	}

	//-----------//
	// Use Spell //
	//-----------//

	public void UseSpell (int slot) {
	
		//clicked on an empty slot
		if (!spellbookScript[slot] || useDelay > 0.0f)
			return;
		
		//reset
		CancelUsed();

		//use spell
		CastSpell(slot);
	
		//update stat bars
		AdjustBars();
		
	}

	//----------//
	// Use Item //
	//----------//

	public void UseItem (int slot) {

		//clicked on an empty slot
		if (!inventoryScript[slot] || useDelay > 0.0f)
			return;
		
		//reset
		CancelUsed();
		showMessage = 0;

		//use item
		switch(inventoryScript[slot].itemName) {
		case "Small Health Potion":
			PlayerProfile.health += (int)Mathf.Ceil(PlayerProfile.maxHealth * 0.25f);
			GetComponent<AudioSource>().PlayOneShot(potionSound);
			showMessage = 3;
			break;
		case "Large Health Potion":
			PlayerProfile.health = PlayerProfile.maxHealth;
			GetComponent<AudioSource>().PlayOneShot(potionSound);
			showMessage = 3;
			break;
		case "Small Mana Potion":
			PlayerProfile.mana += (int)Mathf.Ceil(PlayerProfile.maxMana * 0.25f);
			GetComponent<AudioSource>().PlayOneShot(potionSound);
			showMessage = 3;
			break;
		case "Large Mana Potion":
			PlayerProfile.mana = PlayerProfile.maxMana;
			GetComponent<AudioSource>().PlayOneShot(potionSound);
			showMessage = 3;
			break;
		case "Small Elixer":
			PlayerProfile.healthBonus += 1;
			PlayerProfile.manaBonus += 1;
			PlayerProfile.attackBonus += 1;
			PlayerProfile.magicAttackBonus += 1;
			PlayerProfile.magicalResist += 0.05f;
			PlayerProfile.physicalResist += 0.05f;
			PlayerProfile.evade += 1;
			PlayerProfile.RefreshStats();
			PlayerProfile.health += (int)Mathf.Ceil(PlayerProfile.maxHealth * 0.25f);
			PlayerProfile.mana += (int)Mathf.Ceil(PlayerProfile.maxMana * 0.25f);
			GetComponent<AudioSource>().PlayOneShot(potionSound);
			showMessage = 3;
			break;
		case "Large Elixer":
			PlayerProfile.healthBonus += 5;
			PlayerProfile.manaBonus += 5;
			PlayerProfile.attackBonus += 2;
			PlayerProfile.magicAttackBonus += 2;
			PlayerProfile.magicalResist += 0.1f;
			PlayerProfile.physicalResist += 0.1f;
			PlayerProfile.evade += 1;
			PlayerProfile.RefreshStats();
			PlayerProfile.health = PlayerProfile.maxHealth;
			PlayerProfile.mana = PlayerProfile.maxMana;
			GetComponent<AudioSource>().PlayOneShot(potionSound);
			showMessage = 3;
			break;
		case "Tent":
			AdvanceTime(false);
			break;
		case "Throwing Knife":
			usingItemFromSlot = slot;
			GetComponent<AudioSource>().PlayOneShot(equipSound);
			break;
		case "Wand of Fireball":
			usingItemFromSlot = slot;
			GetComponent<AudioSource>().PlayOneShot(prepSound);
			break;
		case "Wand of Full Cure":
			deathProtect = true;
			PlayerProfile.health = PlayerProfile.maxHealth;
			PlayerProfile.mana = PlayerProfile.maxMana;
			PlayerProfile.food = 20;
			GetComponent<AudioSource>().PlayOneShot(spellCureSound);
			break;
		case "Wand of Healing":
			PlayerProfile.health += (int)Mathf.Ceil(PlayerProfile.maxHealth * 0.5f);
			GetComponent<AudioSource>().PlayOneShot(spellHealSound);
			break;
		case "Wand of Power":
			nextHitFirst = true;
			nextDefenceBonus = 0.5f;//50% less damage
			nextAttackBonus = PlayerProfile.currentLevel * 3;//extra damage
			nextAvoidBonus = 5;//avoid 50%
			GetComponent<AudioSource>().PlayOneShot(spellPowerSound);
			break;
		case "Phoenix Plume":
			deathProtect = true;
			GetComponent<AudioSource>().PlayOneShot(phoenixSound);
			break;
		case "Wild Mushroom":
			PlayerProfile.food += 5;
			PlayerProfile.health = PlayerProfile.maxHealth;
			PlayerProfile.mana = PlayerProfile.maxMana;
			deathProtect = true;
			nextHitFirst = true;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(foodSound);
			break;
		case "Weird Fungi":
			PlayerProfile.food += 5;
			nextDefenceBonus = 0.5f;
			nextAvoidBonus = 5;
			nextAttackBonus = 10;
			nextDefenceBonus = 10;
			nextHitFirst = true;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(foodSound);
			break;
		case "Hunk of Meat":
			PlayerProfile.food += 15;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(foodSound);
			break;
		case "Cheese":
			PlayerProfile.food += 5;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(foodSound);
			break;
		case "Loaf of Bread":
			PlayerProfile.food += 20;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(foodSound);
			break;
		case "Apple":
			PlayerProfile.food += 5;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(foodSound);
			break;			
		case "Map":
			RevealMap();
			GetComponent<AudioSource>().PlayOneShot(mapSound);
			break;
		case "Boot" : case "Wheel" :
			GetComponent<AudioSource>().PlayOneShot(discardSound);
			showMessage = 2;
			break;
		case "Black Custard" :
			PlayerProfile.food = 1;
			PlayerProfile.health = 1;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(sickSound);
			break;
		case "Witches' Brew" :
			PlayerProfile.food = 1;
			PlayerProfile.health = 1;
			showMessage = 3;
			GetComponent<AudioSource>().PlayOneShot(sickSound);
			break;
		case "Penny" :
			GetComponent<AudioSource>().PlayOneShot(discardSound);
			showMessage = 2;
			break;
		case "Fish" :
			PlayerProfile.food += 20;
			showMessage = 1;
			GetComponent<AudioSource>().PlayOneShot(foodSound);
			break;
		}

		//deduct used item now
		if (usingItemFromSlot < 0) {
			if (inventoryScript[slot].qty > 1) {
				switch(showMessage) {
				case 0 :
					CreateMessage("You use a " + inventoryScript[slot].examineName + ".");
					break;
				case 1 :
					CreateMessage("You eat a " + inventoryScript[slot].examineName + ".");
					break;
				case 2 :
					CreateMessage("You discard a " + inventoryScript[slot].examineName + ".");
					break;
				case 3 :
					CreateMessage("You drink a " + inventoryScript[slot].examineName + ".");
					break;
				}					
			} else {
				switch(showMessage) {
				case 0 :
					CreateMessage("You use the " + inventoryScript[slot].examineName + ".");
					break;
				case 1 :
					CreateMessage("You eat the " + inventoryScript[slot].examineName + ".");
					break;
				case 2 :
					CreateMessage("You discard the " + inventoryScript[slot].examineName + ".");
					break;
				case 3 :
					CreateMessage("You drink the " + inventoryScript[slot].examineName + ".");
					break;
				}
			}
			DeductItem(slot);
		} else {
			useDelay = 0.1f;
			if (inventoryScript[slot].qty > 1)
				CreateMessage("Preparing to use a " + inventoryScript[slot].examineName + ".");
			else
				CreateMessage("Preparing to use the " + inventoryScript[slot].examineName + ".");
		}
		
		//update stat bars
		AdjustBars();
						
	}

	//-------------//
	// Deduct Item //
	//-------------//

	void DeductItem (int slot) {
	
		//no double clicking
		useDelay = 0.1f;
		
		//items with multiple uses
		inventoryScript[slot].qty -= 1;
				
		//remove item from inventory
		if (inventoryScript[slot].qty <= 0) {
			DestroyImmediate(inventory[slot]);
			CheckGround();
		}
				
	}

	//------------//
	// Reveal Map //
	//------------//

	void RevealMap () {
		
		for (SX = 0 ; SX < size ; SX++) {
			for (SY = 0 ; SY < size ; SY++) {
				SetVisible(SX, SY, true);
			}
		}
		CalculateVisible();
		
	}

	//--------------//
	// Advance Time //
	//--------------//

	void AdvanceTime (bool inCastle = false) {
	
		CreateMessage("Time passes...");
			
		//fade out
		CameraControl.loadLevel = true;
		CameraControl.wait = 3.0f;
		switchIn = 3.0f;
		switchedDay = false;
		sleepInCastle = inCastle;
		
		//sound
		GetComponent<AudioSource>().PlayOneShot(snoreSound);
		
	}

	//---------------//
	// Update Camera //
	//---------------//

	void UpdateCamera (bool firstTime = false) {
	
		if (!firstTime) {
			GenerateMap(true);
			CalculateVisible();
			PlayerProfile.health += (int)Mathf.Ceil(PlayerProfile.maxHealth * 0.25f);
			PlayerProfile.mana += (int)Mathf.Ceil(PlayerProfile.maxMana * 0.25f);
			PlayerProfile.food += 5;
			playerMoved = false;
			bossScript.health = bossScript.maxHealth;
			AdjustBars();
			dayTime = -dayTime;
			switchedDay = true;
		}
	
		//ambient sound loops
		if (dayTime == 1) {
			dayAmbient.SetActive(true);
			nightAmbient.SetActive(false);
		} else {
			dayAmbient.SetActive(false);
			nightAmbient.SetActive(true);
		}
		
		//weather
		drizzle = Random.Range(0, 5);
		stormTime = Random.Range(10.0f, 120.0f);
		lightTime = Random.Range(0.1f, 0.5f);
		particles.emissionRate = drizzle * 4;
		if (drizzle > 2) {
			rainAmbient.SetActive(true);
			rainParticles.eulerAngles = new Vector3(Random.Range(275.0f, 290.0f), 0.0f, Random.Range(-10.0f, 10.0f));
		} else
			rainAmbient.SetActive(false);

		//robbed
		if (!sleepInCastle) {
			if (Random.Range(0, 10) == 0) {
				PlayerProfile.gold = 0;
				ShowEventGUI();
				showingGUI = 12;
				CreateMessage("You have been robbed!");
				playerMoved = true;
			}
		}
		
		//camera
		if (dayTime == 1) {
			mainCamera.backgroundColor = dayColour;
			RenderSettings.fogEndDistance = 20.0f;
			RenderSettings.fogColor = dayColour;
			RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f, 0.8f);
		} else {
			mainCamera.backgroundColor = nightColour;
			RenderSettings.fogEndDistance = 10.0f;
			RenderSettings.fogColor = nightColour;
			RenderSettings.ambientLight = new Color(0.6f, 0.6f, 0.6f, 1.0f);
		}
		
	}
	
	//------------------//
	// Show Examine GUI //
	//------------------//
		
	void ShowExamineGUI () {
		
		examineGUI.SetActive(true);
		
	}

	//---------------//
	// Show Pair GUI //
	//---------------//

	void ShowPairGUI () {
		
		pairGUI.SetActive(true);
		
	}
		
	//---------------//
	// Show Item GUI //
	//---------------//

	void ShowItemGUI () {
		
		HideAllGUI();
		showingGUI = 1;
		itemGUI.SetActive(true);
		fadeGUI.SetActive(true);
		
	}

	//---------------//
	// Show Shop GUI //
	//---------------//

	void ShowShopGUI () {
	
		HideAllGUI();
		ShowPairGUI();
		showingGUI = 2;
		shopGUI.SetActive(true);
		fadeGUI.SetActive(true);
		
	}
		
	//----------------//
	// Show Spell GUI //
	//----------------//

	void ShowSpellGUI () {
	
		HideAllGUI();
		showingGUI = 3;
		itemGUI.SetActive(true);
		fadeGUI.SetActive(true);
		
	}
		
	//----------------//
	// Show Chest GUI //
	//----------------//

	void ShowChestGUI () {
	
		HideAllGUI();
		showingGUI = 4;
		itemGUI.SetActive(true);
		fadeGUI.SetActive(true);

		if (!chestScript.opened)
			pairGUI.SetActive(true);
		else
			examineGUI.SetActive(true);
		
	}

	//----------------//
	// Show Event GUI //
	//----------------//

	void ShowEventGUI () {
	
		HideAllGUI();
		showingGUI = 9;
		itemGUI.SetActive(true);
		examineGUI.SetActive(true);
		fadeGUI.SetActive(true);
		
	}

	//--------------------//
	// Show Game Over GUI //
	//--------------------//

	void ShowGameOverGUI () {
		
		HideAllGUI();
		overWait = 5.0f;
		showingGUI = 10;
		overGUI.SetActive(true);
		fadeGUI.SetActive(true);
		
	}

	//----------------//
	// Show Stats GUI //
	//----------------//

	void ShowStatsGUI () {
		
		HideAllGUI();
		showingGUI = 11;
		itemGUI.SetActive(true);
		examineGUI.SetActive(true);
		fadeGUI.SetActive(true);
		gameIsOver = true;
		
	}

	//--------------//
	// Hide All GUI //
	//--------------//

	void HideAllGUI () {
	
		itemGUI.SetActive(false);
		examineGUI.SetActive(false);
		pairGUI.SetActive(false);
		fadeGUI.SetActive(false);
		overGUI.SetActive(false);
		shopGUI.SetActive(false);
		showingGUI = 0;
		hideWait = 0;
		
	}

	//--------------//
	// Hide Big GUI //
	//--------------//

	void HideBigGUI () {
		
		itemGUI.SetActive(false);
		shopGUI.SetActive(false);
		pairGUI.SetActive(false);
		fadeGUI.SetActive(false);		
		
	}

	//--------//
	// On GUI //
	//--------//

	void OnGUI () {
		
		//Leave at 480 x 320
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1.0f));
		DrawGUI();
		
	}

	//----------//
	// Draw GUI //
	//----------//

	void DrawGUI () {
		
		GUI.color = new Color(1.0f, 1.0f, 1.0f, 1 - CameraControl.currentAlpha);
		
		//quest log		
		if (onOffQuestJournal.isOn) {
			if (showingGUI == 0 || showingGUI == 10)
				clipText = false;
			else
				clipText = true;
			if (clipText)
				GUI.Label(new Rect(2, 274, 115, 14), message01, customGUISmall);
			else
				GUI.Label(new Rect(2, 274, 330, 14), message01, customGUISmall);
			GUI.Label(new Rect(2, 290, 320, 14), message02, customGUISmall);
			GUI.Label(new Rect(2, 306, 320, 14), message03, customGUISmall);
		}

		//players gold
		if (onOffStats.isOn) {
			goldToDraw = PlayerProfile.gold.ToString();
			while(goldToDraw.Length < 5)
				goldToDraw = "0" + goldToDraw;
			GUI.color = new Color(1.0f, 1.0f, 1.0f, (1 - CameraControl.currentAlpha) * 0.75f);
			GUI.Label(new Rect(397, 153, 80, 22), goldToDraw, customGUI);
		}	
		
		//draw qty for items
		if (onOffInventory.isOn) {
			GUI.color = new Color(1.0f, 1.0f, 1.0f, 1 - CameraControl.currentAlpha);
			maxItems = 4;
			if (hasBelt)
				maxItems = 6;
			for (count = 0 ; count < maxItems ; count++) {
				if (inventory[count]) {
					if (inventoryScript[count].qty > 1) {
						switch(count) {
						case 0:
							GUI.Label(new Rect(2, 50, 30, 25), "" + inventoryScript[count].qty, customGUI);
							break;
						case 1:
							GUI.Label(new Rect(70, 50, 30, 25), "" + inventoryScript[count].qty, customGUI);
							break;
						case 2:
							GUI.Label(new Rect(2, 116, 30, 25), "" + inventoryScript[count].qty, customGUI);
							break;
						case 3:
							GUI.Label(new Rect(70, 116, 30, 25), "" + inventoryScript[count].qty, customGUI);
							break;
						case 4:
							GUI.Label(new Rect(2, 190, 30, 25), "" + inventoryScript[count].qty, customGUI);
							break;
						case 5:
							GUI.Label(new Rect(70, 190, 30, 25), "" + inventoryScript[count].qty, customGUI);
							break;
						}
					}
				}
			}
		}
		
		//text over 3d boxes
		switch (showingGUI) {
		case 1://item
			if (itemsCarried < 4 && !hasBelt || itemsCarried < 6 && hasBelt) {
				DrawText(itemScript.itemName, 37);
				DrawText(itemScript.itemDescription, 105, false, 4, -80);
				pairClicked = DrawPair("Take", "Leave", 255);
				if (pairClicked == 1)
					TakeItem();
				if (pairClicked == 2) {
					if (!isFishing) {
						ShowExamineGUI();
						HideBigGUI();
						showingGUI = 5;
					} else
						HideAllGUI();
					GetComponent<AudioSource>().PlayOneShot(menuSound);
					isFishing = false;
				}
			} else
				DrawText("Your inventory is full", 255);
			break;
		case 2://castle shop
			//draw info
			DrawText("Castle", 37);
			GUI.Label(new Rect(140, 132, 60, textHeight * 2), "" + shopItems[0].cost, customGUI);
			GUI.Label(new Rect(240, 130, 60, textHeight * 2), "" + shopItems[1].cost, customGUI);
			GUI.Label(new Rect(310, 132, 60, textHeight * 2), "" + shopItems[2].cost, customGUI);
			GUI.Label(new Rect(230, 202, 60, textHeight * 2), "" + shopItems[4].cost, customGUI);
			GUI.Label(new Rect(150, 198, 60, textHeight * 2), "" + shopItems[3].cost, customGUI);
			GUI.Label(new Rect(315, 198, 60, textHeight * 2), "" + shopItems[5].cost, customGUI);
			pairClicked = DrawPair("Leave", "Rest", 255);
			if (CameraControl.loadLevel)
				return;
			if (pairClicked == 1) {
				HideAllGUI();
				showingGUI = 6;
				ShowExamineGUI();
				GetComponent<AudioSource>().PlayOneShot(menuSound);
			}
			if (pairClicked == 2)
				AdvanceTime(true);
			//purchase items
			if (shopClicked > -1) {
				itemScript = shopItems[shopClicked];
				CheckItemsCarried();
				if (itemScript.name == "Belt" && hasBelt) {
					GetComponent<AudioSource>().PlayOneShot(noSound);
					shopClicked = -1;
					return;
				}
				if (itemScript.name == "Horse" && hasHorse) {
					GetComponent<AudioSource>().PlayOneShot(noSound);
					shopClicked = -1;
					return;
				}
				if (itemsCarried < 4 && !hasBelt || itemsCarried < 6 && hasBelt || shopClicked == 3 || shopClicked == 5) {
					if (PlayerProfile.gold >= itemScript.cost) {
						GetComponent<AudioSource>().PlayOneShot(shopSound);
						PlayerProfile.gold -= itemScript.cost;
						TakeItem(true);
					} else
						GetComponent<AudioSource>().PlayOneShot(noSound);
				} else
					GetComponent<AudioSource>().PlayOneShot(noSound);
			}
			shopClicked = -1;
			break;
		case 3://spell
			if (spellsCarried < 4) {
				DrawText(spellScript.spellName, 37);
				DrawText(spellScript.spellDescription, 105, false, 4, -80);
				pairClicked = DrawPair("Learn", "Leave", 255);
				if (pairClicked == 1)
					LearnSpell();
				if (pairClicked == 2) {
					ShowExamineGUI();
					HideBigGUI();
					showingGUI = 7;
					GetComponent<AudioSource>().PlayOneShot(menuSound);
				}
			} else
				DrawText("Your spellbook is full", 255);
			break;
		case 4://chest
			DrawText("Chest", 37);
			if (!chestScript.opened) {
				DrawText(chestScript.chestDescriptionClose, 105, false, 4, -80);
				pairClicked = DrawPair("Open", "Leave", 255);
				if (pairClicked == 1) {
					GetComponent<AudioSource>().PlayOneShot(chestSound);
					ProcessEvent();
				}
				if (pairClicked == 2) {
					ShowExamineGUI();
					HideBigGUI();
					showingGUI = 8;
					GetComponent<AudioSource>().PlayOneShot(menuSound);
				}
			} else {
				DrawText(chestScript.chestDescriptionOpen, 105, false, 4, -80);
				if (DrawText("OK", 255, true)) {
					HideAllGUI();
					showingGUI = 8;
					ShowExamineGUI();
					GetComponent<AudioSource>().PlayOneShot(menuSound);
				}
			}
			break;
		case 5://examine item
			if (DrawText("Examine item", 255, true)) {
				ShowItemGUI();
				GetComponent<AudioSource>().PlayOneShot(menuSound);
				if (itemsCarried < 4 && !hasBelt || itemsCarried < 6 && hasBelt)
					ShowPairGUI();
				else
					ShowExamineGUI();
			}
			break;
		case 6://enter castle
			if (DrawText("Enter castle", 255, true)) {
				ShowShopGUI();
				GetComponent<AudioSource>().PlayOneShot(menuSound);
			}
			break;
		case 7://examine book/paper/scroll
			if (DrawText("Examine spell", 255, true)) {
				ShowSpellGUI();
				GetComponent<AudioSource>().PlayOneShot(menuSound);
				if (spellsCarried < 4)
					ShowPairGUI();
				else
					ShowExamineGUI();
			}
			break;
		case 8://examine chest
			if (DrawText("Examine chest", 255, true)) {
				ShowChestGUI();
				GetComponent<AudioSource>().PlayOneShot(menuSound);
			}
			break;
		case 9://event
			DrawText(chestScript.eventName, 37);
			DrawText(chestScript.eventDescription, 105, false, 4, -80);
			if (DrawText("OK", 255, true)) {
				HideAllGUI();
				showingGUI = 8;
				ShowExamineGUI();
				GetComponent<AudioSource>().PlayOneShot(menuSound);
			}
			break;
		case 10://died
			if (PlayerProfile.food > 0)
				DrawText("You were killed", 148);
			else
				DrawText("Starved to death", 148);
			break;
		case 11://game over
			if (PlayerProfile.health <= 0) {
				DrawText("G A M E    O V E R", 37);
				DrawText(gameOverText, 105, false, 4, -80);
			} else {
				DrawText("Congratulations!", 37);
				DrawText(wonGameText, 105, false, 4, -80);
			}
			if (DrawText("Continue", 255, true)) {
				HideAllGUI();
				showingGUI = 14;
				fadeGUI.SetActive(true);
				itemGUI.SetActive(true);
				pairGUI.SetActive(true);
				GetComponent<AudioSource>().PlayOneShot(menuSound);
			}
			break;
		case 12://robbed
			DrawText("Robbed", 37);
			DrawText("You awaken to discover your things ransacked. All of your gold has been stolen!", 105, false, 4, -80);
			if (DrawText("Continue", 255, true)) {
				HideAllGUI();
				GetComponent<AudioSource>().PlayOneShot(menuSound);
			}
			break;
		case 13://collectable item
			DrawText(foundText, 255, true);
			break;
		case 14://stats
			if (PlayerProfile.health <= 0) {
				DrawText("G A M E    O V E R", 37);
				DrawText("Defeat the Lord of Chaos to make your next adventure more interesting.", 105, false, 4, -80);
			} else {
				DrawText("Congratulations!", 37);
				if (PlayerProfile.complete < 10)
					DrawText("Defeating " + GenerateName.firstName + " was clearly too easy. Your next quest will be more challenging!", 105, false, 4, -80);
				else
					DrawText("You defeated " + GenerateName.firstName + " " + GenerateName.lastName + " and slayed " + enemyKilled + " of his minions in " + movesMade + " moves.", 105, false, 4, -80);
			}
			pairClicked = DrawPair("Restart", "Title", 255);
			if (CameraControl.loadLevel)
				return;
			if (pairClicked == 1) {
				GetComponent<AudioSource>().PlayOneShot(menuSound);
				CameraControl.wait = 3.0f;
				CameraControl.loadLevel = true;
				CameraControl.replayGame = true;
			}
			if (pairClicked == 2) {
				CameraControl.wait = 3.0f;
				GetComponent<AudioSource>().PlayOneShot(menuSound);
				CameraControl.loadLevel = true;
				CameraControl.goingToTitle = true;
			}			
			break;
		}
		
	}

	//-----------//
	// Draw Text //
	//-----------//

	bool DrawText (string text, int yPos, bool clickable = false, int linesToWrap = 1, int adjustWidth = 0) {

		bool clicked = false;
		
		if (!clickable)
			GUI.Label(new Rect(90 - (adjustWidth * 0.5f), yPos, textWidth + adjustWidth, textHeight * (linesToWrap + 1)), text, customGUI);
		else {
			if (GUI.Button(new Rect(90 - (adjustWidth * 0.5f), yPos, textWidth + adjustWidth, textHeight * 2), text, customGUI))
				clicked = true;
		}
		
		return clicked;
		
	}

	//-----------//
	// Draw Pair //
	//-----------//

	int DrawPair (string left, string right, int yPos) {

		int buttonClicked = 0;
		
		if (GUI.Button(new Rect(120, yPos, 100, textHeight * 2), left, customGUI))
			buttonClicked = 1;
		if (GUI.Button(new Rect(255, yPos, 100, textHeight * 2), right, customGUI))
			buttonClicked = 2;
		
		return buttonClicked;
						
	}
	
}