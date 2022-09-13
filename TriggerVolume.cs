using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    //public string tag;
    public UnityEvent onTriggerEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
       {
            onTriggerEnter.Invoke();
       } 
    }
}
