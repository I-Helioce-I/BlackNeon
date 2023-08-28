using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [Header("Raycast"), SerializeField]
    Transform raycastOrigin;

    [SerializeField] Camera mainCamera;
    [SerializeField] ActionController aC;

    [Header("Debug")]
    public bool resetOnStart = false;


    private void Start()
    {
        aC = GetComponent<ActionController>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.OnDeath();
        }

        //if (actualCharge > 0)
        //{
        //    if (UIManager.Instance.chargeShortcutPanel.activeSelf)
        //    {
        //        if (Input.GetKeyDown(KeyCode.Alpha1))
        //        {
        //            add = true;
        //            UIManager.Instance.UpdateCharge(this);
        //            actualCharge--;
        //        }

        //        if (Input.GetKeyDown(KeyCode.Alpha2))
        //        {
        //            substract = true;
        //            UIManager.Instance.UpdateCharge(this);
        //            actualCharge--;
        //        }

        //        if (Input.GetKeyDown(KeyCode.Alpha3))
        //        {
        //            multiply = true;
        //            UIManager.Instance.UpdateCharge(this);
        //            actualCharge--;
        //        }

        //        if (Input.GetKeyDown(KeyCode.Alpha4))
        //        {
        //            divide = true;
        //            UIManager.Instance.UpdateCharge(this);
        //            actualCharge--;

        //        }

        //        UIManager.Instance.UpdateChargeText(actualCharge);

        //    }
        //    else
        //    {
        //        UIManager.Instance.DisplayChargeShortcut();
                
        //    }
        //}
        //else if(actualCharge <= 0 || UIManager.Instance.chargeShortcutPanel.activeSelf == true)
        //{
        //    UIManager.Instance.HideChargeShortcut();
        //}
    }

    public Transform GetRaycastorigin()
    {
        return raycastOrigin;

    }
    public Camera GetOrientation()
    {
        return mainCamera;

    }





    

    public void AddCharge()
    {
        aC.chargeToGive = true;
        aC.actualCharge++;
        UIManager.Instance.UpdateChargeText(aC.actualCharge);
    }


}
