using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokEdici : MonoBehaviour
{
    [SerializeField] GameObject patlamaPrefab;

    GeriSayımSayacı yokEdiciGeriSayım;

    void Start()
    {
        yokEdiciGeriSayım = gameObject.AddComponent<GeriSayımSayacı>();
    }

    void Update()
    {
        if (yokEdiciGeriSayım.Bitti)
        {
            GameObject fx = Instantiate(patlamaPrefab, transform.position, Quaternion.identity);
            Destroy(fx, 2f); 
            Destroy(gameObject);
        }
    }

    public void asteroidYokEdici(int sure)
    {
        yokEdiciGeriSayım.ToplamSure = sure;
        yokEdiciGeriSayım.Calıstır();
    }
}
