using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] public Transform player;
    public bool cursorLock = false;
    private Vector2 deltaMouse = new Vector2(0, 0);
    private float turnSpeed = 100f;
    private float rotX = 0;

    void Awake()
    {
        ChangeCursor();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float x = deltaMouse.x * turnSpeed * Time.deltaTime;
        float y = deltaMouse.y * turnSpeed * Time.deltaTime;
        rotX -= y;
        rotX = Mathf.Clamp(rotX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        player.Rotate(Vector3.up * x);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        deltaMouse = context.ReadValue<Vector2>();
    }

    public void ChangeCursor()
    {
        cursorLock = cursorLock ? false : true;
        Cursor.lockState = cursorLock ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !cursorLock;
    }
}
