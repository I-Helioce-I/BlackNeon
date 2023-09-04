using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    bool isRotating;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject[] objectToRotate;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            //Rotate();
            RotateOnItSelf();
        }
    }

    void Rotate()
    {
        foreach (GameObject item in objectToRotate)
        {
            item.transform.Rotate(transform.position, 20 * Time.deltaTime, Space.Self);
        }
    }

    void RotateOnItSelf()
    {
        transform.Rotate(transform.position, 20 * Time.deltaTime, Space.Self);
    }
}
