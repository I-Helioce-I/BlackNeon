using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            GameManager.Instance.OnFinishLane();
        }
    }
}
