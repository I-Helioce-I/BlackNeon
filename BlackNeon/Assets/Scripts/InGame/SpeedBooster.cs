using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField]
    float impulseForce = 10 ;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Should bosst forward" + other.gameObject.name);
        other.GetComponent<Rigidbody>().AddForce(Vector3.forward * impulseForce, ForceMode.Acceleration);
        Destroy(gameObject);
    }
}
