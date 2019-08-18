using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalEnemy : MonoBehaviour {
    public GameObject missile;

    float frame;
    float randomShoot;

    bool move = false;
    bool canShoot = true;

    int phase = 0;

    Rigidbody rb;

    public float offsetX = 0;

    public float randomMove = 0.03f;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        frame = Mathf.FloorToInt((3f * Mathf.PI / 2f) / randomMove);
	}
	
	void Update ()
    {
        if (Time.timeScale == 0)
            return;
        if (move == true)
        {
            transform.position = new Vector3((40 - 5 * phase) * Mathf.Sin(frame * randomMove), (rb.useGravity) ? transform.position.y : 3.5f * Mathf.Sin(frame * 5 * randomMove) + 4.5f, 25 - 7.5f * phase);
            if (phase == 2 && transform.position.x > offsetX)
            {
                Shoot();
                Destroy(this);
            }
            if (phase == 1 && transform.position.x < offsetX && canShoot == true)
            {
                Shoot();
            }
            if (frame * randomMove > (7f * Mathf.PI / 2f))
            {
                phase = 2;
            }
            else if (frame * randomMove > (5f * Mathf.PI / 2f))
            {
                phase = 1;
            }
            frame += 0.5f;
            /*if (canShoot == true)
            {
                randomShoot -= Time.deltaTime;
                if (randomShoot < 0)
                    Shoot();
            }*/
        }
    }

    void Shoot()
    {
        canShoot = false;
        if (ShipController.Instance == null)
            return;
        Vector3 dir = ShipController.Instance.transform.position - transform.position;

        Instantiate(missile, transform.position, Quaternion.LookRotation(dir));
    }

    void OnBecameVisible()
    {
        move = true;
    }
}