using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuessNumberLogic : MonoBehaviour {

	private int mMyGuessValue;
	private int mHiddenAnswer;
	private int mMinBound;
	private int mMaxBound;

	public Text MyNumberText;
	public Text MsgText;

	// Use this for initialization
	void Start () {
		mMinBound = 1;
		mMaxBound = 100;
		mHiddenAnswer = Random.Range(mMinBound, mMaxBound);
		mMyGuessValue = 50;


		MsgText.text = "Guess a number between " + mMinBound + " to " + mMaxBound;

		UpdateGuessToUI();
	}

	public void IncreaseMyGuess()
	{
		MsgText.text = "";

		int value = mMyGuessValue + 1;
		if(value > mMaxBound) {
			value = mMaxBound; 
		} 
		mMyGuessValue = value;
		UpdateGuessToUI();
	}

	public void DecreaseMyGuess()
	{
		MsgText.text = "";

		int value = mMyGuessValue - 1;
		if(value < mMinBound) {
			value = mMinBound; 
		} 


		mMyGuessValue = value;
		UpdateGuessToUI();
	}

	public void SubmitAnswer() {
		if(mHiddenAnswer == mMyGuessValue) {
			SceneManager.LoadScene("GameEnd");
			return;
		}

		string hint = "";
		if(mMyGuessValue < mHiddenAnswer) {
			hint = "It's too small";
			mMinBound = mMyGuessValue+1;
			mMyGuessValue = mMinBound;
		} else {
			hint = "It's too large";
			mMaxBound = mMyGuessValue-1;
			mMyGuessValue = mMaxBound;
		}

		MsgText.text = "Please try again! " + hint;

		UpdateGuessToUI();
		return;	
	}
		

	void UpdateGuessToUI()
	{
		MyNumberText.text = mMyGuessValue.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
