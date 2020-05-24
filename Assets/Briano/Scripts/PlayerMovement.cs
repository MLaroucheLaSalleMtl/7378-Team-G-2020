using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public CharacterController player;
    [Range(0.5f, 10f)] public float speed;
    public float h;
    public float v;
    private Vector3 moveDirection;
    public Animator playerAnim;

    float footStepTimer = 0.5f;
    float currentTime = 0f;
    Vector3 velocity;
    public float gravity = -100;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(h == 0 && v ==0)
        {
            playerAnim.SetInteger("Condition", 0);
        }
        moveDirection = new Vector3(h, 0, v);
        moveDirection *= speed;
        moveDirection = transform.TransformDirection(moveDirection);
        player.Move(moveDirection * Time.deltaTime);
        velocity.y = gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
        currentTime += Time.deltaTime;
        if(currentTime >= footStepTimer)
        {
            currentTime = 0f;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerAnim.SetInteger("Condition", 1);
        Vector2 value = context.ReadValue<Vector2>();
        h = value.x;
        v = value.y;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            speed *= 2;
            playerAnim.speed = 2;
        }
        if (context.canceled)
        {
            Debug.Log(speed);
            speed /= 2; 
            playerAnim.speed = 1 ;
            Debug.Log(speed);
        }
    }
}
