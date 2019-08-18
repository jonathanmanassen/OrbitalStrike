using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeShip : MonoBehaviour {

    public GameObject EnemyExplosion;
    public GameObject Explosion;
    public GameObject Smoke;

    Rigidbody rb;

    bool drop = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (drop)
        {
            transform.Rotate(0, 10, 0);
        }
        if (transform.position.y < 0)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            EnemyController tmp;
            if (transform.parent != null && (tmp = transform.parent.GetComponent<EnemyController>()))
                tmp.ShipDestroyed(transform.position, transform.name);
            Destroy(gameObject);
        }
    }
	
	void OnCollisionEnter (Collision col)
    {
        if (col.transform.CompareTag("Missile"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.useGravity = true;
            drop = true;
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            Instantiate(Smoke, transform);
        }
        else if (col.transform.CompareTag("Ground"))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            EnemyController tmp;
            if (transform.parent != null && (tmp = transform.parent.GetComponent<EnemyController>()))
                tmp.ShipDestroyed(transform.position, transform.name);
            Destroy(gameObject);
        }
    }
}
