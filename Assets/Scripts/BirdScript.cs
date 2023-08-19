using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public int flapStrength = 1;
    public LogicScript logic;
    public bool birdIsAlive = true;
    
    

    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    void Start() 
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    // Update is called once per frame
    void Update()
    {

        bool isSpaceKeyHeld = playerControls.Player.Jump.ReadValue<float>() > 0.1f;

        if (isSpaceKeyHeld && birdIsAlive)
        {
            rb.velocity = Vector2.up * flapStrength;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        birdIsAlive = false;
        logic.gameOver();
    }
}


