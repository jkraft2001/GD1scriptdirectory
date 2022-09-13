using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollACharacter : MonoBehaviour
{

    [Tooltip("How fast does the player go?")]
    public float speed = 20;
    public float jumpForce = 15;
    [Tooltip("How much drag will be applied to the player when isGrounded is true")]
    public float groundedDrag = 2;
    [Tooltip("Opposite of grounded drag")]
    public float airBourneDrag = 2;
    [Tooltip("Are we touching the ground?")]
    public bool isGrounded;
    [Tooltip("What layers are considered ground?")]
    public LayerMask goundMask;

    public float deathThreshold;

    [Header("Mouse Controls")]
    public bool shouldShowCursor;
    public KeyCode showCursorOnKeyDown;

    private Rigidbody myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();

        if (!shouldShowCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //we calculate the relative movement from the main camera based on player input
        var horzMove = Input.GetAxis("Horizontal");
        var vertMove = Input.GetAxis("Vertical");
        var movement = new Vector3(horzMove, 0, vertMove);
        var relativeMovement = Camera.main.transform.TransformVector(movement);
        relativeMovement.y = 0;

        if (isGrounded)
        {
            //if we are grounded, we can move and we apply drag
            myRB.drag = groundedDrag;            
        }
        else
        {
            //if we are not groudned, we can't control movment and apply 0 drag
            myRB.drag = airBourneDrag;
        }

        myRB.AddForce(relativeMovement * speed);
    }

    private void Update()
    {
        if(transform.position.y < deathThreshold)
        {
            KillPlayer();
        }

        if (Input.GetKeyDown(showCursorOnKeyDown))
        {
            //if our cursor is locked and we hit the show cursor key set in the inspector, then we show our cursor and unlock it
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f, goundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    public void KillPlayer()
    {
        FindObjectOfType<LevelManager>().SpawnPlayer();
        Destroy(gameObject);
    }
}
