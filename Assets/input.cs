using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input : MonoBehaviour
{
    bool holding;
    Vector2 cursorPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMovement()
    {
        GetComponent<movement>().MoveTo(cursorPosition);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        var pointerLoc = ctx.ReadValue<Vector2>();
        var worldLoc = Camera.main.ScreenToWorldPoint(pointerLoc);
        cursorPosition = worldLoc;
        if (holding)
        {
            UpdateMovement();
        }
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
}
