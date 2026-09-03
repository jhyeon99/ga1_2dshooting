using UnityEngine;

public class StraightEnemy : Enemy
{
    protected override void GetDirection()
    {
        Direction = Vector2.down;
    }
}