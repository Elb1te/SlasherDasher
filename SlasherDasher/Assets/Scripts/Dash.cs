using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject DashArrow;
    public bool IsDashing;
    public bool canDash;
    public float dashPower;
    public float rotationZ;
    public Rigidbody2D myRB;

    public void Start()
    {
        canDash = true;
        IsDashing = false;
        dashPower = 15f;
        myRB = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePos.Normalize();

        rotationZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        DashArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            if (canDash)
            {
                Debug.Log("GO");
                DoDash();
            }
        }

    }
    IEnumerator timeWait()
    {
        yield return new WaitForSeconds(1);
        IsDashing = false;
    }

    private void DoDash()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        IsDashing = true;
        myRB.velocity = transform.right * dashPower;
        StartCoroutine(timeWait());
    }
}