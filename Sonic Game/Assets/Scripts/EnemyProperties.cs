using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public Transform playerPos;
    float enemyHealth = 3;
    public float speed;
    void Start()
    {
        playerPos = GameObject.Find("Banana Man").transform;
    }

    // Update is called once per frame
    void Update()
    {
        HuntPlayer();
    }

    public virtual void HuntPlayer()
    {
        Vector3 target = new Vector3(playerPos.position.x, 0, playerPos.position.z);
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, step);
        transform.LookAt(playerPos);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet")
        {
            --enemyHealth;
        }

    }
}
