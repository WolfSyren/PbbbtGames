using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour {

	int _OldHighScore = 0;
	public GameObject _HighScoreText;

	// Use this for initialization
	void Start () 
	{
		LoadHighScore ();
		_HighScoreText.GetComponent<TextMesh> ().text = _OldHighScore.ToString();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void LoadHighScore() 
	{
		SetNewHighScore ();
		if (PlayerPrefs.GetInt ("HighScore") == null) 
		{
			SetNewHighScore ();
		}
		_OldHighScore = PlayerPrefs.GetInt ("HighScore");
	}

	public void SetNewHighScore() 
	{
		PlayerPrefs.SetInt ("HighScore", 0);
	}
}
