using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    float colliderEnYarım;
    float colliderBoyYarım;


    void Start()
    {
        //Oyun Objesini rastgele bir kuvvet ile hareket ettir.
        Rigidbody2D myrigidbody2D = GetComponent<Rigidbody2D>();
        myrigidbody2D.AddForce(new Vector2(Random.Range(-5,5),Random.Range(-5,5)), ForceMode2D.Impulse);

        BoxCollider2D Collider = GetComponent<BoxCollider2D>();
        colliderBoyYarım = Collider.size.y / 2;
        colliderEnYarım = Collider.size.x / 2;
    }
    
    
    // Colliderlar birbirine çarptığında bizim uzay gemimiz bir mesaj alıcak
    int sayaç = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        sayaç++;
        //Debug.Log("Çarpışma: "+ sayaç);
        
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
        if (position.x - colliderEnYarım < EkranHesaplayıcı.Sol)
        {
            position.x = EkranHesaplayıcı.Sol + colliderEnYarım;
        }
        else if (position.x + colliderEnYarım > EkranHesaplayıcı.Sag)
        {
            position.x = EkranHesaplayıcı.Sag - colliderEnYarım;
        }
        
        if (position.y + colliderBoyYarım > EkranHesaplayıcı.Ust)
        {
            position.y = EkranHesaplayıcı.Ust - colliderBoyYarım;
        }
        else if (position.y - colliderEnYarım < EkranHesaplayıcı.Alt) {

            position.y = EkranHesaplayıcı.Alt + colliderBoyYarım;
        }

        transform.position = position;
            }

}
