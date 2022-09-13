using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            KeepScore.Score += 10;
        }

        if (KeepScore.Score == 100)
        {
            Debug.Log("Congratulations! You Won the game!");
        }
    }
}
