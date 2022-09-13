using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    float xRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= y;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        playerBody.Rotate(Vector3.up * x);
    }
}
