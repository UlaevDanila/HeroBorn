using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector3 _camOffset = new Vector3(0, 1.2f, -2.6f);

    private Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        this.transform.position = _target.TransformPoint(_camOffset);
        this.transform.LookAt(_target);
    }
}
