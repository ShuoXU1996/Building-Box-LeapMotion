using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform centre;
    float speed = 30;
    float zoomspeed = 0.5f;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
            transform.RotateAround(centre.position, Vector3.up, speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.L))
            transform.RotateAround(centre.position, Vector3.up, -speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.I))
            transform.RotateAround(centre.position, Vector3.right, speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.K))
            transform.RotateAround(centre.position, Vector3.right, -speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.U))
            transform.Translate(Vector3.forward * zoomspeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.O))
            transform.Translate(Vector3.forward * -zoomspeed * Time.deltaTime);

        else if (Input.GetKey(KeyCode.W))
            transform.Translate(0.1f * Vector3.up * Time.deltaTime, Space.Self);
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(-0.1f * Vector3.up * Time.deltaTime, Space.Self);
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(-0.1f * Vector3.right * Time.deltaTime, Space.Self);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(0.1f * Vector3.right * Time.deltaTime, Space.Self);
    }
}
