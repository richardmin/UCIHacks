using UnityEngine;
using System.Collections;

public class MyBalloon : MonoBehaviour {
	int tickCounter = 0;
	System.Random rnd = new System.Random ();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

			transform.GetComponent<Rigidbody>().AddForce (Vector3.up * (float)50);
		if (tickCounter++ >= 20) {
			transform.GetComponent<Rigidbody> ().AddForce (Vector3.left * (float)(rnd.Next (-10, 10) / 10));
			transform.GetComponent<Rigidbody> ().AddForce (Vector3.forward * (float)(rnd.Next (-10, 10) / 10));
		}
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
