using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICommand
{
    void Execute();
    void Undo();
    
}

public class MoveCommand : ICommand
{
    private Transform objectTomove;
    private Vector3 displacement;

    public MoveCommand(Transform obj, Vector3 displacement)
    {
        this.objectTomove = obj;
        this.displacement = displacement;
    }

    public void Execute() { objectTomove.position += displacement; }
    public void Undo() { objectTomove.position -= displacement;}
}

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    // Start is called before the first frame update
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }

    // Update is called once per frame
    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }


    }

}
