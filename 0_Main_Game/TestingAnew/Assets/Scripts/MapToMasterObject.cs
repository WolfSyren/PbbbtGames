using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToMasterObject : MonoBehaviour {

	GameObject _MasterObject;
	// Use this for initialization
	void Start () {
		_MasterObject = GameObject.Find("MasterObject");
		_MasterObject.GetComponent<MapGenerator>().ReceiveMap (this.gameObject);
	}
}
