using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;
    public int moveSpeed;
    public int jumpForce;
    public float rotateSpeed;
    int jumpCount;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            Jump();
            jumpCount++;
        }

    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(0, 0, yInput).normalized * moveSpeed;
        body.transform.Translate(dir * Time.deltaTime);

        body.transform.Rotate(new Vector3 (0, xInput , 0));
        /*Vector3 facingDir = new Vector3(xInput, 0, yInput);
        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }*/
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
    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;
    }
}
