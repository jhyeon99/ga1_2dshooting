using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector2 Direction = Vector2.up;
    public float Speed = 0;

    void Move()
    {
        transform.position = (Vector2)transform.position + Direction * Speed * Time.deltaTime;
    }

    void Update()
    {
        Move();
    }
}