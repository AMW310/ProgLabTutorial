using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyProperties
{
    float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance();
        Debug.Log(distance);
    }

    void PlayerDistance()
    {
        distance = Vector3.Distance(p1pos.position,this.transform.position);
    }
}
