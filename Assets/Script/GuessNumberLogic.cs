using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuessNumberLogic : MonoBehaviour {

	private int mCurrentDigit = 0;
	private int mDigit0 = 0;
	private int mDigit1 = 0;

	private int mMaxLife;
	private int mLife;

	private int mMyGuessValue;
	private int mHiddenAnswer;
	private int mMinBound;
	private int mMaxBound;

	public Text MyNumberText;
	public Text MsgText;
	public Text LifeText;

	// Use this for initialization
	void Start () {
		mMaxLife = 5;
		mLife = mMaxLife;

		mMinBound = 0;
		mMaxBound = 99;
		mHiddenAnswer = Random.Range(mMinBound, mMaxBound);
		mMyGuessValue = 0;


		MsgText.text = "Unlock the bomb with correct code: " + mMinBound + " ~ " + mMaxBound;

		UpdateGuessToUI();
		UpdateLifeToUI();
	}

	void changeValue(int digit)
	{
		if(mCurrentDigit == 0) {
			mDigit1 = 0;
			mDigit0 = digit;
		}else if(mCurrentDigit == 1) {
			mDigit1 = mDigit0;
			mDigit0 = digit;
		}

		mMyGuessValue = mDigit1 * 10 + mDigit0;
		mCurrentDigit = (mCurrentDigit + 1) % 2;

		UpdateGuessToUI();
	}

	public void NumberClicked(int value)
	{
		changeValue(value);	
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

		// Reset the digit position 
		mCurrentDigit = 0;

		// update life
		mLife--;
		UpdateLifeToUI();

		// Checking lose case
		if(mLife <= 0) {
			SceneManager.LoadScene("GameLose");
			return;
		}

		string hint = "";
		if(mMyGuessValue < mHiddenAnswer) {
			hint = "It's too small";
		} else {
			hint = "It's too large";
		}

		MsgText.text = "Please try again! " + hint;

		return;	
	}

	void UpdateLifeToUI()
	{
		LifeText.text = mLife.ToString();
	}

	void UpdateGuessToUI()
	{
		string outString = "";
		if(mMyGuessValue < 10) {
			outString = "0" + mMyGuessValue;
		} else {
			outString = mMyGuessValue.ToString();
		}

		MyNumberText.text = outString;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
