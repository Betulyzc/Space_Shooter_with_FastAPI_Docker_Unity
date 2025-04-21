using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{

    [SerializeField] AudioClip gemiPatlama = default;

    [SerializeField] AudioClip asteroidPatlama = default;

    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AsteroidPatlamaSesiCal()
    {
        audioSource.PlayOneShot(asteroidPatlama);
    }

    public void GemiPatlamaSesiCal()
    {
        audioSource.PlayOneShot(gemiPatlama);
    }


}