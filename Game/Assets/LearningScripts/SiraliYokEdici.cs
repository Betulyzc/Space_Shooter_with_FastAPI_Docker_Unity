using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiraliYokEdici : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    GameObject UzayGemisi; //Tag(Etiket) ile yapýcaz  bu oyun objesi içinde yukarýda ki iþlemi 

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


    GameObject EnYakýnAsteroid() {
        GameObject enYakýnAsteroid;
        float enYakýnMesafe;

        if (asteroidList.Count == 0)
        {
            return null;
        }else
        {
            enYakýnAsteroid = asteroidList[0];
            enYakýnMesafe = MesafeHesapla(enYakýnAsteroid);
            
            foreach(GameObject asteroid in asteroidList)
            {
                float mesafe = MesafeHesapla(asteroid);
                if (mesafe < enYakýnMesafe) {    
                    enYakýnAsteroid = asteroid;
                    enYakýnMesafe = mesafe;
                }
            }
        }
        return enYakýnAsteroid;

    }

    public void HedefiYokEt() {
        hedefAsteroid = EnYakýnAsteroid();
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
