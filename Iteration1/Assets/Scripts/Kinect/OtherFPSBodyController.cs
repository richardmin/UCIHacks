﻿using UnityEngine;
using System.Collections;
using Kinect = Windows.Kinect;

public class OtherFPSBodyController : MonoBehaviour {

    private GameObject KinectPlayerObject;
    private KinectDataHandler dataHandler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        KinectPlayerObject = GameObject.Find("KinectPlayer");
        dataHandler = KinectPlayerObject.GetComponent<KinectDataHandler>();

        foreach (Kinect.Body body in dataHandler.GetData()) {
            print("level inside body");
            Kinect.JointType jt = Kinect.JointType.SpineShoulder;
            if (body.Joints.ContainsKey(jt))
            {
                Vector3 newPos = new Vector3(body.Joints[jt].Position.X, body.Joints[jt].Position.Y,
                    body.Joints[jt].Position.Z);
                print("joint found with position: " + newPos);

                print("old position: " + transform.position);
                transform.position = newPos;
                print("newly assigned position is correct = " + (transform.position == newPos));
            }
        }
	}
}