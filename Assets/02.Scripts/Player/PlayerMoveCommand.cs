using UnityEngine;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
}

public class PlayerMoveCommand : ICommand
{
    private readonly Transform _playerTransform;
    private readonly Vector2 _targetPosition;

    public PlayerMoveCommand(Transform playerTransform, Vector2 targetPosition)
    {
        _playerTransform = playerTransform;
        _targetPosition = targetPosition;
    }

    public void Execute()
    {
        _playerTransform.position = _targetPosition;
    }
}