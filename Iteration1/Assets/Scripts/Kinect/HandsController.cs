using UnityEngine;
using System.Collections;
using Kinect = Windows.Kinect;

public class HandsController : MonoBehaviour {

    private GameObject KinectPlayerGameObject;

    private KinectDataHandler _KinectDataHandler;

	// Use this for initialization
	void Start () {
        KinectPlayerGameObject = GameObject.Find("KinectPlayer");
        _KinectDataHandler = KinectPlayerGameObject.GetComponent<KinectDataHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        KinectPlayerGameObject = GameObject.Find("KinectPlayer");
        _KinectDataHandler = KinectPlayerGameObject.GetComponent<KinectDataHandler>();

        if (_KinectDataHandler == null) return;


        Kinect.Body[] bodies = _KinectDataHandler.GetData();
        if (bodies == null)
        {
            print("Bodies is null");
            return;
        }

        print("Size of bodies is: " + bodies.Length);

        foreach (Kinect.Body body in bodies)
        {
            // Testing right hand
            Kinect.JointType jt_rightHand = Kinect.JointType.HandTipRight;
            Kinect.Joint rightHand;
            if (body.Joints.ContainsKey(jt_rightHand))
            {
                rightHand = body.Joints[jt_rightHand];
            }
            else
            {
                print("No right hand found.");
                return;
            }

            Vector3 newPos = new Vector3(rightHand.Position.X, rightHand.Position.Y, rightHand.Position.Z);
            transform.position = newPos;
        }
	}
}
