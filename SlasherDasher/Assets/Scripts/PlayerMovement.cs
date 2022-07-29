using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 moveInput;
    public Rigidbody2D rb2d;
    private float activeMoveSpeed;
    public float dashSpeed;
    public bool canDash;
    public Dash script;


    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = movementSpeed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Awake() 
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if (script.isDashing == false)
        {
            rb2d.velocity = moveInput * activeMoveSpeed;

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canDash == true)
            {
                activeMoveSpeed = dashSpeed;
                canDash = false;
            }
        }

    }
}

