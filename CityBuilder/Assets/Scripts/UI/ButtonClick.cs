using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioClip _audHov;
    public AudioClip _audPres;
    private AudioSource audSrc;

    void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    public void Hovering()
    {
        audSrc.PlayOneShot(_audHov);
    }

    public void Pressed()
    {
        audSrc.PlayOneShot(_audPres);
    }
}
