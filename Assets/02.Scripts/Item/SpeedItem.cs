using UnityEngine;

public class SpeedItem : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().SpeedUp(_value);
            Destroy(gameObject);
        }
    }
}