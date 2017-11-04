using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public GameObject _Target;
	public bool _FollowX = false;
	public bool _FollowY = false;
	public bool _FollowZ = false;
	public bool _Lerp = false;
	public float _LerpRate = 1.0f;

	// Use this for initialization
	void Start () 
	{
		EventManager.GameUpdate += GameUpdate;
	}
	
	// Update is called once per frame
	void GameUpdate () 
	{
		var targetPos = this.transform.position;
		if (_FollowX) 
		{
			targetPos.x = _Target.transform.position.x;
		}
		if (_FollowY) 
		{
			targetPos.y = _Target.transform.position.y;
		}
		if (_FollowZ) 
		{
			targetPos.z = _Target.transform.position.z;
		}


		if(!_Lerp)
		{
			this.transform.position = targetPos;
		}
		else 
		{
			this.transform.position = Vector3.Lerp (this.transform.position, targetPos, Time.deltaTime * _LerpRate);
		}
	}
}
