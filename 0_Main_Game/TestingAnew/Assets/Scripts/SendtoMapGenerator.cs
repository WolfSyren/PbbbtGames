using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendtoMapGenerator : MonoBehaviour {
	
	GameObject _MasterObject;
	// Use this for initialization
	void Start () {
		//EventManager.GameStart += GameStart;
		_MasterObject = GameObject.Find("MasterObject");
	}

	/*void GameStart()
	{
		
	}

	void OnDestroy()
	{
		EventManager.GameStart -= GameStart;
	}*/

	void OnTriggerEnter (Collider otherObject) 
	{
		if (otherObject.gameObject.name == "Player") 
		{
			_MasterObject.GetComponent<MapGenerator>().PlayerEnteringNewMap (this.gameObject.transform.parent.gameObject);
		}
	}
}
