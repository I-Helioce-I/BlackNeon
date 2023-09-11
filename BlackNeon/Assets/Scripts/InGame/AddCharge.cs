using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddCharge : MonoBehaviour
{
    [SerializeField]
    chargeType charge;

    [SerializeField]
    Material chargeColor;

    [SerializeField]
    Color[] colors;

    private void Start()
    {
        chargeColor = GetComponent<MeshRenderer>().material;

        switch (charge)
        {
            case chargeType.Add:
                chargeColor.SetColor("_EmissionColor", colors[0] * Mathf.Pow(2.0F, 4));
                break;
            case chargeType.Substract:
                chargeColor.SetColor("_EmissionColor", colors[1] * Mathf.Pow(2.0F, 4));
                break;
            case chargeType.Multiply:
                chargeColor.SetColor("_EmissionColor", colors[2] * Mathf.Pow(2.0F, 4));
                break;
            case chargeType.Divide:
                chargeColor.SetColor("_EmissionColor", colors[3] * Mathf.Pow(2.0F, 4));
                break;
            default:
                break;
        }


    }

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
