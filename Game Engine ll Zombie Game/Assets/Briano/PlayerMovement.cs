using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerMovement player;
    private Transform m_Cam;
    private Vector3 m_CamForward;
    private Vector3 m_Move;
    private bool m_Jump;
    float h = 0;
    float v = 0;
    bool jumping = false;
    bool crouch = false;
    bool walk = false;

    void Start()
    {
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
        }
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!m_Jump)
        {
            m_Jump = jumping;
            jumping = false;
        }
    }

    private void FixedUpdate()
    {
        if (m_Cam != null)
        {
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            m_Move = v * Vector3.forward + h * Vector3.right;
        }
    }

public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        h = value.x;
        v = value.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            jumping = true;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            crouch = !crouch;
        }
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        walk = context.performed;
    }
}
