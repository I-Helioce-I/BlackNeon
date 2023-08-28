using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeActionDivide : ChargeAction
{
    public override void UseAction(PlayerController pc)
    {
        RaycastHit hit;
        if (Physics.Raycast(pc.GetRaycastorigin().position, pc.GetOrientation().transform.forward, out hit, Mathf.Infinity))
        {
            hit.collider.gameObject.transform.localScale = new Vector3(hit.collider.gameObject.transform.localScale.x / 2, hit.collider.gameObject.transform.localScale.y / 2, hit.collider.gameObject.transform.localScale.z / 2);
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }
}
