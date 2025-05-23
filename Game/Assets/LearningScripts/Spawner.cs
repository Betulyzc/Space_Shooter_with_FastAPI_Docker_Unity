using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    GeriSayımSayacı gerisayımsayacı;
    
    void Start()
    {
        gerisayımsayacı = gameObject.AddComponent<GeriSayımSayacı>();
        gerisayımsayacı.ToplamSure =1;
        gerisayımsayacı.Calıstır();

    }

    // Update is called once per frame
    void Update()
    {
        if (gerisayımsayacı.Bitti) {
            //Her geri sayım bittiğinde spawn etmesini istiyoruz.
            SpawnAsteroid();

            gerisayımsayacı.Calıstır();
        }
    }

    void SpawnAsteroid() {
        Instantiate(asteroidPrefab);
    }
}
