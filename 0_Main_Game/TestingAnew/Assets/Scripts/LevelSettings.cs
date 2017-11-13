﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour {

	public float _GravityModifier = 1.0f;
	int _BallLives = 1;
	public int _StartingBallLives = 3;

	float _GameTimer = 0.0f;
	int _Score = 0;
	int _BallScore = 0;
	public int _BallToScoreRatio = 1;
	int _TimerScore = 0;
	public int _TimeToScoreRatio = 5;

	public GameObject _ScoreDisplay;
	string _ScoreText;

	public GameObject _BallLivesText;
	public GameObject _Time;
	public GameObject _AfterGameTime;
	public GameObject _Quality;
	public GameObject _NewHighScoreText;
	public GameObject _EndHighScoreText;
	public GameObject _EndNewHighScoreText;

	//float _ScreenTimer = 0.0f;

	//List<float> _HighScoreList = new List<float>();
	int _OldHighScore = 0;
	int _NewScore;

	public bool _NewHighScore = false;
	//public bool _CountScore = false;
	//public bool _ScreenUp = false;

	// Use this for initialization
	void Start () {
		EventManager.GameUpdate += GameUpdate;
		//var baseGravity = Physics.gravity.y;
		//Physics.gravity = new Vector3(0.0f, baseGravity*_GravityModifier, 0.0f);

		_BallLives = _StartingBallLives;
	}
	
	void GameUpdate()
	{
		_GameTimer += Time.deltaTime;
		UpdateScore ();
		UpdateScoreText ();
	}

	void UpdateScore()
	{
		_TimerScore = Mathf.FloorToInt((_GameTimer % 60)/_TimeToScoreRatio); 
		_Score = _TimerScore + _BallScore;
	}

	void UpdateScoreText()
	{
		var seconds = Mathf.FloorToInt(_GameTimer % 60); 
		var minutes = Mathf.FloorToInt(_GameTimer/ 60); 
		var hours = Mathf.FloorToInt(minutes/ 60); 

		_ScoreText =  _Score.ToString() + "  ||  " +
							hours.ToString() + " - " +
								minutes.ToString() + " - " +
									seconds.ToString();
		//GUI.Label (Rect (400, 25, 100, 30), _Displ
		_ScoreDisplay.GetComponent<TextMesh>().text = _ScoreText;

	}

	public void ReduceBallLife()
	{
		_BallLives--;
		if (_BallLives <= 0) {
			//gameover;
		}
	}
	public void AddBallScore()
	{
		_BallScore += _BallToScoreRatio;
		Debug.Log ("AAAAAAAAAHHHHHHHHHH");
	}

	/*void CheckScore () 
	{
		LoadHighScore ();
		_NewHighScore = false;
		var newPosition = 11;
		for(int scores = 0; scores < 10; scores +=1)
		{
			var _TimeInSec = (_HighScoreList[scores].x * 3600) + (_HighScoreList[scores].y * 60) + _HighScoreList[scores].z;
			if(_GameTimer> _TimeInSec)
			{
				newPosition = scores;
				_NewHighScore = true;
				scores = 1000;
				Debug.Log("new high score : " + newPosition);
			}
		}
		if(_NewHighScore)
		{
			var seconds = Mathf.FloorToInt(_GameTimer % 60); 
			var minutes = Mathf.FloorToInt(_GameTimer/ 60); 
			var hours = Mathf.FloorToInt(minutes/ 60); 
			_HighScoreList.Insert(newPosition, new Vector3(hours, minutes, seconds));
			var text = "";
			for(int lists = 0; lists < 10; lists +=1)
			{
				if(lists != newPosition)
				{
					text += lists + 1 + "     " + 
						_HighScoreList[lists].x + " hours, "  + 
						_HighScoreList[lists].y + " minutes, "  + 
						_HighScoreList[lists].z + " seconds"  + "\n";
				}
				else
				{
					text += "\n";
				}
			}
			var newtext = "";
			for(int lists = 0; lists < 10; lists +=1)
			{
				if(lists == newPosition)
				{
					newtext += lists + 1 + "     " + 
						_HighScoreList[lists].x + " hours, "  + 
						_HighScoreList[lists].y + " minutes, "  + 
						_HighScoreList[lists].z + " seconds" + "      " + "\n";
				}
				else
				{
					newtext += "    " + "\n";
				}
			}
			_EndHighScoreText.GetComponent<TextMesh>().text = text;
			_EndNewHighScoreText.GetComponent<TextMesh>().text = newtext;
		}
		SaveHighScore ();
	}
	*/

	void CheckScore () 
	{
		LoadHighScore ();
		_NewHighScore = false;
		//var newPosition = 11;

		if(_NewScore> _OldHighScore)
		{
			_NewHighScore = true;
			Debug.Log("new high score : " + _NewScore);
		}
		/*for(int scores = 0; scores < 10; scores +=1)
		{
			if(_GameTimer> _HighScoreList[scores])
			{
				newPosition = scores;
				_NewHighScore = true;
				scores = 1000;
				Debug.Log("new high score : " + newPosition);
			}
		}
		if(_NewHighScore)
		{
			var seconds = Mathf.FloorToInt(_GameTimer % 60); 
			var minutes = Mathf.FloorToInt(_GameTimer/ 60); 
			var hours = Mathf.FloorToInt(minutes/ 60); 

			var text = "";
			for(int lists = 0; lists < 10; lists +=1)
			{
				if(lists != newPosition)
				{
					text += lists + 1 + "     " + 
						_HighScoreList[lists].x + " hours, "  + 
						_HighScoreList[lists].y + " minutes, "  + 
						_HighScoreList[lists].z + " seconds"  + "\n";
				}
				else
				{
					text += "\n";
				}
			}
			var newtext = "";
			for(int lists = 0; lists < 10; lists +=1)
			{
				if(lists == newPosition)
				{
					newtext += lists + 1 + "     " + 
						_HighScoreList[lists].x + " hours, "  + 
						_HighScoreList[lists].y + " minutes, "  + 
						_HighScoreList[lists].z + " seconds" + "      " + "\n";
				}
				else
				{
					newtext += "    " + "\n";
				}
			}
			_EndHighScoreText.GetComponent<TextMesh>().text = text;
			_EndNewHighScoreText.GetComponent<TextMesh>().text = newtext;

		}*/
		SaveHighScore ();
	}

	void LoadHighScore() 
	{
		/*if (_HighScoreList == null) 
		{
			SetNewHighScore ();
		}
		for(int scores = 0; scores < 10; scores +=1)
		{
			_HighScoreList.Add(PlayerPrefs.GetFloat("HighScore" + scores));
		}
		*/
		SetNewHighScore ();
		if (PlayerPrefs.GetInt ("HighScore") ==null) 
		{
			SetNewHighScore ();
		}
		_OldHighScore = PlayerPrefs.GetInt ("HighScore");
	}

	public void SetNewHighScore() 
	{
		/*for(int scores = 0; scores < 10; scores +=1)
		{
			//_HighScoreList.Add(0.0f);
			PlayerPrefs.SetFloat("HighScore" + scores, 0.0f);
		}*/
		PlayerPrefs.SetInt ("HighScore", 0);
	}

	public void SaveHighScore() 
	{
		/*for(int scores = 0; scores < 10; scores +=1)
		{
			//_HighScoreList.Add(new Vector3(0.0f, 1.0f,0.0f));
			PlayerPrefs.SetFloat("HighScore" + scores, _HighScoreList[scores]);
		}*/
		PlayerPrefs.SetInt ("HighScore", _NewScore);
	}

	public void WipeHighScore() 
	{
		/*for(int scores = 0; scores < 10; scores +=1)
		{
			PlayerPrefs.SetFloat("HighScore" + scores, 0.0f);
		}*/
		PlayerPrefs.SetInt ("HighScore", 0);
		Debug.Log ("High Scores wiped");
	}


	void OnDestroy()
	{
		EventManager.GameUpdate -= GameUpdate;
	}
}
