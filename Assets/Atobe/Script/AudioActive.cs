using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActive : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    [SerializeField] AudioSource _audio;

    public void Active()
    {
        _gameObject.SetActive(true);
    }

    public void AudioPlay()
    {
        _audio = gameObject.GetComponent<AudioSource>();
        _audio.Play();
    }
}
