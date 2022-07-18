using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    public void Activate(Vector3 mousePosition);
}

public class NullAction : IAction
{
    public void Activate(Vector3 _)
    {
        Debug.Log("null action triggered");
    }
}

public class ActionManager : MonoBehaviour
{
    IAction action1;

    // Start is called before the first frame update
    public void Start()
    {
        action1 = new NullAction();
    }

    public void Action1Used(Vector3 mouse)
    {
        action1.Activate(mouse);
    }
}
