using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterBehavior : MonoBehaviour {

	bool _Activated = false;
	float _FilterTimer = 0.0f;
	public float _FilterTimerLimit = 1.0f;

	Vector3 _OriginalPosition;
	Vector3 _RestingPosition;
	// Use this for initialization
	void Start () 
	{
		_OriginalPosition = this.transform.position;
		_RestingPosition = new Vector3(1000.0f,1000.0f,1000.0f);
		this.transform.position = _RestingPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (_Activated) 
		{
			_FilterTimer += Time.deltaTime;
			if (_FilterTimer >= _FilterTimerLimit) 
			{
				DeactivateFilter ();
			}
		}
	}

	public void ActivateFilter () 
	{
		_Activated = true;
		this.transform.position = _OriginalPosition;
	}

	public void DeactivateFilter () 
	{
		_Activated = false;
		this.transform.position = _RestingPosition;
	}

}
