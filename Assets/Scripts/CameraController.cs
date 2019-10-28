using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1f;
    public float zoomSpeed = 10f;
    public float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //    transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f,         
        //    Input.GetAxis("Vertical")) 
        //    * speed; //Camera movement with W,S,A,D
        //    transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; //Camera Zoom with the Mouse wheel
        //    transform.Rotate(Vector3.up, Input.GetAxis("Rotation") * rotationSpeed, Space.World); // Camera Rotation with Q and E


        transform.position += transform.right * Input.GetAxis("Horizontal") * speed; //Move the camera horizontally 
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed; //Move the camera vertically
        transform.position += transform.up * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; //Camera Zoom with the Mouse wheel
        transform.Rotate(Vector3.up, Input.GetAxis("Rotation") * rotationSpeed, Space.World); //Camera Rotation with Q and E
    }
}
