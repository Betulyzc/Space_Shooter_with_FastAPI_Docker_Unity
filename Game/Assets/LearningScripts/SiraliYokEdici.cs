using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiraliYokEdici : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    GameObject UzayGemisi; //Tag(Etiket) ile yap�caz  bu oyun objesi i�inde yukar�da ki i�lemi 

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


    GameObject EnYak�nAsteroid() {
        GameObject enYak�nAsteroid;
        float enYak�nMesafe;

        if (asteroidList.Count == 0)
        {
            return null;
        }else
        {
            enYak�nAsteroid = asteroidList[0];
            enYak�nMesafe = MesafeHesapla(enYak�nAsteroid);
            
            foreach(GameObject asteroid in asteroidList)
            {
                float mesafe = MesafeHesapla(asteroid);
                if (mesafe < enYak�nMesafe) {    
                    enYak�nAsteroid = asteroid;
                    enYak�nMesafe = mesafe;
                }
            }
        }
        return enYak�nAsteroid;

    }

    public void HedefiYokEt() {
        hedefAsteroid = EnYak�nAsteroid();
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
