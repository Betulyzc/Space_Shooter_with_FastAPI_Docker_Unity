using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayýmSayacý : MonoBehaviour
{

    float toplamSure = 0;
    float gecenSure = 0;

    bool calýsýyor = false;
    bool basladý = false;

    /// <summary>
    /// Geri Sayým Sayacýnýn Toplam Süresini Ayarlar 
    /// </summary>
    public float ToplamSure // property tanýmladýk private bir deðiþkende deðiþiklik yapmak için.
    {
        set
        {
            if (!calýsýyor) // calýsýyor false durumunda ise yani çalýþmýyorsa biz burda toplam süreyi ayarlayacaðýz.
            {
                toplamSure = value;
            }
        }
    }


    /// <summary>
    /// Geri Sayýmýn bitip bitmediðini söyler
    /// </summary>
    public bool Bitti
    {
        get
        {
            return basladý && !calýsýyor;
        }

    }


    /// <summary>
    /// Sayacý Çalýþtýrýr.
    /// </summary>
    public void Calýstýr()
    {
        if (toplamSure > 0)
        {
            calýsýyor = true;
            basladý = true;
            gecenSure = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (calýsýyor)
        {
            gecenSure += Time.deltaTime;
            if (gecenSure >= toplamSure)
            {
                calýsýyor = false;
            }
        }
    }
}