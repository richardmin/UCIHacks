using UnityEngine;
using System.Collections;

public class Ballon : MonoBehaviour {

	public GameObject knife; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collision)
	{
		GameObject objectHit = collision.gameObject;
		
		if (objectHit == knife)
		{
			//Update Player Inventory with Bubble

			Destroy(this.gameObject);
		}
		
	}
}
