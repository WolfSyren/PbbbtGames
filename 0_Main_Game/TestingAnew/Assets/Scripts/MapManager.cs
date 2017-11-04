using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour {

	List<GameObject> _PlatformList = new List<GameObject> ();
	public int _MaxNumberOfPlatforms = 3;
	public GameObject _Platform;
	public int _MaxNumberOfLava = 3;

	// Use this for initialization
	void Start () {
		EventManager.GameStart += GameStart;
		EventManager.GameUpdate += GameUpdate;
		EventManager.GamePause += GamePause;
		EventManager.GamePauseOn += GamePauseOn;
		EventManager.GamePauseOff += GamePauseOff;
		EventManager.GameEndUpdate += GameEndUpdate;
		EventManager.GameEndedOn += GameEndedOn;

		PlatformSetup ();
		ActivatePlatforms ();
	}

	void GameStart()
	{
		
	}

	void Update()
	{

	}

	void GameUpdate()
	{

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

	void PlatformSetup()
	{
		/*foreach (Transform child in this.transform) 
		{
			if (child.tag == "Platform") 
			{
				_PlatformList.Add (child.gameObject);
			}
		}*/

		var platforms = 0;
		while (platforms < _MaxNumberOfPlatforms)
		{
			Transform newPlatform;
			Vector3 newPosition = new Vector3 (this.transform.position.x, -50.0f, this.transform.position.z);
			newPlatform = Instantiate (_Platform.transform, newPosition, Quaternion.identity);
			newPlatform.parent = this.transform;
			_PlatformList.Add (newPlatform.gameObject);
			platforms++;
		}

		
		
	}
	/*
	void FindLava()
	{

	}

	void FindPlatforms()
	{

	}
	*/

	public void NewMap(Vector3 newPosition)
	{
		this.transform.position = newPosition;

		ActivatePlatforms ();

		//set lava
	}

	void ActivatePlatforms()
	{
		var numOfPlatforms = 1;//Random.Range(0, _MaxNumberOfPlatforms);
		while (numOfPlatforms > 0) 
		{
			//set position of each platform
			//activate each platform
			_PlatformList[numOfPlatforms-1].GetComponent<PlatformBehavior>().Activate(0.0f);
			numOfPlatforms --;
		}
	}
}
