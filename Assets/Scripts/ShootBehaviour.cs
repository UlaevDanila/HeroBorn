using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletVelocity;
    private bool _isEnable;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) _isEnable = true;
        else _isEnable = false;
    }

    private void FixedUpdate()
    {
        if(_isEnable)
        {
            GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(2, 0, 0),
                transform.rotation);
            Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();

            rigidbody.velocity = transform.forward * bulletVelocity;
        }
    }
}
