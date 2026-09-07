using UnityEngine;

public class StraightEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        Direction = Vector2.down;
    }
}