using UnityEngine;

public class Kursun : MonoBehaviour
{
    GeriSayýmSayacý geriSayýmSayacý;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        geriSayýmSayacý = gameObject.AddComponent<GeriSayýmSayacý>();
        geriSayýmSayacý.ToplamSure = 3;
        geriSayýmSayacý.Calýstýr();
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayýmSayacý.Bitti)
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