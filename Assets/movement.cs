using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float speed;
    bool moving;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position += (destination - transform.position).normalized * speed * Time.deltaTime; 
        }
    }

    public void MoveTo(Vector2 dest)
    {
        destination = new Vector3(dest.x, dest.y, 0);
        moving = true;
    }
}
