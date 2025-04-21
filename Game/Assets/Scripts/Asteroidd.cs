using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidd : MonoBehaviour
{
    [SerializeField] GameObject patlamaPrefeb;

    OyunKontrol oyunKontrol;

    void Start()
    {
        Rigidbody2D rgbd = GetComponent<Rigidbody2D>();
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();


        float yon = Random.Range(0f, 1.0f);

        if (yon < 0.5f)
        {
            rgbd.AddForce(new Vector2(Random.Range(-1.0f, -2.5f), Random.Range(-1.0f, -2.5f)), ForceMode2D.Impulse);
            rgbd.AddTorque(yon * 2.0f);

        }
        else
        {
            rgbd.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rgbd.AddTorque(yon * 2.0f);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Kursun")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().AsteroidPatlamaSesiCal();
            oyunKontrol.AsteroidYokOldu(gameObject);
            Instantiate(patlamaPrefeb, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}