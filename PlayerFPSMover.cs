using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPSMover : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -99.84f;
    public float jumpHeight = 3f;

    public CharacterController _controller;

    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isGrounded;
    public float groundDistance = 0.4f;
    Vector3 velocity;
    //public float jumpSpeed = 20.0f;
    //public float jumpForce = 100;
    //public Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        //_controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horzMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horzMove + transform.forward * vertMove;

        _controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        _controller.Move(velocity * Time.deltaTime);
    }
}
