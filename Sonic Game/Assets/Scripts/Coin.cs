using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Banana Man")
        {
            Manager.coinCount++;
            Destroy(this.gameObject);
        }
    }
}
