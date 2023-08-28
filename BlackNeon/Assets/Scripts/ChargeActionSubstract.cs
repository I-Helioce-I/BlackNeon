using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ChargeActionSubstract : ChargeAction
{
    public override void UseAction(PlayerController pc)
    {
        RaycastHit hit;
        if (Physics.Raycast(pc.GetRaycastorigin().position, pc.GetOrientation().transform.forward, out hit, Mathf.Infinity))
        {
            Destroy(hit.collider.gameObject);
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }
}
