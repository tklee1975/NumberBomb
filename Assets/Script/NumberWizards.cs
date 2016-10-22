using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {
	int min = 1;
	int max = 100;
	int guess;

	// Use this for initialization
	void Start () {
		min = 1;
		max = 100;

		print("Welcome to Number Wizards");

		print("pick a number between " + min + " and " + max);
		NextGuess();
	}



	void NextGuess()
	{
		guess = (max + min - 1) / 2;
		print("My guess is " + guess);
		print("Up - it is higher  Down - it is lower - Return - Bingo!");
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){ 
			print("The guess is too high!!");	
			// guess = min
			max = guess;
			NextGuess();

		} else if(Input.GetKeyDown(KeyCode.DownArrow)){ 
			print("The guess is too small!!");	
			// guess = min
			min = guess;
			NextGuess();
		} else if(Input.GetKeyDown(KeyCode.Return)){ 
			print("enter is clicked");
			print("bingo! the answer is " + guess);
		}
	}
}
