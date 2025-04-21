using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKontrol : MonoBehaviour
{
    
    [SerializeField] GameObject asteroidPrefab;

    //GameObject[] asteroidler = new GameObject[4];
    List<GameObject> asteroidList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        { 

            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;// Her ne kadar iki boyutluda olsa oyun, bizim mouse hareketinin z kordinat�n�, 
                                                           // kameraya g�re referans almal�y�z yoksa  kamera objeyi g�rm�yor
            //position de�i�keninin kendisi bu sat�rlarda ekran�n pikseline g�re ayarland�.Onu oyun d�nyas�ndaki de�erlerine
            //�evirmemiz gerekiyor.Onu da a�a��da ki �ekilde yap�yoruz.
            position = Camera.main.ScreenToWorldPoint(position);

            //Farenin sol tu�una bast���mda a�a��da ayn� anda 4 tane asteroid olu�uturmu� oldum.

            for (int i = 0; i < 20 ; i++)
            {
                asteroidList.Add(Instantiate(asteroidPrefab, position, Quaternion.identity));
            }
        
        }
        // Farenin sa� tu�una bast���mda da ayn� anda yok edicek.
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(asteroidList.Count);
            foreach (GameObject asteroid in asteroidList) {
                Destroy(asteroid);

            } 
            asteroidList.Clear(); //Bu kodun sebebi biz ekrandan yok etsekte her ekledi�imiz listede kal�yor o y�zden d�ng� sonras� listeyide full temizlemeliyiz.
            
            //foreach(GameObject asteroid in asteroidler){
            //    Destroy(asteroid);
            //}

        }


    }
}
