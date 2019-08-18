using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
