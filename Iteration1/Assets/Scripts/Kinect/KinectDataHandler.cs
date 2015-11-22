using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class KinectDataHandler : MonoBehaviour
{

    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;

    private System.DateTime _initTime;
    private bool _offsetRecorded = false;
    private Vector3 _DataOffset;

    public Body[] GetData()
    {
        return _Data;
    }

    // Use this for initialization
    void Start()
    {
        _initTime = System.DateTime.Now;
        _initTime = _initTime.AddSeconds(10);
        
        // Gets the sensor object from the kinect
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            // Gets the reader object from the sensor object
            _Reader = _Sensor.BodyFrameSource.OpenReader();

            // Open sensor if not already open
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }

        if (!_offsetRecorded)
        {
            if (System.DateTime.Now.Subtract(_initTime) > new System.TimeSpan(0, 0, 1))
            {
                _DataOffset = new Vector3(8-transform.position.x, 1-transform.position.y, 11-transform.position.z);
                _offsetRecorded = true;
            }
        }

        if (_offsetRecorded)
        {
            transform.Translate(_DataOffset);
            //for (int i = 0; i < _Data.Length; i++)
            //{
            //    Body body = _Data[i];
            //    foreach (JointType key in body.Joints.Keys)
            //    {
                    
            //    }
            //}
                
        }

        GameObject FPSCamera = GameObject.Find("RigidBodyFPSController");
        Vector3 initPos = new Vector3(FPSCamera.transform.position.x,FPSCamera.transform.position.y,FPSCamera.transform.position.z);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();
            if (frame != null)
            {
                if (_Data == null)
                {
                    _Data = new Body[_Sensor.BodyFrameSource.BodyCount];
                }

                frame.GetAndRefreshBodyData(_Data);
                frame.Dispose();
                frame = null;
            }
        }

        Vector3 pos = new Vector3(transform.position.x, transform.position.x, transform.position.x);
        print("Current kinect player position is: " + pos);
    }


    void OnApplicationQuit()
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }

        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }
            _Sensor = null;
        }
    }
}
