using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour {

	public Button _Button;
	// Use this for initialization
	void Start () {
		//_Button = this.GetComponent<Button> ();
		//Button button = _Button.GetComponent<Button> ();
		///_Button.onClick.AddListener (Clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Clicked () 
	{
		Debug.Log ("Clicky");
	}

	void OnPointerClick()
	{
		Clicked ();
	}

	void Destroy () 
	{
		//_Button.GetComponent<Button> ().onClick.RemoveAllListeners ();
	}
}
