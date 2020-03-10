using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    public void ExecuteCommand(Command command)
    {
        command.Execute();
    }
}
