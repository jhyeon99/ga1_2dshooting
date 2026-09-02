using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 0;
    

    void Move()
    {
        transform.position = (Vector2)transform.position + Vector2.up * speed * Time.deltaTime;   
    }

    void Update()
    {
        Move();
    }
}
