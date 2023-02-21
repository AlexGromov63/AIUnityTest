using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIRSTpersonCONTROLLER : MonoBehaviour
{
    public Transform camera;
    public float sensX = 30;
    public float sensY = 30;
    public float verticalAngle = 30;


    Vector3 lastMousePos;

    // Start is called before the first frame update
    void Awake()
    {
        lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        var deltaPos = Input.mousePosition - lastMousePos;

        transform.Rotate(Vector3.up, deltaPos.x * Time.deltaTime * sensX);

        var angle = camera.eulerAngles.x;

        if (angle > 180)
        {
            angle -= 360;
        }

        if(angle - deltaPos.y * Time.deltaTime * sensY < verticalAngle
            && angle - deltaPos.y * Time.deltaTime * sensY > -verticalAngle)
        {
            camera.Rotate(Vector3.left, deltaPos.y * Time.deltaTime * sensY);
        }
        lastMousePos = Input.mousePosition;
    }
}
