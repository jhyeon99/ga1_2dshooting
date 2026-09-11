using System;
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
    }

    public void OnSpawn()
    {
        // 프리팹이 활성화 될때마다
        // 초기화 하는 코드들이 들어간다.

        PlaySound();
    }

    private void PlaySound()
    {
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
            //Destroy(gameObject);
            gameObject.SetActive(false); // 비활성화

            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(_damage);
        }
    }
}