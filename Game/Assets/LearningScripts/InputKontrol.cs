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
            position.z = -Camera.main.transform.position.z;// Her ne kadar iki boyutluda olsa oyun, bizim mouse hareketinin z kordinatýný, 
                                                           // kameraya göre referans almalýyýz yoksa  kamera objeyi görmüyor
            //position deðiþkeninin kendisi bu satýrlarda ekranýn pikseline göre ayarlandý.Onu oyun dünyasýndaki deðerlerine
            //çevirmemiz gerekiyor.Onu da aþaðýda ki þekilde yapýyoruz.
            position = Camera.main.ScreenToWorldPoint(position);

            //Farenin sol tuþuna bastýðýmda aþaðýda ayný anda 4 tane asteroid oluþuturmuþ oldum.

            for (int i = 0; i < 20 ; i++)
            {
                asteroidList.Add(Instantiate(asteroidPrefab, position, Quaternion.identity));
            }
        
        }
        // Farenin sað tuþuna bastýðýmda da ayný anda yok edicek.
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(asteroidList.Count);
            foreach (GameObject asteroid in asteroidList) {
                Destroy(asteroid);

            } 
            asteroidList.Clear(); //Bu kodun sebebi biz ekrandan yok etsekte her eklediðimiz listede kalýyor o yüzden döngü sonrasý listeyide full temizlemeliyiz.
            
            //foreach(GameObject asteroid in asteroidler){
            //    Destroy(asteroid);
            //}

        }


    }
}
