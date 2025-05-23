using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EkranHesaplayıcı
{
    static float sol;
    static float sag;
    static float ust;
    static float alt;


    /// <summary>
    /// Ekranın sol kenarının kordinatlarını verir.
    /// </summary>
    public static float Sol
    {
        get
        {
            return sol;
        }
    }

    /// <summary>
    /// Ekranın sağ kenarının kordinatlarını verir.
    /// </summary>
    public static float Sag
    {
        get
        {
            return sag;
        }
    }

    /// <summary>
    /// Ekranın üst kenarının kordinatlarını verir.
    /// </summary>
    public static float Ust
    {
        get
        {
            return ust;
        }
    }

    /// <summary>
    /// Ekranın alt kenarının kordinatlarını verir.
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

        Vector3 SolAltKoseOyunDünyası = Camera.main.ScreenToWorldPoint(solAltKose);
        Vector3 SagUstKoseOyunDünyası = Camera.main.ScreenToWorldPoint(sagUstKose);

        sol = SolAltKoseOyunDünyası.x;
        alt = SolAltKoseOyunDünyası.y;
        sag = SagUstKoseOyunDünyası.x;
        ust = SagUstKoseOyunDünyası.y;

    }

}