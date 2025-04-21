using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    GeriSayýmSayacý gerisayýmsayacý;
    
    void Start()
    {
        gerisayýmsayacý = gameObject.AddComponent<GeriSayýmSayacý>();
        gerisayýmsayacý.ToplamSure =1;
        gerisayýmsayacý.Calýstýr();

    }

    // Update is called once per frame
    void Update()
    {
        if (gerisayýmsayacý.Bitti) {
            //Her geri sayým bittiðinde spawn etmesini istiyoruz.
            SpawnAsteroid();

            gerisayýmsayacý.Calýstýr();
        }
    }

    void SpawnAsteroid() {
        Instantiate(asteroidPrefab);
    }
}
