using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiraliYokEdici : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    GameObject UzayGemisi; //Tag(Etiket) ile yapıcaz  bu oyun objesi içinde yukarıda ki işlemi 

    List<GameObject> asteroidList = new List<GameObject>();

    GameObject hedefAsteroid;


    // Start is called before the first frame update
    void Start()
    {
        UzayGemisi = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);

            GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
            asteroidList.Add(asteroid);

        }

        if (Input.GetMouseButtonDown(1)) {
            HedefiYokEt();
        }
    }


    GameObject EnYakınAsteroid() {
        GameObject enYakınAsteroid;
        float enYakınMesafe;

        if (asteroidList.Count == 0)
        {
            return null;
        }else
        {
            enYakınAsteroid = asteroidList[0];
            enYakınMesafe = MesafeHesapla(enYakınAsteroid);
            
            foreach(GameObject asteroid in asteroidList)
            {
                float mesafe = MesafeHesapla(asteroid);
                if (mesafe < enYakınMesafe) {    
                    enYakınAsteroid = asteroid;
                    enYakınMesafe = mesafe;
                }
            }
        }
        return enYakınAsteroid;

    }

    public void HedefiYokEt() {
        hedefAsteroid = EnYakınAsteroid();
        if (hedefAsteroid != null) {
            hedefAsteroid.GetComponent<YokEdici>().asteroidYokEdici(1);
            asteroidList.Remove(hedefAsteroid);
        }
    }

    float MesafeHesapla(GameObject gameObject) 
    {
        return Vector3.Distance(UzayGemisi.transform.position, gameObject.transform.position);
    }
}
