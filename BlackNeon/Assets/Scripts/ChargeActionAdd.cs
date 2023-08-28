using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeActionAdd : ChargeAction
{
    public override void UseAction(PlayerController pc)
    {
        RaycastHit hit;
        if (Physics.Raycast(pc.GetRaycastorigin().position, pc.GetOrientation().transform.forward, out hit, Mathf.Infinity))
        {
            
            GameObject instance = Instantiate(hit.collider.gameObject, hit.transform.position + (Vector3.Scale(hit.normal,hit.collider.transform.localScale)), hit.transform.localRotation);
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }
}

