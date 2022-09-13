using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
