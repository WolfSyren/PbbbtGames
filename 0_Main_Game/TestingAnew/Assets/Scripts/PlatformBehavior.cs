using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour {

	public float _MovementRate = 0.5f;
	public float _MaxHeight = 5.0f;
	public float _MinHeight = 1.0f;
	public float _MaxStayTime = 10.0f;
	public float _MaxStartTime = 3.0f;
	public Vector3 _DeactivatedPosition = Vector3.zero;

	float _StayTimer = 0.0f;
	float _StartTimer = 0.0f;
	public int _Mode = 0;
	// 0=deactivated, 1=stay, 2=up, 3=down
	int _DeactivatedMode = 0;
	int _StartMode = 1;
	int _StayMode = 2;
	int _UpMode = 3;
	int _DownMode = 4;

	// Use this for initialization
	void Start () {
		EventManager.GameStart += GameStart;
		EventManager.GameUpdate += GameUpdate;
		EventManager.GamePause += GamePause;
		EventManager.GamePauseOn += GamePauseOn;
		EventManager.GamePauseOff += GamePauseOff;
		EventManager.GameEndUpdate += GameEndUpdate;
		EventManager.GameEndedOn += GameEndedOn;
		//Deactivate ();
	}

	void GameStart()
	{
		
	}

	void GameUpdate()
	{
		var newY = 0.0f;
		var newPos = Vector3.zero;
		switch (_Mode) 
		{
		case 0: //inactive mode
			break;
		case 1:
			_StartTimer -= Time.deltaTime;
			if (_StartTimer <= 0.0f) 
			{
				//change mode to up
				_Mode = _UpMode;
			}
			break;
		case 2: //stay mode
			_StayTimer += Time.deltaTime;
			if (_StayTimer >= _MaxStayTime) 
			{
				//change mode to up or down
				if (this.transform.localPosition.y >= _MinHeight) 
				{
					_Mode = _DownMode;
				} 
				else 
				{
					_Mode = _UpMode;
				}
				_StayTimer = 0.0f;
			}
			break;
		case 3: //up mode
			newY = this.transform.localPosition.y + _MovementRate;
			newPos = new Vector3(this.transform.position.x, newY, this.transform.position.z);
			this.transform.position = Vector3.Lerp (this.transform.position, newPos, Time.deltaTime * _MovementRate);
			if (newY >= _MaxHeight) 
			{
				_Mode = _StayMode;
			}
			break;
		case 4: //down mode
			newY = this.transform.position.y - _MovementRate;
			newPos = new Vector3(this.transform.position.x, newY, this.transform.position.z);
			this.transform.position = Vector3.Lerp (this.transform.position, newPos, Time.deltaTime * _MovementRate);
			if (newY <= _MinHeight) 
			{
				_Mode = _StayMode;
			}
			break;
		}
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

	public void Activate(float newX)
	{
		_Mode = _StartMode;
		this.transform.localPosition = new Vector3 (newX, _MinHeight, 0.0f);
		_StartTimer = Random.Range (0.3f, _MaxStartTime);
	}

	void Deactivate()
	{
		_Mode = _DeactivatedMode;
		this.transform.localPosition = _DeactivatedPosition;
	}
}

