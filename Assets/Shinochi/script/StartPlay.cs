using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlay : MonoBehaviour
{
    AudioClip clip;

    void Start()
    {
        clip = gameObject.GetComponent<AudioSource>().clip;
    }

    public void PlayStart()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}