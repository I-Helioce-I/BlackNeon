using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
    [SerializeField]
    public Material materialToApply;
    [SerializeField]
    Material defaultMat;

    public bool swapColor;

    void Start()
    {
        defaultMat = GetComponent<MeshRenderer>().material;
        
    }

    public void Update()
    {
        if (swapColor)
        {
            GetComponent<MeshRenderer>().material = materialToApply;
        }
        else
        {
            GetComponent<MeshRenderer>().material = defaultMat;
        }
    }

    public void OnRaycastHit(Material materialToApply)
    {
        GetComponent<MeshRenderer>().material = materialToApply;
    }

    public void OnRaycastUnHit()
    {
        GetComponent<MeshRenderer>().material = defaultMat;
    }

}
