using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    float colliderEnYar�m;
    float colliderBoyYar�m;


    void Start()
    {
        //Oyun Objesini rastgele bir kuvvet ile hareket ettir.
        Rigidbody2D myrigidbody2D = GetComponent<Rigidbody2D>();
        myrigidbody2D.AddForce(new Vector2(Random.Range(-5,5),Random.Range(-5,5)), ForceMode2D.Impulse);

        BoxCollider2D Collider = GetComponent<BoxCollider2D>();
        colliderBoyYar�m = Collider.size.y / 2;
        colliderEnYar�m = Collider.size.x / 2;
    }
    
    
    // Colliderlar birbirine �arpt���nda bizim uzay gemimiz bir mesaj al�cak
    int saya� = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        saya�++;
        //Debug.Log("�arp��ma: "+ saya�);
        
    }
   


    // Update is called once per frame
    void Update()
    {
        //Asteroid mouse imlecini takip etsin.
        //Vector3 position = Input.mousePosition;
        //position.z = -Camera.main.transform.position.z;
        //position = Camera.main.ScreenToWorldPoint(position);
        //transform.position = position;
        EkrandaKal();
    }
    void EkrandaKal() {
        Vector3 position = transform.position;
        if (position.x - colliderEnYar�m < EkranHesaplay�c�.Sol)
        {
            position.x = EkranHesaplay�c�.Sol + colliderEnYar�m;
        }
        else if (position.x + colliderEnYar�m > EkranHesaplay�c�.Sag)
        {
            position.x = EkranHesaplay�c�.Sag - colliderEnYar�m;
        }
        
        if (position.y + colliderBoyYar�m > EkranHesaplay�c�.Ust)
        {
            position.y = EkranHesaplay�c�.Ust - colliderBoyYar�m;
        }
        else if (position.y - colliderEnYar�m < EkranHesaplay�c�.Alt) {

            position.y = EkranHesaplay�c�.Alt + colliderBoyYar�m;
        }

        transform.position = position;
            }

}
