using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction = Vector2.up;
    public float MoveSpeed = 0;

    void Move()
    {
        transform.position = (Vector2)transform.position + Direction * MoveSpeed * Time.deltaTime;
    }

    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}