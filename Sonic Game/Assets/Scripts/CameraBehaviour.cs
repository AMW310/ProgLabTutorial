using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Animator anim;
    Transform playerPos;
    public Vector3 camOffset = new Vector3(0.4f, 1.8f, -1.3f);
    void Start()
    {
        playerPos = GameObject.Find("Banana Man").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = camOffset + playerPos.position;
    }
}
