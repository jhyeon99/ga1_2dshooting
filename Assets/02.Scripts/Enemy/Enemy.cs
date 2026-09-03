using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float Health = 100;
    protected Vector2 Direction = Vector2.zero;
    public float MoveSpeed = 0;

    private void Start()
    {
        GetDirection();
    }

    private void Move()
    {
        transform.Translate(Direction * MoveSpeed * Time.deltaTime);
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void GetDirection();
}