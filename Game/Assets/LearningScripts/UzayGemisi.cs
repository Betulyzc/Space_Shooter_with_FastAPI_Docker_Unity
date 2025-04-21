using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisi
{
    int maxHiz;
    string renk;

    /// <summary>
    /// Maksimum hýzý döndürür.
    /// </summary>
    public int MaxHiz {
        get { return maxHiz; }
    }

    /// <summary>
    /// Renk Döndürür.
    /// </summary>
    public string Renk {
        get { return renk; }
    }

    /// <summary>
    /// Nesne oluþturulurken hýz ve renk girilmeli.
    /// </summary>
    /// <param name="maxHiz"></param>
    /// <param name="renk"></param>
    public UzayGemisi(int maxHiz, string renk) {
        this.maxHiz = maxHiz;
        this.renk = renk;
    }

    /// <summary>
    /// Nesne Oluþturulurken sadece hýz girilmeli.
    /// </summary>
    /// <param name="maxHiz"></param>
    public UzayGemisi(int maxHiz) {
        this.maxHiz = maxHiz;
    }

    public void Hýzlandirici() {
        maxHiz += Random.Range(5, 10);
        Debug.Log("Hýzlandýrýcý ile hýzlandýrýldýktan sonra hýzý: "+maxHiz);
    }

    public void Yavaslatici() {
        maxHiz -= Random.Range(5, 10);
        Debug.Log("Yavaþlatýldýktan sonra hýz: " + maxHiz);
    }
        

}
