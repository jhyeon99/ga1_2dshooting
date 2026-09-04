using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private float _speedUpAmount = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().SpeedUp(_speedUpAmount);
            Destroy(gameObject);
        }
    }
}