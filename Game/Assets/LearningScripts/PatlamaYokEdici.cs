using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaYokEdici : MonoBehaviour
{
    GeriSayýmSayacý gerisayýmsayacý;

    //SiraliYokEdici sýralýYokEdici;

    
    void Start()
    {
        gerisayýmsayacý = gameObject.AddComponent<GeriSayýmSayacý>();
       //sýralýYokEdici = Camera.main.GetComponent<SiraliYokEdici>();
        gerisayýmsayacý.ToplamSure = 1;
        gerisayýmsayacý.Calýstýr();
       


    }

    // Update is called once per frame
    void Update()
    {
        if (gerisayýmsayacý.Bitti) {
            //sýralýYokEdici.HedefiYokEt();
            Destroy(gameObject);
        }
    }
}
