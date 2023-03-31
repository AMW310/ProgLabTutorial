using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Manager mgRef;
    int count;
    void Start()
    {
        count = Manager.coinCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Banana Man")
        {
            count++;
            Destroy(this.gameObject);
        }
    }
}
