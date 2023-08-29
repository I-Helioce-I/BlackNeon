using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public ChargeAction[] actions;

    [Header("Add")]
    [SerializeField] int addCharges;
    [SerializeField] bool addSelected;
    [Header("Substract")]
    [SerializeField] int substractCharges;
    [SerializeField] bool substractSelected;
    [Header("Multiply")]
    [SerializeField] int multiplyCharges;
    [SerializeField] bool multiplySelected;
    [Header("Divide")]
    [SerializeField] int divideCharges;
    [SerializeField] bool divideSelected;

    PlayerController pc;


    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        ChargeSelector();

        if (addSelected || substractSelected || multiplySelected || divideSelected)
        {
            DoRaycast();
        }
    }

    private void DoRaycast()
    {

        if (addSelected)
        {
            actions[0].SelectOutline(pc);
        }
        else if (substractSelected)
        {
            actions[1].SelectOutline(pc);
        }
        else if (multiplySelected)
        {
            actions[2].SelectOutline(pc);
        }
        else if (divideSelected)
        {
            actions[3].SelectOutline(pc);
        }
    }

    private void ChargeSelector()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && addCharges > 0)
        {
            addSelected = true;
            substractSelected = false;
            multiplySelected = false;
            divideSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && substractCharges > 0)
        {
            addSelected = false;
            substractSelected = true;
            multiplySelected = false;
            divideSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && substractCharges > 0)
        {
            addSelected = false;
            substractSelected = false;
            multiplySelected = true;
            divideSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && substractCharges > 0)
        {
            addSelected = false;
            substractSelected = false;
            multiplySelected = false;
            divideSelected = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            addSelected = false;
            substractSelected = false;
            multiplySelected = false;
            divideSelected = false;
        }

    }

    public void AddCharge(chargeType chargeType)
    {
        if (chargeType == chargeType.Add)
        {
            addCharges++;
        }
        else if (chargeType == chargeType.Substract)
        {
            substractCharges++;
        }
        else if (chargeType == chargeType.Multiply)
        {
            multiplyCharges++;
        }
        else if (chargeType == chargeType.Divide)
        {
            divideCharges++;
        }

    }

}
