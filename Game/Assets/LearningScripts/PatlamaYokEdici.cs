using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaYokEdici : MonoBehaviour
{
    GeriSayımSayacı gerisayımsayacı;

    //SiraliYokEdici sıralıYokEdici;

    
    void Start()
    {
        gerisayımsayacı = gameObject.AddComponent<GeriSayımSayacı>();
       //sıralıYokEdici = Camera.main.GetComponent<SiraliYokEdici>();
        gerisayımsayacı.ToplamSure = 1;
        gerisayımsayacı.Calıstır();
       


    }

    // Update is called once per frame
    void Update()
    {
        if (gerisayımsayacı.Bitti) {
            //sıralıYokEdici.HedefiYokEt();
            Destroy(gameObject);
        }
    }
}
