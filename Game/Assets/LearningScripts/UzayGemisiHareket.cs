using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiHareket : MonoBehaviour
{
    const float hareketGucu = 5; //karakter bu hýzda hareket etsin istiyorum onu sabit tanýmladým o yüzden.

    bool topluyor = false;
    
    GameObject hedef;

    Rigidbody2D myrigidbody2D;

    Toplayýcý toplayýcý;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        toplayýcý = Camera.main.GetComponent<Toplayýcý>();

    }

    void OnMouseDown()//OnMouseDown is called when the user has pressed the mouse button while over the Collider.
    {
        if (!topluyor) {
            GitveTopla();
        }
    }

    void OnTriggerStay2D(Collider2D collider) 
    {
        if (collider.gameObject == hedef)
        {
            toplayýcý.yýldýzYokEt(hedef);
            myrigidbody2D.velocity = Vector2.zero;// sýfýrlýyoruz hýzýný uzay gemisinin ve sonra gitvetoplayýtekrarçaðýrýphesaplaýyoruz)
            GitveTopla();
            
        }
    
    }
    
    void GitveTopla() {
        hedef = toplayýcý.HedefYýldýz;
        if (hedef != null) {
            Vector2 gidilecekYer = new Vector2(hedef.transform.position.x - transform.position.x, hedef.transform.position.y - transform.position.y);
            //Bu iki vektorel noktayý birleþtirmesi için normalini almamýz lazým
            gidilecekYer.Normalize(); // mesafeyi x ve y ortasýndan olcak þekÝle çevirir

            myrigidbody2D.AddForce(gidilecekYer * hareketGucu, ForceMode2D.Impulse);
        }
    }


    // Update is called once per frame
    void Update()
    {
       
        
        
        
        
        //Vector3 position = transform.position; //öncelikle oyun objemin konumunu kaydediyorum position deðiþkenine;

        //float yatayInput = Input.GetAxis("Horizontal");
        //float dikeyInput = Input.GetAxis("Vertical");

        //if (yatayInput != 0)
        //{
        //    position.x += hareketGucu * yatayInput * Time.deltaTime;
        //}

        //if (dikeyInput != 0) {
        //    position.y += hareketGucu * dikeyInput * Time.deltaTime;
        //}

        //transform.position = position;

      
    }
}
