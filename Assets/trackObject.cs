using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackObject : MonoBehaviour
{

    [SerializeField] private Transform target;
    int speed = 5;
    float z_pos;

    // Start is called before the first frame update
    void Start()
    {
        z_pos = transform.position.z;
    }

    // Update is called once per frame (late)
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        var pos = transform.position;
        pos.z = z_pos;
        transform.position = pos;
    }
}
