using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;

    public Vector2 moveInput{ get; private set; }

    public Vector2 mouseDirection { get; private set; }
    public Vector2 mouseDirectionNorm { get; private set; }
    public float mouseAngle { get; private set; }

    public bool fireHook { get; private set; }

    [SerializeField] private Camera mainCam;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnFireHook(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            fireHook = true;
        }
        if (context.performed)
        {

        }
        if (context.canceled)
        {


        }
    }

    public void OnMouseDirection(InputAction.CallbackContext context)
    {
        mouseDirection = context.ReadValue<Vector2>();
        mouseDirectionNorm = mainCam.ScreenToWorldPoint(mouseDirection);
        mouseDirectionNorm = mouseDirectionNorm - new Vector2(transform.position.x, transform.position.y);
        mouseAngle = Mathf.Atan2(mouseDirectionNorm.y, mouseDirectionNorm.x) * Mathf.Rad2Deg;
    }

    public void SetFireHookInputFalse()
    {
        fireHook = false;
    }
}
