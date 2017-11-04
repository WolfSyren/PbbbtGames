using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public float _MovementRate = 1.0f;
	bool _MouseDown = false;
	public float _TapTimeLimit = 0.5f;
	float _TapTimer = 0.0f;
	int _PlayerMode = 0;
	// 0=Still, 1=Move, 2=Jump;


	public float _JumpPower = 1.0f;
	public float _GravityMultiplier = 1.0f;
	bool _OnGround = false;

	// Use this for initialization
	void Start () {
		EventManager.GameStart += GameStart;
		EventManager.GameUpdate += GameUpdate;
		EventManager.GamePause += GamePause;
		EventManager.GamePauseOn += GamePauseOn;
		EventManager.GamePauseOff += GamePauseOff;
	}
	
	void GameStart()
	{
		
	}

	void GameUpdate()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			_MouseDown = Input.GetMouseButtonDown (0);
		}
		if (_MouseDown && _PlayerMode == 0) 
		{
			_TapTimer += Time.deltaTime;
			if (_TapTimer >= _TapTimeLimit && _OnGround) 
			{
				_PlayerMode = 1;
			}
		}
			
		if (Input.GetMouseButtonUp (0)) 
		{
			if (_PlayerMode == 1) 
			{
				_PlayerMode = 0;
			} 
			else if(_PlayerMode == 0)
			{
				if (_OnGround) 
				{
					_PlayerMode = 2;
				}
			}
			_TapTimer = 0.0f;
			_MouseDown = false;
		}

		switch (_PlayerMode) 
		{
		case 1:
			var newX = this.transform.position.x;
			var middleOfScreen = Display.main.systemWidth/2;
			//var adjustedMousePosition = Input.mousePosition.x - middleOfScreen; //Input.mousePosition.x - screenWidth/2 - newX; 

			if (Input.mousePosition.x > middleOfScreen) 
			{
				newX = _MovementRate;
			}
			else
			{
				newX = -_MovementRate;
			}
			//Debug.Log (Input.mousePosition.x);
			//var newPosition = new Vector3 (newX, this.transform.position.y, this.transform.position.z);

			var newMovement = new Vector3 (newX*_MovementRate, Physics.gravity.y*(_GravityMultiplier + 1.0f), 0.0f);
			this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
			this.transform.GetComponent<Rigidbody>().AddForce(newMovement);

			// Gravity adjustment
			//this.transform.GetComponent<Rigidbody>().AddForce(Physics.gravity*this.transform.GetComponent<Rigidbody>().mass);
			break;
		case 2:
			if (_OnGround) 
			{
				var _PlayerVelocity = this.transform.GetComponent<Rigidbody> ().velocity;
				var _Bounce = new Vector3 (_PlayerVelocity.x, _JumpPower, 0.0f);

				_PlayerVelocity = Vector3.zero;
				this.gameObject.GetComponent<Rigidbody> ().AddForce (_Bounce);
				_OnGround = false;
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
	void OnDestroy()
	{
		EventManager.GameStart -= GameStart;
		EventManager.GameUpdate -= GameUpdate;
		EventManager.GamePause -= GamePause;
		EventManager.GamePauseOn -= GamePauseOn;
		EventManager.GamePauseOff -= GamePauseOff;
	}

	void OnCollisionEnter (Collision col)
	{
		foreach(ContactPoint ctpt in col.contacts)
		{
			switch (ctpt.otherCollider.tag) 
			{
			case "Map":
			case "Platform":
				_OnGround = true;
				//Debug.Log ("Everybody hit da floor");
				if (_PlayerMode == 2) 
				{
					_PlayerMode = 0;
				}
				break;
			}
		}
	}

	/*void OnCollisionStay (Collision col)
	{
		foreach(ContactPoint ctpt in col.contacts)
		{
			switch (ctpt.otherCollider.tag) 
			{
			case "Map":
			case "Platform":
				_OnGround = true;
				if (_PlayerMode == 2) 
				{
					_PlayerMode = 0;
				}
				break;
			}
		}
	}*/

	void OnCollisionExit (Collision col)
	{
		foreach(ContactPoint ctpt in col.contacts)
		{
			switch (ctpt.otherCollider.tag) 
			{
			case "Map":
			case "Platform":
				_OnGround = false;
				break;
			}
			Debug.Log (ctpt.otherCollider.name);

		}
	}
}
