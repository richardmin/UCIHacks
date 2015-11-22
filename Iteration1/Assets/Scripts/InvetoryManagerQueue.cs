using UnityEngine;
using System.Collections;

public class InventoryManagerQueue : MonoBehaviour, InventoryManager{
	private int size = 0;
	private int maxSize = 4;
	private System.Collections.Generic.Queue<GameObject> internalQueue = new System.Collections.Generic.Queue<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject push(GameObject obj) {
		if (size < maxSize) {
			internalQueue.Enqueue(obj);
			size++;
			return null;
		} else {
			internalQueue.Enqueue(obj);
			return internalQueue.Dequeue();
		}

	}
	public GameObject push(GameObject obj, int index){
		return push (obj);
	}
		//special for structs with positional: push may not do what it indicates!
	//to be fair, you shouldn't really care.
	public GameObject pop() {
		if (size > 0) {
			size--;
			return internalQueue.Dequeue();
		} else {
			return null;
		}
	}

	public GameObject pop(int index) {
		return pop ();
	}
	public void clear() {
		internalQueue.Clear();
		size = 0;
	}
	
	public void updateHUD() {
	}
}
