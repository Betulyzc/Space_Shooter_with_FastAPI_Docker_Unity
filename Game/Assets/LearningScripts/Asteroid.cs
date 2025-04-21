using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D RGB2D = new Rigidbody2D();

        float yon = Random.Range(0f, 1.0f);
        if (yon < 0.5)
        { //bu satýrda rastgele hareket saðlamak için kod yazdým.
            RGB2D.AddForce(new Vector2(Random.Range(-2.5f, -1.0f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);// bu koþul gerçeklirse sola doðru bir açýyla gidicek

        }
        else
        {
            RGB2D.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
