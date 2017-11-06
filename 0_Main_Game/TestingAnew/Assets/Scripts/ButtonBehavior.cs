using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour {

	//public Button _Button;
	// Use this for initialization
	void Start () {
		
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
		Debug.Log ("Ok bye bye... :(");
	}

	void Destroy () 
	{
		
	}
}
