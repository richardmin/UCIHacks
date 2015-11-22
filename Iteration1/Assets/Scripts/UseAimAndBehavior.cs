using UnityEngine;
using System.Collections;
using System;

public class UseAimAndBehavior : MonoBehaviour {

    private const double TimeInterval = 3f;
    private System.DateTime? _startTime = null;

    private GameObject collidingObject;
    private GameObject camera;

	// Use this for initialization
	void Start () {
            
	}
	
	// Update is called once per frame
	void Update () {
        bool usePressed = Input.GetKey(KeyCode.E);
        if (usePressed)
        {
            if (rayTracingHitSomething())
            {
                if (_startTime == null)
                {
                    _startTime = System.DateTime.Now;
                    showAnimation();
                }
                else if (System.DateTime.Now.Subtract(((System.DateTime)_startTime).AddSeconds(TimeInterval)) > new System.TimeSpan(0,0,0))
                {
                    _startTime = null;
                    completePickUp();
                    hideAnimation();
                }
            }
        }
        else
        {
            _startTime = null;
            hideAnimation();
        }
	}


    private void showAnimation()
    {

    }

    private void hideAnimation()
    {

    }

    private bool rayTracingHitSomething()
    {
        return false;
    }

    private void completePickUp()
    {

    }

}