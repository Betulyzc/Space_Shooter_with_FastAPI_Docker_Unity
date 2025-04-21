using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayıcı : MonoBehaviour
{

    [SerializeField] GameObject yıldızPrefab;

    List<GameObject> yıldızlar = new List<GameObject>();
    
    /// <summary>
    /// Hedefteki yıldızı söyler.
    /// </summary>
    public GameObject HedefYıldız   
    {
        get
        {
            if (yıldızlar.Count > 0)
            {
                return yıldızlar[0];
            }
            else {
                return null;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            Vector3 oyunDünyasıKonum = Camera.main.ScreenToWorldPoint(position);
            yıldızlar.Add(Instantiate(yıldızPrefab, oyunDünyasıKonum, Quaternion.identity));
        }

        //if (Input.GetMouseButtonDown(0)) {
        //    Debug.Log("Yıldızlar Listesi Eleman Sayısı: " + yıldızlar.Count);
        //}
           
    }
    
    /// <summary>
    ///parametre olarak gönderilen yıldızı yok eder.
    /// </summary>
    /// <param name="yokEdilecekYıldız"></param>
    public void yıldızYokEt(GameObject yokEdilecekYıldız) {
        
        yıldızlar.Remove(yokEdilecekYıldız); //Bu satırda listeden siliyorum.
        Destroy(yokEdilecekYıldız); // Bu satırda da oyun ekranından siliyorum.

    }
}
