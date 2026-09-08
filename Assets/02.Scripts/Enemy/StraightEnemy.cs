using UnityEngine;

public class StraightEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        _direction = Vector2.down;
    }
}