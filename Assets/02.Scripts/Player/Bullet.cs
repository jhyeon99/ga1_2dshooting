using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction = Vector2.up;
    public float MoveSpeed = 0;
    public float Damage = 0;

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

            var enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.Health -= Damage;
            if (enemyScript.Health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}