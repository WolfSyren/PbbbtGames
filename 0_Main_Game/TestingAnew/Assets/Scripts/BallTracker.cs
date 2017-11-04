using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour {

	public GameObject _Ball;
	public float _WidthLimit = 9.0f;
	public float _HeightLimit = 9.0f;
	public float _Border = 0.5f;
	float _HeightAdjustment;
	float _BallHeightLimit;

	public GameObject _Player;
	//float _PlayerAdjustment = 0.0f;

	// Use this for initialization
	void Start () {
		EventManager.GameStart += GameStart;
		EventManager.GameUpdate += GameUpdate;
		EventManager.GamePause += GamePause;
		EventManager.GamePauseOn += GamePauseOn;
		EventManager.GamePauseOff += GamePauseOff;
		EventManager.GameEndUpdate += GameEndUpdate;
		EventManager.GameEndedOn += GameEndedOn;
		_BallHeightLimit = _HeightLimit;
		_HeightAdjustment = this.transform.parent.transform.position.y;
		_HeightLimit = _HeightLimit - _HeightAdjustment;

	}

	void GameStart()
	{
		
	}

	void Update()
	{

	}

	void GameUpdate()
	{
		var targetX = this.transform.position.x;
		var targetY = this.transform.position.y;
		var playerPos = _Player.transform.position;
		var ballPos = _Ball.transform.position;
		//var widthLimit = Display.main.systemWidth;
		//var heightLimit = Display.main.systemHeight;

		var showUp = false;
		if (ballPos.x - playerPos.x > _WidthLimit) 
		{
			targetX = _WidthLimit - _Border;
			showUp = true;
		}
		else if (ballPos.x - playerPos.x  < -_WidthLimit) 
		{
			targetX = -_WidthLimit + _Border;
			showUp = true;
		}
		else
		{
			targetX = ballPos.x - playerPos.x;
		}

		if (ballPos.y > _BallHeightLimit) 
		{
			targetY = _HeightLimit;
			showUp = true;
		}
		else if (ballPos.y < 0.5f) 
		{
			showUp = false;
		}
		else
		{
			targetY = _Ball.transform.position.y - _HeightAdjustment;
		}


		if(!showUp)
		{
			targetY = 100.0f;
		}
		this.transform.localPosition = new Vector3 (targetX, targetY, this.transform.localPosition.z);

		//this.transform.LookAt (_Ball.transform);

		var targetDirection = this.transform.position - _Ball.transform.position;
		//var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime, 0.0f);
		//transform.transform.Rotate (newDirection);

		//Debug.Log (this.transform.rotation);
		/*if (_FollowX) 
		{
			targetPos.x = _Ball.transform.position.x;
		}
		if (_FollowY) 
		{
			targetPos.y = _Ball.transform.position.y;
		}*/

		//this.transform.position = targetPos;

		//this.transform.position = Vector3.Lerp (this.transform.position, targetPos, Time.deltaTime * _LerpRate);
	}

	void GamePause()
	{

	}

	void GamePauseOn()
	{
		
	}


	void GamePauseOff()
	{
		
	}

	void GameEndUpdate()
	{

	}

	void GameEndedOn()
	{
		
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