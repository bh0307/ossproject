using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Startmusic()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
