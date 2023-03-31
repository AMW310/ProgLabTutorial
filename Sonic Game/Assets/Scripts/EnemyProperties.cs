using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public Transform p1pos;
    float enemyHealth = 3;
    public float speed;
    CameraBehaviour cam;
    void Start()
    {
        p1pos = CameraBehaviour.playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        HuntPlayer();
    }

    public virtual void HuntPlayer()
    {
        Vector3 target = new Vector3(p1pos.position.x, 0, p1pos.position.z);
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, step);
        transform.LookAt(p1pos);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet")
        {
            --enemyHealth;
        }

    }
}
