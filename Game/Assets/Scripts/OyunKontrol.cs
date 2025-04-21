using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField] GameObject UzayGemisiPrefab;
    GameObject uzayGemisi;
    [SerializeField] GameObject patlamaPrefab;

    [SerializeField] List<GameObject> asteroidPrefabs = new List<GameObject>();

    List<GameObject> asteroidler = new List<GameObject>();

    [SerializeField] GameObject oynaButonu;

    UIKontrol uikontrol;

    int zorluk = 1;


    [SerializeField] int kat;

    void Start()
    {
        uikontrol = GetComponent<UIKontrol>();
    }

    public void OyunuBaslat()
    {

        uikontrol.OyunBasladý();
        uzayGemisi = Instantiate(UzayGemisiPrefab);
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayýcý.Alt + 1.5f);
        AsteroidUret(5);
    }



    void AsteroidUret(int adet)
    {
        Vector3 position = new Vector3();

        for (int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(EkranHesaplayýcý.Sol, EkranHesaplayýcý.Sag);
            position.y = EkranHesaplayýcý.Ust - 1;
            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity);
            asteroidler.Add(asteroid);
        }

    }

    public void AsteroidYokOldu(GameObject gameobject)
    {
        uikontrol.asteroidPuanEkle(gameobject);
        asteroidler.Remove(gameobject);
        if (asteroidler.Count <= zorluk)
        {
            zorluk++;
            AsteroidUret(zorluk * kat);

        }

    }

    public void SonTemizleyici()
    {
        foreach (GameObject asteroid in asteroidler)
        {
            Instantiate(patlamaPrefab, asteroid.transform.position, Quaternion.identity);
            Destroy(asteroid);
        }
        asteroidler.Clear();
        zorluk = 1;

    }





}