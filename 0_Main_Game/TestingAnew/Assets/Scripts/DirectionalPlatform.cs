using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPlatform : MonoBehaviour {

	public float _AdjustedHeight = 1.0f;
	GameObject _Player;

	// Use this for initialization
	void Start () 
	{
		EventManager.GameUpdate += GameUpdate;

		_Player = GameObject.Find("Player");
	}
	

	void GameUpdate()
	{
		if (_Player.transform.position.y >= this.transform.position.y + _AdjustedHeight) 
		{
			this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
		} 
		else 
		{
			this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
		}
		//Debug.Log (this.gameObject.GetComponent<BoxCollider> ().isTrigger);
	}

	void OnDestroy()
	{
		EventManager.GameUpdate -= GameUpdate;
	}
}
