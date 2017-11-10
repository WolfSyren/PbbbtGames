﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour {

	public GameObject _Filter;
	// Use this for initialization
	void Start () {
		_Filter = GameObject.Find ("Filter");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() 
	{
		// change image to show it is being pressed
		Debug.Log ("Hello, I am " + this.name);
	}

	void OnMouseEnter() 
	{
		// change image to show it is being pressed, basically same as on mouse down
		Debug.Log ("Hello, I am " + this.name);
	}
	void OnMouseExit() 
	{
		//set image back to normal
		Debug.Log ("Ok bye bye... :(");
	}

	void OnMouseUp() 
	{
		//set image back to normal
	}

	void OnMouseUpAsButton() 
	{
		switch (this.name)
		{
		case "Start":
		case "HighScore":
		case "HowTo":
		case "Logo":
		case "Credits":
		case "Quit":
			_Filter.transform.GetComponent<FilterBehavior> ().ActivateFilter ();
			break;
		default:
			break;
		}

		switch (this.name)
		{
		case "Start":
			Application.LoadLevel ("GameScene");
			break;
		case "HighScore":
		case "HowTo":
		case "Logo":
		case "Credits":
			
			break;
		case "Quit":
			//_Master.SendMessage("ChangeBackground", this.name);
			//Debug.Log ("Hello, I am " + this.name);
			//GetComponent<AudioSource>().Play ();

			Application.Quit ();

			break;
		default:
			break;
		}
	}

	void Destroy () 
	{
		
	}
}
