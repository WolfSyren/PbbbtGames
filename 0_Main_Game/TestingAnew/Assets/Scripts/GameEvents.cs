using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.GameStart += GameStart;
		EventManager.GameUpdate += GameUpdate;
		EventManager.GamePause += GamePause;
		EventManager.GamePauseOn += GamePauseOn;
		EventManager.GamePauseOff += GamePauseOff;
		EventManager.GameEndUpdate += GameEndUpdate;
		EventManager.GameEndedOn += GameEndedOn;
	}

    void GameStart()
    {
		Debug.Log ("START");
    }

    void Update()
    {
        
    }

    void GameUpdate()
    {
		
    }

    void GamePause()
    {


    }

    void GamePauseOn()
    {
		Debug.Log ("PAUSED");
    }


    void GamePauseOff()
    {
		Debug.Log ("UNPAUSED");
    }

	void GameEndUpdate()
	{
		
	}

	void GameEndedOn()
	{
		Debug.Log ("GAME END");
	}

	void OnDestroy()
	{
		EventManager.GameStart -= GameStart;
		EventManager.GameUpdate -= GameUpdate;
		EventManager.GamePause -= GamePause;
		EventManager.GamePauseOn -= GamePauseOn;
		EventManager.GamePauseOff -= GamePauseOff;
		EventManager.GameEndUpdate -= GameEndUpdate;
		EventManager.GameEndedOn -= GameEndedOn;
	}
}
