using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    // Overarching events
    public delegate void GameEvents();
    public static event GameEvents GameStart;
	public static event GameEvents GameUpdate;
	public static event GameEvents GamePause;
	public static event GameEvents GamePauseOn;
	public static event GameEvents GamePauseOff;
	public static event GameEvents GameEndUpdate;
	public static event GameEvents GameEndedOn;

    // variables to determine when GameEvents are occuring.
    bool _GameStarted = false;
    bool _GamePaused = true;
    bool _GameOver = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!_GameStarted && GameStart != null) 
		{
			GameStart ();
			_GameStarted = true;
			_GamePaused = false;
		} 
		else if (_GameStarted && !_GameOver) 
		{
			if (_GamePaused && GamePause != null) 
			{
				GamePause ();
			} 
			else if(GameUpdate  != null)
			{
				GameUpdate ();
			}
		} 
		else if (_GameOver) 
		{
			GameEndUpdate ();
		}

	}
}
