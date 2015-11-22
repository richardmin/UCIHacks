using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class KinectDataHandler : MonoBehaviour
{

    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;

    public Body[] GetData()
    {
        return _Data;
    }

    // Use this for initialization
    void Start()
    {
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
