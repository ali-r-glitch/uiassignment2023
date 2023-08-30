using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    private AudioSource wat;
    public AudioClip sound;
    private void Start()
    {
        wat.clip = sound;

    }
    // Start is called before the first frame update
    private void Awake()
    {
        wat.Play();
    }
}
