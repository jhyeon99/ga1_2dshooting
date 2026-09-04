using UnityEngine;

public class AttackspeedItem : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().AttackspeedUp();
            Destroy(gameObject);
        }
    }
}