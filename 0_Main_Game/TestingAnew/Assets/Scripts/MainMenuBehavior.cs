using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour {

	int _OldHighScore = 0;
	public GameObject _HighScoreText;
	public GameObject _HelpScreen;

	bool _ActivateHelpScreen = false;
	bool _DeactivateHelpScreen = false;
	public Vector3 _ActiveHelpScreenPosition = Vector3.zero;
	public Vector3 _DefaultHelpScreenPosition = Vector3.zero;
	public float _TransitionTimer = 1.0f;
	Vector3 _HelpScreenSpeed;

	// Use this for initialization
	void Start () 
	{
		LoadHighScore ();
		_HighScoreText.GetComponent<TextMesh> ().text = _OldHighScore.ToString();
		_HelpScreen.transform.position = _DefaultHelpScreenPosition;
		_HelpScreenSpeed = (_DefaultHelpScreenPosition - _ActiveHelpScreenPosition) * (Time.deltaTime / _TransitionTimer);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_ActivateHelpScreen) 
		{
			_HelpScreen.transform.position -= _HelpScreenSpeed;

			if (Vector3.Distance(_HelpScreen.transform.position, _ActiveHelpScreenPosition) <= 0.01f) 
			{
				_ActivateHelpScreen = false;
			}
		}
		else if (_DeactivateHelpScreen) 
		{
			_HelpScreen.transform.position += _HelpScreenSpeed;

			if (Vector3.Distance(_HelpScreen.transform.position, _DefaultHelpScreenPosition) <= 0.01f) 
			{
				_DeactivateHelpScreen = false;
			}
		}
	}

	void LoadHighScore() 
	{
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

	public void ActivateHelpScreen() 
	{
		_ActivateHelpScreen = true;
	}

	public void DeactivateHelpScreen() 
	{
		_DeactivateHelpScreen = true;
		Debug.Log ("pbbbbbbbt");
	}
}
