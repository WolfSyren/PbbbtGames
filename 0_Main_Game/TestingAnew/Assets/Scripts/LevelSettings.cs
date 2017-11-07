using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour {

	public float _GravityModifier = 1.0f;
	int _BallLives = 3;
	public int _StartingBallLives = 3;

	// Use this for initialization
	void Start () {
		//var baseGravity = Physics.gravity.y;
		//Physics.gravity = new Vector3(0.0f, baseGravity*_GravityModifier, 0.0f);

		_BallLives = _StartingBallLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReduceBallLife()
	{
		_BallLives--;
		if (_BallLives <= 0) {
			//gameover;
		}
	}
}
