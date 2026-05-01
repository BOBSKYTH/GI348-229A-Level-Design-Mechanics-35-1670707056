using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;

    Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        // 👉 ถึงจุดแล้วสลับเป้า
        if (Vector2.Distance(transform.position, target) < 0.05f)
        {
            if (target == pointA.position)
                target = pointB.position;
            else
                target = pointA.position;
        }
        
    }
}