using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EkranHesaplayýcý
{
    static float sol;
    static float sag;
    static float ust;
    static float alt;


    /// <summary>
    /// Ekranýn sol kenarýnýn kordinatlarýný verir.
    /// </summary>
    public static float Sol
    {
        get
        {
            return sol;
        }
    }

    /// <summary>
    /// Ekranýn sað kenarýnýn kordinatlarýný verir.
    /// </summary>
    public static float Sag
    {
        get
        {
            return sag;
        }
    }

    /// <summary>
    /// Ekranýn üst kenarýnýn kordinatlarýný verir.
    /// </summary>
    public static float Ust
    {
        get
        {
            return ust;
        }
    }

    /// <summary>
    /// Ekranýn alt kenarýnýn kordinatlarýný verir.
    /// </summary>
    public static float Alt
    {
        get
        {
            return alt;
        }
    }


    public static void Init()
    {
        float ekranZekseni = -Camera.main.transform.position.z;
        Vector3 solAltKose = new Vector3(0, 0, ekranZekseni);
        Vector3 sagUstKose = new Vector3(Screen.width, Screen.height, ekranZekseni);

        Vector3 SolAltKoseOyunDünyasý = Camera.main.ScreenToWorldPoint(solAltKose);
        Vector3 SagUstKoseOyunDünyasý = Camera.main.ScreenToWorldPoint(sagUstKose);

        sol = SolAltKoseOyunDünyasý.x;
        alt = SolAltKoseOyunDünyasý.y;
        sag = SagUstKoseOyunDünyasý.x;
        ust = SagUstKoseOyunDünyasý.y;

    }

}