﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    bool moveLeft = false;
    float MoveSpeed= 3f;
    void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - (MoveSpeed*0.05f), 0, 0);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x + (MoveSpeed * 0.05f), 0, 0);
        }

        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            if (moveLeft == true)
            {
                moveLeft = false;
                transform.localPosition = new Vector3(0, 0, 0);
                MoveSpeed = Random.Range(0.5f, 3.0f);
            }
            else if (moveLeft == false)
            {
                moveLeft = true;
                transform.localPosition = new Vector3(5.3f, 0, 0);
                MoveSpeed = Random.Range(0.5f, 3.0f);
            }
        }
    }
}