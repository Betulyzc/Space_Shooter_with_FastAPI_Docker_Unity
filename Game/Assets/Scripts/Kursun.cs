using UnityEngine;

public class Kursun : MonoBehaviour
{
    GeriSayımSayacı geriSayımSayacı;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        geriSayımSayacı = gameObject.AddComponent<GeriSayımSayacı>();
        geriSayımSayacı.ToplamSure = 3;
        geriSayımSayacı.Calıstır();
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayımSayacı.Bitti)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Asteroid") ;
        Destroy(gameObject);
    }
}