using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCam : MonoBehaviour
{
    //public GameObject target;

    //private float xRotateMove, yRotateMove;

    //public float rotateSpeed = 50.0f;

    //public float scrollSpeed = 10.0f;


    //private void Update()
    //{
    //    if (Input.GetMouseButton(1))
    //    {
    //        xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
    //        yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

    //        Vector3 targetPosition = target.transform.position;

    //        transform.RotateAround(targetPosition, Vector3.right, -yRotateMove);
    //        transform.RotateAround(targetPosition, Vector3.up, xRotateMove);

    //        transform.LookAt(targetPosition);
    //    }
    //    else
    //    {
    //        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

    //        Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;

    //        this.transform.position += cameraDirection * Time.deltaTime * scrollWheel * scrollSpeed;
    //    }
    //}

    public GameObject target;
    public float xmove, ymove;
    public float rotateSpeed = 5000f;
    public float distance = 3;

    public float smoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;

    private int toggleView = 3;

    private float wheelspeed = 10.0f;

    private void Start()
    {
        target = GameObject.Find("Barrel(Clone)");
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            xmove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            ymove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            Vector3 targetPosition = target.transform.position;

            transform.RotateAround(targetPosition, Vector3.right, -ymove);
            transform.RotateAround(targetPosition, Vector3.up, xmove);

            transform.LookAt(targetPosition);
        }
        //transform.rotation = Quaternion.Euler(ymove, xmove, 0);

        if (toggleView == 3)
        {
            distance -= Input.GetAxis("Mouse ScrollWheel") * wheelspeed;
            if (distance < 3.0f) distance = 3.0f;
            if (distance > 10.0f) distance = 10.0f;

            Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
            transform.position = Vector3.SmoothDamp(
                transform.position,
                target.transform.position - transform.rotation * reverseDistance,
                ref velocity,
                smoothTime);
        }

    }

}
