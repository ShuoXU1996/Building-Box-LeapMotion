using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRotation : MonoBehaviour
{


    private Vector3 startPoint;
    private Vector3 endPoint;
    private int disToAngle = 5;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            endPoint = Input.mousePosition;
        }
        float dx = endPoint.x - startPoint.x;
        float angle = dx / disToAngle;
        float angle2 = endPoint.y - startPoint.y;
        this.transform.localEulerAngles = new Vector3(0, transform.localEulerAngles .y- angle,0);

    }


}
