using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject DashArrow;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                mousePos.Normalize();

                float rotationZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        }

    }

}
