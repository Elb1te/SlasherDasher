using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject DashArrow;
    public bool canDash;
    public bool isDashing;
    public float dashSpeed = 10f;
    public Rigidbody2D myRB2D;
    public float rotationZ;
    public bool makeDash;

    private void Start()
    {
        DashArrow.SetActive(false);
        myRB2D = GetComponent<Rigidbody2D>();
        isDashing = false;
        canDash = true;
        makeDash = false;
    }

    private void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            makeDash = true;
            if (makeDash)
            {
                DashArrow.SetActive(true);

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                mousePos.Normalize();

                rotationZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

                DashArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            }
           else if (Input.GetMouseButtonUp(0))
            {
                DashArrow.SetActive(false);

                DoDash();
            }
        }
 
    }
    
    IEnumerator timeWait()
    {
        yield return new WaitForSeconds(0.1f);
    }

    private void DoDash()
    {
        isDashing = true;
        
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        for (int i = 0; i < 1000; i++)
        {
            myRB2D.velocity = transform.right * dashSpeed;

            StartCoroutine(timeWait());
        }
        canDash = false;
    }
}
