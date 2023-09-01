using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public Action action;

    public enum Action
    {
        start,
        stop
    }



    private void OnTriggerEnter(Collider other)
    {
        if (action == Action.start)
        {

            GetComponent<AudioSource>().Play();
        }

        if(action == Action.stop)
        {

            GetComponent<AudioSource>().Stop();
        }
    }
}
