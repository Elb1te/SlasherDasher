using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject DashArrow;
    public bool canDash = true;
    public bool isDashing = false;
    public int dashSpeed = 10;
    public Rigidbody myRB2D;
    public Transform DashDirection;
    public float rotationZ;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePos.Normalize();

        rotationZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        DashArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        DashDirection.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            if(canDash)
            {
                DoDash();
                canDash = false;
            }
        }

    }

    private void DoDash()
    {
        transform.rotation = DashDirection.rotation;

        rb2D.velocity = DashDirection.right * dashSpeed;
        
    }
}
