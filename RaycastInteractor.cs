using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractor : MonoBehaviour
{
    public Transform rayCastOrigin;
    public float rayCastDist;
    public LayerMask interactMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SendRayCast();
        }
    }

    public void SendRayCast()
    {
        RaycastHit hit;

        if(Physics.Raycast(rayCastOrigin.position, rayCastOrigin.TransformDirection(Vector3.forward), out hit, rayCastDist, interactMask))
        {
            Debug.Log("Did hit" + hit.collider.name);

            if(hit.collider.TryGetComponent(out RaycastInteractable info))
            {
                info.DoInteraction();
                Destroy(gameObject);
            }
        }
    }
}
