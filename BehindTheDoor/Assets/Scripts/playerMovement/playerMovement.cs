using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float timeToHide = 1f;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private SpriteRenderer spriteRenderer;
    private PlayerState playerState;
    private SphereCollider feetCollider;
    private float timeSpentIdle;

    private enum PlayerState
    {
        idle,
        running,
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerState = PlayerState.idle;
    }
    void Update()
    {
        Vector2 inputs = playerInput.actions.actionMaps[0].actions[0].ReadValue<Vector2>();
        setState(inputs);

        if (playerState == PlayerState.idle)
        {
        }
        if(playerState == PlayerState.running)
        {
            rb.velocity = new Vector2(inputs.x * speed, rb.velocity.y);
        }
    }

    void checkIdle(Vector2 direction)
    {
        if(direction == Vector2.zero)
        {
            timeSpentIdle += Time.deltaTime;
            if (timeSpentIdle >= timeToHide)
            {

                playerState = PlayerState.idle;
                spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            }
        }

    }
    void setState(Vector2 inputs)
    {
        if(inputs == Vector2.zero)
        {
            checkIdle(inputs);
        }
        else
        {
            timeSpentIdle = 0;
            playerState = PlayerState.running;
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }
    }
}
