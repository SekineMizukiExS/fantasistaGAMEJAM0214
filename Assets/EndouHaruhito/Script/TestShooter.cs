﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooter : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Instantiate(bullet,transform.position,transform.rotation);
            bullet.GetComponent<Bullet>().Fire(gameObject,true);
        }
    }
}
