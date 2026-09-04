using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction = Vector2.up;
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private int _damage = 0;

    void Move()
    {
        transform.position = (Vector2)transform.position + Direction * _moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            var enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(_damage);
        }
    }
}