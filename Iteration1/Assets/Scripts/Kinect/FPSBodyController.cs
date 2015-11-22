using UnityEngine;
using System.Collections;

public class FPSBodyController : MonoBehaviour {


    private GameObject _BodyView;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _BodyView = GameObject.Find("testBodyView");

        transform.position = new Vector3(_BodyView.transform.position.x - 5f, _BodyView.transform.position.y - 5f, _BodyView.transform.position.z - 5f);
        
	}
}
