using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody body;
    public float speed = 5f;
    public int jumpForce;
    public float rotationSpeed = 5f;
    public float boostForce;
    int jumpCount;
    public List<GameObject> animators;
    public bool jump;
    bool airborne;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            Move();
        }
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            Jump();
            jump = true;
            jumpCount++;
            anim.SetBool("Jump", true);

            //StartCoroutine(Falling());

        }
        if (Input.GetButton("Fire1"))
        {
            body.AddForce(Vector3.forward * boostForce, ForceMode.Impulse);
        }

    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVert = verticalInput * forward;
        Vector3 rightRelativeHori = horizontalInput * right;

        Vector3 CamRelativeMove = forwardRelativeVert + rightRelativeHori;

        // Rotate the character smoothly towards the direction of movement
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(CamRelativeMove, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Move the character
        transform.Translate(CamRelativeMove * speed * Time.deltaTime, Space.World);

        if (Mathf.Abs(horizontalInput) >= Mathf.Abs(verticalInput))
        {
            anim.SetFloat("Velocity", Mathf.Abs(horizontalInput));
        }
        else if (Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput))
        {
            anim.SetFloat("Velocity", Mathf.Abs(verticalInput));
        }
        Debug.Log(horizontalInput +"."+ verticalInput);
        /* float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        //Vector3 rot = new Vector3(0, xInput, 0).normalized * rotateSpeed;
        Vector3 dir = new Vector3(xInput, 0, yInput).normalized * moveSpeed;
        body.velocity = new Vector3(dir.x,body.velocity.y,dir.z);
        Quaternion r = Quaternion.LookRotation(dir);
        body.rotation = Quaternion.Lerp(body.rotation, r , Time.deltaTime * rotateSpeed);
        if(Mathf.Abs(xInput) >= Mathf.Abs(yInput))
        {
            anim.SetFloat("Velocity", Mathf.Abs(xInput));
        }
        else if(Mathf.Abs(yInput) > Mathf.Abs(xInput) )
        {
            anim.SetFloat("Velocity", Mathf.Abs(yInput));
        }

        Transform camref = GameObject.Find("Head").GetComponent<Transform>();
        /*if (camref.forward == )
        {

        }
        //body.transform.Translate(dir * Time.deltaTime);
        //body.transform.Rotate(rot * Time.deltaTime);
        /*Vector3 facingDir = new Vector3(xInput, 0, yInput);
        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }*/
        //Debug.Log(yInput);
    }

    void Jump()
    {
        if (jumpCount > 0)
        {
            float boost = jumpForce * 1.1f;
            body.AddForce(Vector3.up * boost, ForceMode.Impulse);

        }
        else
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    /*IEnumerator Falling()
    {
        yield return new WaitForSeconds(1f);
        //if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        //{
            anim.SetBool("Jump", false);
            jump = false;
        //}

        if (airborne && !jump) 
        {
            anim.SetBool("Falling", true);
            anim.SetBool("Grounded", false);
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;
        jump = false;
        if (collision.gameObject.name == "Plane" )
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Grounded", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Plane")
        {
            if (jump == true)
            {
                anim.SetBool("Grounded", false);
            }
        }
    }
}
