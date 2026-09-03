using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100;
    public float MoveSpeed = 0;

    private void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.down * MoveSpeed * Time.deltaTime;
    }
}