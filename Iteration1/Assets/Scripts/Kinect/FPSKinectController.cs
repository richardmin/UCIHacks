using UnityEngine;
using System.Collections;
using Kinect = Windows.Kinect;

public class FPSKinectController : MonoBehaviour {

    private GameObject KinectPlayerObject;

    private KinectDataHandler _KinectDataHandler;

	// Use this for initialization
	void Start () {
        KinectPlayerObject = GameObject.Find("KinectPlayer");
        _KinectDataHandler = KinectPlayerObject.GetComponent<KinectDataHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        KinectPlayerObject = GameObject.Find("KinectPlayer");
        _KinectDataHandler = KinectPlayerObject.GetComponent<KinectDataHandler>();

        Kinect.Body[] bodies = _KinectDataHandler.GetData();
        if (bodies == null)
        {
            print("Bodies is null.");
            return;
        }

        foreach (Kinect.Body body in bodies)
        {
            Kinect.JointType jt_head = Kinect.JointType.Head;
            Kinect.Joint head;
            if (body.Joints.ContainsKey(jt_head))
            {
                head = body.Joints[jt_head];
            }

            Vector3 newPos = new Vector3(head.Position.X, head.Position.Y, head.Position.Z);
            transform.position = newPos;
        }
	}
}
