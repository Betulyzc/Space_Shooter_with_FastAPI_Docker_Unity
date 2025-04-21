using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisi
{
    int maxHiz;
    string renk;

    /// <summary>
    /// Maksimum h�z� d�nd�r�r.
    /// </summary>
    public int MaxHiz {
        get { return maxHiz; }
    }

    /// <summary>
    /// Renk D�nd�r�r.
    /// </summary>
    public string Renk {
        get { return renk; }
    }

    /// <summary>
    /// Nesne olu�turulurken h�z ve renk girilmeli.
    /// </summary>
    /// <param name="maxHiz"></param>
    /// <param name="renk"></param>
    public UzayGemisi(int maxHiz, string renk) {
        this.maxHiz = maxHiz;
        this.renk = renk;
    }

    /// <summary>
    /// Nesne Olu�turulurken sadece h�z girilmeli.
    /// </summary>
    /// <param name="maxHiz"></param>
    public UzayGemisi(int maxHiz) {
        this.maxHiz = maxHiz;
    }

    public void H�zlandirici() {
        maxHiz += Random.Range(5, 10);
        Debug.Log("H�zland�r�c� ile h�zland�r�ld�ktan sonra h�z�: "+maxHiz);
    }

    public void Yavaslatici() {
        maxHiz -= Random.Range(5, 10);
        Debug.Log("Yava�lat�ld�ktan sonra h�z: " + maxHiz);
    }
        

}
