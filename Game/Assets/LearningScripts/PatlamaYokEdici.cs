using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaYokEdici : MonoBehaviour
{
    GeriSay�mSayac� gerisay�msayac�;

    //SiraliYokEdici s�ral�YokEdici;

    
    void Start()
    {
        gerisay�msayac� = gameObject.AddComponent<GeriSay�mSayac�>();
       //s�ral�YokEdici = Camera.main.GetComponent<SiraliYokEdici>();
        gerisay�msayac�.ToplamSure = 1;
        gerisay�msayac�.Cal�st�r();
       


    }

    // Update is called once per frame
    void Update()
    {
        if (gerisay�msayac�.Bitti) {
            //s�ral�YokEdici.HedefiYokEt();
            Destroy(gameObject);
        }
    }
}
