using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    GeriSay�mSayac� gerisay�msayac�;
    
    void Start()
    {
        gerisay�msayac� = gameObject.AddComponent<GeriSay�mSayac�>();
        gerisay�msayac�.ToplamSure =1;
        gerisay�msayac�.Cal�st�r();

    }

    // Update is called once per frame
    void Update()
    {
        if (gerisay�msayac�.Bitti) {
            //Her geri say�m bitti�inde spawn etmesini istiyoruz.
            SpawnAsteroid();

            gerisay�msayac�.Cal�st�r();
        }
    }

    void SpawnAsteroid() {
        Instantiate(asteroidPrefab);
    }
}
