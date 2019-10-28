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

        //transform.position += transform.right * Input.GetAxis("Horizontal") * speed; //Move the camera horizontally 
        //transform.position += transform.forward * Input.GetAxis("Vertical") * speed; //Move the camera vertically

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed;
        }


        //transform.position += transform.up * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; //Camera Zoom with the Mouse wheel

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * zoomSpeed, Space.Self);


        transform.Rotate(Vector3.up, Input.GetAxis("Rotation") * rotationSpeed, Space.World); //Camera Rotation with Q and E
    }
}
