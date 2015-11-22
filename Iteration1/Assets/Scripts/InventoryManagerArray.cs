using UnityEngine;
using System.Collections;

public class InventoryManagerArray : MonoBehaviour, InventoryManager{
	
	private GameObject[] internalArr = new GameObject[5];
	// Use this for initialization
	void Start () {
		for (int i = 0; i < internalArr.Length; i++)
			internalArr [i] = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject push(GameObject obj) {

		for (int i = 0; i < internalArr.Length; i++) {
			if(internalArr[i] == null)
				return null;
	 	}
		//otherwise, we delete the first element and shuffle the rest
		GameObject temp = internalArr [0];
		for(int i = 0; i < internalArr.Length-1; i++) 
			internalArr[i] = internalArr[i+1];
		internalArr [internalArr.Length - 1] = obj;
		return temp;
	}


	public GameObject push(GameObject obj, int index) {
		GameObject temp = internalArr[index];
		internalArr[index] = obj;
		return temp;
	}

	public GameObject pop() {
		GameObject temp = internalArr [0];
		for(int i = 0; i < internalArr.Length-1; i++) 
			internalArr[i] = internalArr[i+1];
		internalArr [internalArr.Length - 1] = null;
		return temp;
	}

	public GameObject pop( int index) { //special in that these are for arrays
		GameObject temp = internalArr [index];
		internalArr [index] = null;
		return temp;
	}


	public void clear() {
		for(int i = 0; i < internalArr.Length; i++)
			internalArr[i] = null;

	}

	public void updateHUD()
	{
	}

}
