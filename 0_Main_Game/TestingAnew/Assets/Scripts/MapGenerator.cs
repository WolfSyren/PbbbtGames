using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public float _MapSize = 10.0f;
	float _MaxMapNum = 0.0f;
	public GameObject _CurrentMap;
	int _NewMap;
	int _MiddleMap;

	List<GameObject> _MapList = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		EventManager.GameStart += GameStart;
		EventManager.GameUpdate += GameUpdate;
		EventManager.GamePause += GamePause;
		EventManager.GamePauseOn += GamePauseOn;
		EventManager.GamePauseOff += GamePauseOff;
		EventManager.GameEndUpdate += GameEndUpdate;
		EventManager.GameEndedOn += GameEndedOn;
	}

	void GameStart()
	{
		SortMapList ();
		/*var listSize = 0;
		while (listSize < _MapList.Count)
		{
			Debug.Log (_MapList [listSize].transform.position.x);
			listSize++;
		}*/
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

	public void ReceiveMap(GameObject newMap)
	{
		_MapList.Add (newMap);
		_MaxMapNum ++;
		_MiddleMap = Mathf.FloorToInt(Mathf.Round(_MaxMapNum/2.0f));
		SortMapList ();
	}

	public void PlayerEnteringNewMap(GameObject enteredMap)
	{
		if (enteredMap != _CurrentMap) ///not sure if this line is necessary, but...
		{
			_CurrentMap = enteredMap;
			var listSize = 0;
			while (listSize < _MapList.Count)
			{
				if (_MapList [listSize] == enteredMap && listSize!= _MiddleMap) 
				{
					var newXPosition = 0.0f; //enteredMap.transform.position.x;
					var mapToMove = 0;

					if (listSize - _MiddleMap < 0) //generate at the left
					{
						newXPosition = _MapList [0].transform.position.x - _MapSize;
						mapToMove = _MapList.Count-1;
					} 
					else //generate at the left
					{
						newXPosition = _MapList [_MapList.Count - 1].transform.position.x + _MapSize;
					}
					GenerateNewMap (newXPosition, mapToMove);

					break;
				}
				listSize++;
			}
		}
	}

	void GenerateNewMap(float newXPosition, int mapToMove)
	{
		//temporary settings
		_MapList[mapToMove].GetComponent<MapManager>().NewMap(new Vector3(newXPosition, 0.0f, 0.0f));
		//send instructions to map
		//update map list order via sort
		SortMapList();
	}

	void SortMapList()
	{
		var updatedMapList = new List<GameObject> ();
		updatedMapList = _MapList.OrderBy(go =>go.transform.position.x).ToList();
		_MapList = updatedMapList;
	}
}
