using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCharge : MonoBehaviour
{
    [SerializeField]
    chargeType charge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().GetActionController().AddCharge(charge);
            Debug.Log("Give charge" + charge);
            Destroy(gameObject);
        }
    }
}
public enum chargeType
{
    Add,
    Substract,
    Multiply,
    Divide
}
