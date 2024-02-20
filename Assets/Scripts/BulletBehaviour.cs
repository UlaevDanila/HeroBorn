using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float timeToDelay;

    private void Update()
    {
        Destroy(this.gameObject, timeToDelay);
    }
}
