using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Animator anim;
    internal static Transform p1Position;
    public Transform facingDir;
    /*public Vector3 camOffset = new Vector3(0.4f, 1.8f, -1.3f);
    Vector3 offset;
    public float camSpeedX = 10.0f;
    public float camSpeedY = 10.0f;

    float yaw;
    float pitch;
    */
    public Transform player;
    public Transform playerObj;

    public float rotationSpeed;
    void Start()
    {
        p1Position = GameObject.Find("Banana Man").transform;
        //offset = p1Position.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        this.transform.position = camOffset + p1Position.position;
        
        float horizontal = Input.GetAxis("Mouse X") * camSpeedX;
        float vertical = Input.GetAxis("Mouse Y") * camSpeedY;
        if (Input.GetButton("Fire2"))
        {
            facingDir.forward = p1Position.forward;
            p1Position.Rotate(0, horizontal, 0);
        }
        else
        {
            facingDir.Rotate(0, horizontal, 0);
        }
            

        
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = p1Position.position - (rotation * offset);
        
        
        yaw += camSpeedX * Input.GetAxis("Mouse X");
        pitch -= camSpeedY * Input.GetAxis("Mouse Y");
        yaw = Mathf.Repeat(yaw, 360);
        pitch = Mathf.Clamp(pitch, -80, 80);
        this.transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        this.transform.Rotate(yaw,pitch,0);
        */
        //transform.LookAt(facingDir);

        AimingBehaviour();
    }

    void AimingBehaviour()
    {
        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        facingDir.forward = viewDir.normalized;

        //rotate player object
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = facingDir.forward * vertical + facingDir.right * horizontal;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

        facingDir.position = new Vector3(p1Position.position.x, p1Position.position.y + 1.69f, p1Position.position.z);
    }
}
