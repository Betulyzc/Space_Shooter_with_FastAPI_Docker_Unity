using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSay�mSayac� : MonoBehaviour
{

    float toplamSure = 0;
    float gecenSure = 0;

    bool cal�s�yor = false;
    bool baslad� = false;

    /// <summary>
    /// Geri Say�m Sayac�n�n Toplam S�resini Ayarlar 
    /// </summary>
    public float ToplamSure // property tan�mlad�k private bir de�i�kende de�i�iklik yapmak i�in.
    {
        set
        {
            if (!cal�s�yor) // cal�s�yor false durumunda ise yani �al��m�yorsa biz burda toplam s�reyi ayarlayaca��z.
            {
                toplamSure = value;
            }
        }
    }


    /// <summary>
    /// Geri Say�m�n bitip bitmedi�ini s�yler
    /// </summary>
    public bool Bitti
    {
        get
        {
            return baslad� && !cal�s�yor;
        }

    }


    /// <summary>
    /// Sayac� �al��t�r�r.
    /// </summary>
    public void Cal�st�r()
    {
        if (toplamSure > 0)
        {
            cal�s�yor = true;
            baslad� = true;
            gecenSure = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (cal�s�yor)
        {
            gecenSure += Time.deltaTime;
            if (gecenSure >= toplamSure)
            {
                cal�s�yor = false;
            }
        }
    }
}