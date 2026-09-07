using UnityEngine;

public class HealthItem : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Heal(_value);
            Destroy(gameObject);
        }
    }
}