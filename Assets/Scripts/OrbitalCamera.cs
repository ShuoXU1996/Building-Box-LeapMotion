using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public float sensitivetyKeyBoard = 0.05f;
    public float rotatespeed = 50;
    public float zoomspeed = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Input.GetAxis("Horizontal") * sensitivetyKeyBoard, 0, 0);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, Input.GetAxis("Vertical") * sensitivetyKeyBoard, 0);
        }
        if (Input.GetKey(KeyCode.U))
        {
            transform.Translate(Vector3.forward * zoomspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.O))
        {
            transform.Translate(Vector3.forward * -zoomspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(0, rotatespeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(0, -rotatespeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(-rotatespeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(rotatespeed * Time.deltaTime, 0, 0);
        }
    }
}
