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


    [Header("Charge"), SerializeField]
    public bool chargeToGive;
    [SerializeField] public int actualCharge;


    PlayerController pc;


    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && addCharges > 0 && actualCharge <= 0)
        {
            addSelected = true;
            substractSelected = false;
            multiplySelected = false;
            divideSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && multiplyCharges > 0 && actualCharge <= 0)
        {
            addSelected = false;
            substractSelected = true;
            multiplySelected = false;
            divideSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && multiplyCharges > 0 && actualCharge <= 0)
        {
            addSelected = false;
            substractSelected = false;
            multiplySelected = true;
            divideSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && divideCharges > 0 && actualCharge <= 0)
        {
            addSelected = false;
            substractSelected = false;
            multiplySelected = false;
            divideSelected = true;
        }

        if (actualCharge > 0)
        {
            UIManager.Instance.DisplayChargeShortcut(true);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                addCharges++;
                CleanToGivePoint();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                substractCharges++;
                CleanToGivePoint();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                multiplyCharges++;
                CleanToGivePoint();
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                divideCharges++;
                CleanToGivePoint();
            }
        }
        else
        {
            UIManager.Instance.DisplayChargeShortcut(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (addSelected)
            {
                actions[0].UseAction(pc);
                addCharges--;
            }
            else if (substractSelected)
            {
                actions[1].UseAction(pc);
                substractCharges--;
            }
            else if (multiplySelected)
            {
                actions[2].UseAction(pc);
                multiplyCharges--;
            }
            else if (divideSelected)
            {
                actions[3].UseAction(pc);
                divideCharges--;
            }

            ResetSelection();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ResetSelection();
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    actions[0].UseAction(pc);
        //    Debug.Log("Add");
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    actions[1].UseAction(pc);
        //    Debug.Log("Substract");
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    actions[2].UseAction(pc);
        //    Debug.Log("Multiply");
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    actions[3].UseAction(pc);
        //    Debug.Log("Divide");
        //}
    }

    public void ResetSelection()
    {
        addSelected = false;
        substractSelected = false;
        multiplySelected = false;
        divideSelected = false;
    }

    private void CleanToGivePoint()
    {
        actualCharge--;
        UIManager.Instance.UpdateChargeText(actualCharge);
    }


}
