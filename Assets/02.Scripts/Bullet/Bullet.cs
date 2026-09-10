using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction = Vector2.up;
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private int _damage = 0;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.pitch = UnityEngine.Random.Range(1f, 3f);
        _audioSource.Play();
    }

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

            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(_damage);
        }
    }
}