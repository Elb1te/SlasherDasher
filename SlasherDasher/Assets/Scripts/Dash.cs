using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject DashArrow;
    public bool canDash = true;
    public bool isDashing = false;
    public float dashSpeed = 10;
    public Rigidbody2D myRB2D;
    public float rotationZ;

    private void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePos.Normalize();

        rotationZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        DashArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            DoDash();
            Debug.Log("CLICKED2");
        }
    }
    
    IEnumerator timeWait()
    {
        Debug.Log("Waited");
        yield return new WaitForSeconds(0.1f);
        Debug.Log("WAITED2");
    }

    private void DoDash()
    {
        StartCoroutine(timeWait());
        Debug.Log("MADE DASH2");
        for (int i = 0; i < 10; i++)
        {
            myRB2D.velocity = transform.right * dashSpeed;
            Debug.Log("Made Dash");
        }

    }

}
