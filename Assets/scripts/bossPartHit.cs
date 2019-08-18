﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPartHit : MonoBehaviour {

    public GameObject explosion;
    public bool isCore = false;

    FinalBossBehaviour boss;

	// Use this for initialization
	void Start () {
        boss = transform.parent.parent.GetComponent<FinalBossBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        Instantiate(explosion, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, col.contacts[0].point.z), Quaternion.identity);
        if (isCore == false)
            gameObject.SetActive(false);
        boss.PartHit(isCore);
    }
}