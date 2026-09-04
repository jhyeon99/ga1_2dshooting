using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private float _healAmount = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Heal(_healAmount);
            Destroy(gameObject);
        }
    }
}