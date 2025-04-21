using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemiKontrol : MonoBehaviour
{
    const float hareketGucu = 5;

    [SerializeField] GameObject kursunPrefab;

    [SerializeField] GameObject patlamaPrefab;

    UIKontrol uIKontrol;


    void Start()
    {
        uIKontrol = Camera.main.GetComponent<UIKontrol>();

    }

    void Update()
    {

        Vector3 position = transform.position;
        float yatayInput = Input.GetAxis("Horizontal");
        float dikeyInput = Input.GetAxis("Vertical");

        if (yatayInput != 0)
        {
            position.x += hareketGucu * yatayInput * Time.deltaTime;
        }

        if (dikeyInput != 0)
        {
            position.y += hareketGucu * dikeyInput * Time.deltaTime;
        }

        transform.position = position;


        if (Input.GetButtonDown("Jump"))
        {
            Vector3 uzayGemisiPosition = gameObject.transform.position;
            uzayGemisiPosition.y += 2;
            Instantiate(kursunPrefab, uzayGemisiPosition, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().GemiPatlamaSesiCal();
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            uIKontrol.OyunBitti();
        }

    }
}


