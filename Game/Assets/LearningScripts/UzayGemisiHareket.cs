using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiHareket : MonoBehaviour
{
    const float hareketGucu = 5; //karakter bu h�zda hareket etsin istiyorum onu sabit tan�mlad�m o y�zden.

    bool topluyor = false;
    
    GameObject hedef;

    Rigidbody2D myrigidbody2D;

    Toplay�c� toplay�c�;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        toplay�c� = Camera.main.GetComponent<Toplay�c�>();

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
            toplay�c�.y�ld�zYokEt(hedef);
            myrigidbody2D.velocity = Vector2.zero;// s�f�rl�yoruz h�z�n� uzay gemisinin ve sonra gitvetoplay�tekrar�a��r�phesapla�yoruz)
            GitveTopla();
            
        }
    
    }
    
    void GitveTopla() {
        hedef = toplay�c�.HedefY�ld�z;
        if (hedef != null) {
            Vector2 gidilecekYer = new Vector2(hedef.transform.position.x - transform.position.x, hedef.transform.position.y - transform.position.y);
            //Bu iki vektorel noktay� birle�tirmesi i�in normalini almam�z laz�m
            gidilecekYer.Normalize(); // mesafeyi x ve y ortas�ndan olcak �ek�le �evirir

            myrigidbody2D.AddForce(gidilecekYer * hareketGucu, ForceMode2D.Impulse);
        }
    }


    // Update is called once per frame
    void Update()
    {
       
        
        
        
        
        //Vector3 position = transform.position; //�ncelikle oyun objemin konumunu kaydediyorum position de�i�kenine;

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
