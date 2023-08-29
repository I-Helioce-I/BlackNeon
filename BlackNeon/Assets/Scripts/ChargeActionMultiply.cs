using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeActionMultiply : ChargeAction
{
    [SerializeField]
    Material selectedMaterial;


    [SerializeField]
    LayerMask layerMask;

    SwapMaterial colliderDetected;


    public override void UseAction(PlayerController pc)
    {
        RaycastHit hit;
        if (Physics.Raycast(pc.GetRaycastorigin().position, pc.GetOrientation().transform.forward, out hit, Mathf.Infinity))
        {
            hit.collider.gameObject.transform.localScale = new Vector3(hit.collider.gameObject.transform.localScale.x * 2, hit.collider.gameObject.transform.localScale.y * 2, hit.collider.gameObject.transform.localScale.z * 2);
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }

    public override void SelectOutline(PlayerController pc)
    {
        RaycastHit hit;

        if (Physics.Raycast(pc.GetRaycastorigin().position, pc.GetOrientation().transform.forward, out hit, 25, layerMask))
        {

            if (hit.collider.TryGetComponent<SwapMaterial>(out SwapMaterial swapMaterial))
            {
                if (colliderDetected != swapMaterial && colliderDetected != null)
                {
                    colliderDetected.swapColor = false;
                    colliderDetected = swapMaterial;
                }
                else
                {
                    colliderDetected = swapMaterial;
                }

                swapMaterial.materialToApply = selectedMaterial;
                swapMaterial.swapColor = true;
            }

        }
        else
        {
            if (colliderDetected != null)
            {
                colliderDetected.swapColor = false;
                colliderDetected = null;
            }
            Debug.Log("Did not Hit");
        }

    }
}
