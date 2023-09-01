using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggere");
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            GameManager.Instance.OnDeath();
        }
    }
}
