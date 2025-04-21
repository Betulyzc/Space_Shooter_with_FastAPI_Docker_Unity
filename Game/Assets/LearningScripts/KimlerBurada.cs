using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimlerBurada : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //Play tuşuna bastığımda GameObjectler mesaj göndermeli.
      int zırh=50;
      int sağlık=100;
      int toplamCan=zırh - sağlık;
      Debug.Log("Zırh: " + zırh + " Sağlık: " + sağlık + " Toplam Can: " + toplamCan);

    }

    
    
}
