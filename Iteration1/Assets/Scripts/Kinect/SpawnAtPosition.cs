using UnityEngine;
using System.Collections;

public class SpawnAtPosition : MonoBehaviour {
    public GameObject prefab;
	// Use this for initialization
	void Start () {
        Instantiate(prefab, new Vector3(8, 1, 11), transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
