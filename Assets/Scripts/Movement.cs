using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    float speed;
    bool moving;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 2;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            var delta = destination - transform.position;
            if (delta.magnitude < 0.1)
            {
                moving = false;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.velocity = delta.normalized * speed;
                PointInDirection();
            }
        }
    }

    public void MoveTo(Vector2 dest)
    {
        destination = new Vector3(dest.x, dest.y, 0);
        moving = true;
    }

    public void PointInDirection()
    {
        float angle = Mathf.Atan2(body.velocity.y, body.velocity.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
