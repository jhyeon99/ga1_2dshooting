using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    public float speed = 0;
    

    void Move()
    {
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;   
    }

    void Update()
    {
        Move();
    }
}
