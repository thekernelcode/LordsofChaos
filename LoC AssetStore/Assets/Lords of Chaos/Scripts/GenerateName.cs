using UnityEngine;
using System.Collections;

public class GenerateName : MonoBehaviour {

	//-------------------------//
	// Public Static Variables //
	//-------------------------//

	public static string firstName;				//First name of boss character (max 8 letters!)
	public static string lastName;				//Last name (max 11 letters!)

	//--------//
	// Goblin //
	//--------//

	public static void Goblin () {
	
		switch(Random.Range(0, 6)) {
		case 0 :
			firstName = "Argatz";
			break;
		case 1 :
			firstName = "Urag";
			break;
		case 2 :
			firstName = "Nigbit";
			break;
		case 3 :
			firstName = "Gazzah";
			break;
		case 4 :
			firstName = "Skeezix";
			break;
		case 5 :
			firstName = "Wikz";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Weak";
			break;
		case 1 :
			lastName = "the Puny";
			break;
		case 2 :
			lastName = "the Moody";
			break;
		case 3 :
			lastName = "the Foul";
			break;
		}
		
	}

	//-----------//
	// Hobgoblin //
	//-----------//

	public static void Hobgoblin () {
	
		switch(Random.Range(0, 4)) {
		case 0 :
			firstName = "Torpek";
			break;
		case 1 :
			firstName = "Rach";
			break;
		case 2 :
			firstName = "Fidget";
			break;
		case 3 :
			firstName = "Iggy";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Sneaky";
			break;
		case 1 :
			lastName = "the Silent";
			break;
		case 2 :
			lastName = "the Swift";
			break;
		case 3 :
			lastName = "the Greedy";
			break;
		}
		
	}

	//-------//
	// Gnome //
	//-------//

	public static void Gnome () {
	
		switch(Random.Range(0, 5)) {
		case 0 :
			firstName = "Bimpni";
			break;
		case 1 :
			firstName = "Fudwick";
			break;
		case 2 :
			firstName = "Jebkor";
			break;
		case 3 :
			firstName = "Namji";
			break;
		case 4 :
			firstName = "Turkor";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Short";
			break;
		case 1 :
			lastName = "the Wise";
			break;
		case 2 :
			lastName = "the Magi";
			break;
		case 3 :
			lastName = "the Great";
			break;
		}
		
	}

	//-------//
	// Troll //
	//-------//

	public static void Troll () {
	
		switch(Random.Range(0, 3)) {
		case 0 :
			firstName = "Blug";
			break;
		case 1 :
			firstName = "Flub";
			break;
		case 2 :
			firstName = "Yog";
			break;
		}
		
		switch(Random.Range(0, 7)) {
		case 0 :
			lastName = "the Ugly";
			break;
		case 1 :
			lastName = "the Slimy";
			break;
		case 2 :
			lastName = "the Foul";
			break;
		case 3 :
			lastName = "the Vile";
			break;
		case 4 :
			lastName = "the Odourous";
			break;
		case 5 :
			lastName = "the Fetid";
			break;
		case 6 :
			lastName = "the Putrid";
			break;
		}
		
	}

	//-------------------//
	// Goblin Wolf Rider //
	//-------------------//

	public static void GoblinWolfRider () {
	
		switch(Random.Range(0, 4)) {
		case 0 :
			firstName = "Dak";
			break;
		case 1 :
			firstName = "Gub";
			break;
		case 2 :
			firstName = "Og";
			break;
		case 3 :
			firstName = "Gorf";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Swift";
			break;
		case 1 :
			lastName = "the Hasty";
			break;
		case 2 :
			lastName = "the Speedy";
			break;
		case 3 :
			lastName = "the Quick";
			break;
		}
		
	}

	//------//
	// Ogre //
	//------//

	public static void Ogre () {
	
		switch(Random.Range(0, 4)) {
		case 0 :
			firstName = "Kog";
			break;
		case 1 :
			firstName = "Grugg";
			break;
		case 2 :
			firstName = "Mongo";
			break;
		case 3 :
			firstName = "Hrrub";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Stout";
			break;
		case 1 :
			lastName = "the Mighty";
			break;
		case 2 :
			lastName = "the Giant";
			break;
		case 3 :
			lastName = "the Flatulent";
			break;
		}
		
	}

	//-------//
	// Witch //
	//-------//

	public static void Witch () {
	
		switch(Random.Range(0, 4)) {
		case 0 :
			firstName = "Hazel";
			break;
		case 1 :
			firstName = "Ursula";
			break;
		case 2 :
			firstName = "Tabitha";
			break;
		case 3 :
			firstName = "Selena";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Vile";
			break;
		case 1 :
			lastName = "the Black";
			break;
		case 2 :
			lastName = "the Wicked";
			break;
		case 3 :
			lastName = "the Hagged";
			break;
		}
		
	}

	//---------//
	// Banshee //
	//---------//

	public static void Banshee () {
	
		switch(Random.Range(0, 6)) {
		case 0 :
			firstName = "Aednat";
			break;
		case 1 :
			firstName = "Eachna";
			break;
		case 2 :
			firstName = "Grainne";
			break;
		case 3 :
			firstName = "Niamh";
			break;
		case 4 :
			firstName = "Saoirse";
			break;
		case 5 :
			firstName = "Teagan";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Ghastly";
			break;
		case 1 :
			lastName = "the Tortured";
			break;
		case 2 :
			lastName = "the Abandoned";
			break;
		case 3 :
			lastName = "the Forgotten";
			break;
		}
		
	}

	//--------//
	// Dragon //
	//--------//

	public static void Dragon () {
	
		switch(Random.Range(0, 6)) {
		case 0 :
			firstName = "Aralth";
			break;
		case 1 :
			firstName = "Emelth";
			break;
		case 2 :
			firstName = "Ginarth";
			break;
		case 3 :
			firstName = "Ith";
			break;
		case 4 :
			firstName = "Soreth";
			break;
		case 5 :
			firstName = "Tiolth";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Ancient";
			break;
		case 1 :
			lastName = "the Wise";
			break;
		case 2 :
			lastName = "the Great";
			break;
		case 3 :
			lastName = "the Mighty";
			break;
		}
		
	}

	//-------//
	// Demon //
	//-------//

	public static void Demon () {
	
		switch(Random.Range(0, 5)) {
		case 0 :
			firstName = "Agrat";
			break;
		case 1 :
			firstName = "Lilith";
			break;
		case 2 :
			firstName = "Naamah";
			break;
		case 3 :
			firstName = "Samael";
			break;
		case 4 :
			firstName = "Eisheth";
			break;
		}
		
		switch(Random.Range(0, 4)) {
		case 0 :
			lastName = "the Cruel";
			break;
		case 1 :
			lastName = "the Wicked";
			break;
		case 2 :
			lastName = "the Ancient";
			break;
		case 3 :
			lastName = "the Torturer";
			break;
		}
		
	}
	
}