using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveCommandInvoker : MonoBehaviour
{
    private Queue<ICommand> _commandReplay = new Queue<ICommand>();
    private bool _isReplaying = false;
    
    public void ExcuteCommand(ICommand command)
    {
        if (_isReplaying) return;
        
        command.Execute();
        _commandReplay.Enqueue(command);
    }

    public IEnumerator ReplayCorutine()
    {
        _isReplaying = true;

        foreach (var command in _commandReplay)
        {
            command.Execute();
            yield return null;
        }
        
        _isReplaying = false;
    }

    public bool IsReplaying()
    {
        return _isReplaying;
    }
}
