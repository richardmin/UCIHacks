using UnityEngine;
using System.Collections;
using Kinect = Windows.Kinect;
using System;

public class SpanishCubes : MonoBehaviour
{
    private GameObject KinectDataGameObject;

    private KinectDataHandler _KinectData;

    private const int MoveThreshold = 10;
    private int xPrevious, yPrevious;

    // Use this for initialization
    void Start()
    {
        KinectDataGameObject = GameObject.Find("KinectPlayer");
        _KinectData = KinectDataGameObject.GetComponent<KinectDataHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        KinectDataGameObject = GameObject.Find("KinectPlayer");
        _KinectData = KinectDataGameObject.GetComponent<KinectDataHandler>();
        if (_KinectData == null)
        {
            return;
        }

        Kinect.Body[] bodies = _KinectData.GetData();
        if (bodies == null)
        {
            print("bodies is null");
            return;
        }

        print("bodies size is: " + bodies.Length);


        foreach (Kinect.Body body in bodies)
        {

            //Kinect.JointType jt = Kinect.JointType.Head;
            //Kinect.Joint head;
            //if (body.Joints.ContainsKey(jt))
            //{
            //    head = body.Joints[jt];
            //}
            //else return;

            //Vector3 newPos = new Vector3(head.Position.X * 10, head.Position.Y * 10, head.Position.Z * 10);
            //transform.position = newPos;


            Kinect.JointType jt = Kinect.JointType.HandTipRight;
            Kinect.JointType jt2 = Kinect.JointType.HandTipLeft;
            Kinect.Joint rightHand, leftHand;
            if (body.Joints.ContainsKey(jt))
            {
                print("hand tip right found in body joints");
                rightHand = body.Joints[jt];
                leftHand = body.Joints[jt2];
            }
            else return;
            //Vector3 newPos = new Vector3((float)xScaled, (float)yScaled, rightHand.Position.Z);
            //Vector3 newPos = new Vector3(rightHand.Position.X, rightHand.Position.Y, rightHand.Position.Z);
            //Vector3 oldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //transform.position = new Vector3(rightHand.Position.X * 10, rightHand.Position.Y * 10, rightHand.Position.Z * 10);
            ////transform.position = Vector3.MoveTowards(oldPos,
            ////    newPos, 1000 * Time.deltaTime);
            //Vector3 realNewPos = new Vector3(transform.position.x * 10, transform.position.y, transform.position.z);
            //print("Old Position: " + oldPos);
            //print("Supposed to be new Position shoulder: " + newPos);
            //print("Real new Position: " + realNewPos);

            Kinect.Joint rightShoulder = body.Joints[Kinect.JointType.ShoulderRight];
            Kinect.Joint leftShoulder = body.Joints[Kinect.JointType.ShoulderLeft];
            Kinect.Joint rightHip = body.Joints[Kinect.JointType.HipRight];


            // the hand is sufficiently in front of the shoulder
            if (rightShoulder.Position.Z - rightHand.Position.Z > 0.4)
            {
                double xScaled = (rightHand.Position.X - leftShoulder.Position.X) / ((rightShoulder.Position.X - leftShoulder.Position.X) * 2) * Screen.width;
                double yScaled = (rightHand.Position.Y - rightShoulder.Position.Y) / (rightHip.Position.Y - rightShoulder.Position.Y) * Screen.height;

                print("right hand is being tracked.");

                //Vector3 newPos = new Vector3((float)xScaled, (float)yScaled, rightHand.Position.Z);
                Vector3 newPos = new Vector3(rightHand.Position.X, rightHand.Position.Y, rightHand.Position.Z);
                Vector3 oldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.position = new Vector3((rightHand.Position.X+leftHand.Position.X)/2 * 10,
                    (rightHand.Position.Y + leftHand.Position.Y) / 2 * 10,
                    (rightHand.Position.Z + leftHand.Position.Z)/2 * 10);
                //transform.position = Vector3.MoveTowards(oldPos,
                //    newPos, 1000 * Time.deltaTime);
                Vector3 realNewPos = new Vector3(transform.position.x * 10, transform.position.y, transform.position.z);
                print("Old Position: " + oldPos);
                print("Supposed to be new Position: " + newPos);
                print("Real new Position: " + realNewPos);
            }

        }

    }
}
