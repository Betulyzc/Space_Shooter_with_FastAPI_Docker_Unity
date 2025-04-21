using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayımTest : MonoBehaviour
{
    GeriSayımSayacı geriSayımSayacı;
    float baslangıcZamanı;

    // Start is called before the first frame update
    void Start()
    {
        geriSayımSayacı = gameObject.AddComponent<GeriSayımSayacı>();
        geriSayımSayacı.ToplamSure = 3;
        geriSayımSayacı.Calıstır();

        baslangıcZamanı = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayımSayacı.Bitti) {

            float gecenSure = Time.time - baslangıcZamanı;
            Debug.Log(gecenSure);

            baslangıcZamanı = Time.time;
            geriSayımSayacı.Calıstır();
        }
    }
}
