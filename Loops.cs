using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public int whileNumber;
    public GameObject[] randArray;

    // Start is called before the first frame update
    void Start()
    {
        while (whileNumber < 10)
        {
            //print(whileNumber);
            whileNumber++;
        }

        foreach(GameObject go in randArray)
        {
            go.transform.position += Vector3.up * 5;
        }

        for (int i = randArray.Length; i > 0; i--)
        {
            print(randArray[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
