using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public float _BouncePower = 50.0f; 
	public float _SideBouncePower = 20.0f; 

	float _RandomX;
	float _RandomY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision col)
	{
		foreach(ContactPoint ctpt in col.contacts)
		{
			switch (ctpt.otherCollider.tag) 
			{
			case "Ball Platform":
				//call level settings to reduce ball life.
			case "Player":
				_RandomX = Random.Range (-_SideBouncePower, _SideBouncePower);
				_RandomY = Random.Range (_BouncePower, _BouncePower * 2);

				var _Bounce = new Vector3 (_RandomX, _RandomY, 0.0f);


				this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				this.gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
				this.gameObject.GetComponent<Rigidbody> ().AddForce (_Bounce);
				break;
			}
		}
	}
}
