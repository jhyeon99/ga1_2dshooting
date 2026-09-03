using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed = 0;

    private void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.down * Speed * Time.deltaTime;
    }
}