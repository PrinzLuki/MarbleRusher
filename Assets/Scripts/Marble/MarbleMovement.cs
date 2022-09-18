using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MarbleMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float maxAngularAcceleration;
    public float jumpPower;
    public float jumpDelay = 0.2f;
    public float groundCheckRadial;
    Camera cam;
    public LayerMask enviromentLayer;
    public Transform playerStuffObj;
    Vector3 flashDirection;
    CinemachineFreeLook cineMachine;
    float timer;
    [Header("FeedBacks")]
    [SerializeField] ParticleSystem jumpFeedBack; 

    public Vector3 FlashDirection { get => flashDirection; set => flashDirection = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        cineMachine = FindObjectOfType<CinemachineFreeLook>();
        cineMachine.LookAt = this.transform;
        cineMachine.Follow = this.transform;
        Cursor.lockState = CursorLockMode.Locked;
        cam.GetComponent<CameraController>().ResetCameraPosition();
    }

    private void FixedUpdate()
    {
        Movement();
        playerStuffObj.transform.position = transform.position;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Jump();
        }
        StopRotation();
    }

    bool IsGrounded()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, groundCheckRadial, enviromentLayer);

        if (coll.Length > 0) return true;
        else return false;
    }

    void Movement()
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * -1;
        float yAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) return;

        float camRotY = cam.transform.rotation.eulerAngles.y;

        Quaternion camRot = Quaternion.Euler(0, camRotY, 0);
        Vector3 direction = new Vector3(yAxis, 0, xAxis).normalized * speed;

        Vector3 finalDir = camRot * direction * Time.deltaTime;

        rb.AddTorque(finalDir);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            timer = jumpDelay;
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpFeedBack.Play();
        }
    }

    void StopRotation()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (IsGrounded()) rb.velocity = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadial);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enviroment"))
        {

        }
    }


}
