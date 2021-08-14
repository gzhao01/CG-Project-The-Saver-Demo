using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    private int faceDirection;
    public float moveSpeed;

    [Header("Hook")]
    [SerializeField] private Transform hookEnd;
    [SerializeField] private Transform hookDirection;
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyHookDirection();
    }

    private void ApplyMovement()
    {
        rb.velocity = InputHandler.Instance.moveInput * moveSpeed;
    }

    private void ApplyHookDirection()
    {
        hookDirection.localRotation = Quaternion.Euler(0, 0, InputHandler.Instance.mouseAngle);
    }

    private void ApplyHook()
    {
        if (InputHandler.Instance.fireHook)
        {
            InputHandler.Instance.SetFireHookInputFalse();

        }
    }

    private void Flip()
    {
        faceDirection *= -1;
        transform.Rotate(0,-180,0);
    }
}
