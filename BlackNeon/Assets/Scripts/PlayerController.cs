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

    }

    public Transform GetRaycastorigin()
    {
        return raycastOrigin;

    }
    public Camera GetOrientation()
    {
        return mainCamera;
    }

    public ActionController GetActionController()
    {
        return aC;
    }




    


}
