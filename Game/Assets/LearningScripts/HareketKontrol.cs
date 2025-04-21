using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    float colliderEnYarým;
    float colliderBoyYarým;


    void Start()
    {
        //Oyun Objesini rastgele bir kuvvet ile hareket ettir.
        Rigidbody2D myrigidbody2D = GetComponent<Rigidbody2D>();
        myrigidbody2D.AddForce(new Vector2(Random.Range(-5,5),Random.Range(-5,5)), ForceMode2D.Impulse);

        BoxCollider2D Collider = GetComponent<BoxCollider2D>();
        colliderBoyYarým = Collider.size.y / 2;
        colliderEnYarým = Collider.size.x / 2;
    }
    
    
    // Colliderlar birbirine çarptýðýnda bizim uzay gemimiz bir mesaj alýcak
    int sayaç = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        sayaç++;
        //Debug.Log("Çarpýþma: "+ sayaç);
        
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
        if (position.x - colliderEnYarým < EkranHesaplayýcý.Sol)
        {
            position.x = EkranHesaplayýcý.Sol + colliderEnYarým;
        }
        else if (position.x + colliderEnYarým > EkranHesaplayýcý.Sag)
        {
            position.x = EkranHesaplayýcý.Sag - colliderEnYarým;
        }
        
        if (position.y + colliderBoyYarým > EkranHesaplayýcý.Ust)
        {
            position.y = EkranHesaplayýcý.Ust - colliderBoyYarým;
        }
        else if (position.y - colliderEnYarým < EkranHesaplayýcý.Alt) {

            position.y = EkranHesaplayýcý.Alt + colliderBoyYarým;
        }

        transform.position = position;
            }

}
