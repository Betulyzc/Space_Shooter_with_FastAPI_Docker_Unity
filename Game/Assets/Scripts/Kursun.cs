using UnityEngine;

public class Kursun : MonoBehaviour
{
    GeriSay�mSayac� geriSay�mSayac�;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        geriSay�mSayac� = gameObject.AddComponent<GeriSay�mSayac�>();
        geriSay�mSayac�.ToplamSure = 3;
        geriSay�mSayac�.Cal�st�r();
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSay�mSayac�.Bitti)
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