using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Object thisObject;
    public int pointsAwarded;
     
    private void Awake() 
    {
        thisObject = GetComponent<Object>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("PlayerCollider"))
        {
            PlayerPrefs.SetInt(thisObject.ID, PlayerPrefs.GetInt(thisObject.ID) + pointsAwarded);
            Destroy(gameObject);
        }
    }
        
}
