using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    bool holding;
    Vector2 cursorPosition;
    Vector2 pointerLoc;

    Movement movement;
    ActionManager actions;

    void Start()
    {
        movement = GetComponent<Movement>();
        actions = GetComponent<ActionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(pointerLoc);
        if (holding)
        {
            UpdateMovement();
        }
    }

    void UpdateMovement()
    {
        GetComponent<Movement>().MoveTo(cursorPosition);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        pointerLoc = ctx.ReadValue<Vector2>();
    }

    public void Click(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            holding = true;
            UpdateMovement();
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            holding = false;
        }
    }

    public void Action1(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            actions.Action1Used(cursorPosition);
        }
    }
}
