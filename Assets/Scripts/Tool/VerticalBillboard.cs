using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBillboard : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindAnyObjectByType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        //Vector3 to = transform.position - target.position;
        //transform.rotation = Quaternion.Euler(to);
    }
}
