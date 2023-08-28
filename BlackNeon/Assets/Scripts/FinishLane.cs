using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggere");
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            Debug.Log("triggered");
            GameManager.Instance.OnFinishLane();
        }
    }
}
