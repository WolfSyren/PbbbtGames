using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public float _RunRate = 1.0f;
	public float _RunPower = 50.0f;
	public float _RunInertia = 4.0f;
	bool _IsMoving = false;

	bool _MouseDown = false;
	public float _TapTimeLimit = 0.5f;
	float _TapTimer = 0.0f;
	int _PlayerMode = 0;
	// 0=Still, 1=Move, 2=Jump;


	//public float _JumpPower = 1.0f;
	public float _GravityMultiplier = 1.0f;
	public float _JumpPower = 120.0f;
	public float _JumpLimit = 50.0f;
	public float _JumpInertia = 7.0f;


	bool _IsJumping = false;
	bool _OnGround = false;

	float _JumpTimer = 0.0f;
	float _MaxJumpTimer = 3.0f;
	public float _MaxJumpPower = 3.0f;


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
				//_PlayerMode = 1;
				_IsMoving = true;
			}
		}
			
		if (Input.GetMouseButtonUp (0)) 
		{
			if (_IsMoving) 
			{
				_IsMoving = false;
			} 
			else if(_OnGround)
			{
				StartJump ();
			}
			_TapTimer = 0.0f;
			_MouseDown = false;
		}
		/*
		switch (_PlayerMode) 
		{
		case 1:
			var newX = this.transform.position.x;
			var middleOfScreen = Display.main.systemWidth/2;
			//var adjustedMousePosition = Input.mousePosition.x - middleOfScreen; //Input.mousePosition.x - screenWidth/2 - newX; 

			if (Input.mousePosition.x > middleOfScreen) 
			{
				newX = _RunRate;
			}
			else
			{
				newX = -_RunRate;
			}
			//Debug.Log (Input.mousePosition.x);
			//var newPosition = new Vector3 (newX, this.transform.position.y, this.transform.position.z);

			var newMovement = new Vector3 (newX*_RunRate, 0.0f, 0.0f);
			this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
			this.transform.GetComponent<Rigidbody>().AddForce(newMovement);

			// Gravity adjustment   
			//this.transform.GetComponent<Rigidbody>().AddForce(Physics.gravity*this.transform.GetComponent<Rigidbody>().mass);

			break;
		case 2:
			//Jump ();
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
		if (!_OnGround) 
		{
			this.transform.GetComponent<Rigidbody>().velocity = new Vector3 (this.transform.GetComponent<Rigidbody>().velocity.x, 0.0f, 0.0f);
			this.transform.GetComponent<Rigidbody>().AddForce(new Vector3 (0.0f, Physics.gravity.y*(_GravityMultiplier + 1.0f), 0.0f));
		}
		Debug.Log (_OnGround);*/
		if (_IsMoving) 
		{
			Move ();
		}
		Jump ();
	}

	void Move()
	{
		var direction = Vector3.zero;
		var middleOfScreen = Display.main.systemWidth/2;
		if (Input.mousePosition.x > middleOfScreen) 
		{
			direction.x = _RunRate;
		}
		else
		{
			direction.x = -_RunRate;
		}

		var movement = new Vector3 (direction.x * _RunPower, transform.GetComponent<Rigidbody>().velocity.y, direction.z * _RunPower);
		movement = transform.TransformDirection(movement);
		this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.Lerp(transform.GetComponent<Rigidbody>().velocity, movement, Time.deltaTime * _RunInertia) ;

	}

	void Jump () {

		if(_IsJumping)
		{
			var NewY = new Vector3(this.transform.position.x, this.transform.position.y+(_JumpPower), 0.0f);
			this.transform.position = Vector3.Lerp(transform.position, NewY, Time.deltaTime);

			if (_JumpPower > -_JumpLimit)
			{
				_JumpPower -= _JumpInertia;
			}
			else
			{
				_JumpPower = -_JumpLimit;
			}
		}
		else if(!_OnGround)
		{
			var NewY = new Vector3(this.transform.position.x, this.transform.position.y+(-_JumpLimit), this.transform.position.z);
			this.transform.position = Vector3.Lerp(transform.position, NewY, Time.deltaTime);
			this.GetComponent<Rigidbody>().useGravity = true;
		}
	}

	void StartJump()
	{
		_OnGround = false;
		_IsJumping = true;

		_JumpTimer = _MaxJumpTimer;
		_JumpPower = _MaxJumpPower;
		Debug.Log ("Jumpy");
	}

	public void Landing ()
	{
		_OnGround = true;
		_IsJumping = false;
		_JumpPower = _MaxJumpPower;
		Debug.Log ("Touchdown");
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
				Landing ();
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
			//case "Map":
			case "Platform":
				_OnGround = false;
				break;
			}
			Debug.Log (ctpt.otherCollider.name);

		}
	}
}
