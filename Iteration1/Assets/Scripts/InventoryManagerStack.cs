using UnityEngine;
using System.Collections;

public class InventoryManagerStack : MonoBehaviour, InventoryManager{
	private int size = 0;
	private int maxSize = 4;
	private System.Collections.Generic.Stack<GameObject> internalStack = new System.Collections.Generic.Stack<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void collapseStack()
	{
	}

	public GameObject push(GameObject obj) {
		if (size < maxSize) {
			internalStack.Push (obj);
			size++;
		} else {
			collapseStack();
		}
		if (size >= maxSize) {
			return obj;
		}
		return null;



	}
	public GameObject push(GameObject obj, int index) {
		return push (obj);
	}//special for structs with positional: push may not do what it indicates!
	//to be fair, you shouldn't really care.
	//for structs where that isn't allowed, it just calls the original.
	public GameObject pop() {
		if (size > 0) {
			size--;
			return internalStack.Pop();

		}
		return null;
	}
	public GameObject pop(int index) {
		return pop ();
	}
	public void clear() {
		internalStack.Clear ();
		size = 0;
	}
	
	public void updateHUD() {
	}

}
