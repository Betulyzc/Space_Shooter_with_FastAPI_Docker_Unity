using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UzayGemisi gemi1 = new UzayGemisi(Random.Range(80, 100));
        UzayGemisi gemi2 = new UzayGemisi(Random.Range(80, 100));

        Debug.Log("Gemi1 yavaþlatýcý Öncesi Hýzý : " + gemi1.MaxHiz);
        gemi1.Yavaslatici();

        Debug.Log("Gemi2 yavaþlatýcý Öncesi Hýzý : " + gemi2.MaxHiz);
        gemi2.Yavaslatici();

        if (gemi1.MaxHiz > gemi2.MaxHiz) {
            Debug.Log("Gemi1 kazandý.");
        }
        else 
        {
            Debug.Log("Gemi2 kazandý.");
        }
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
