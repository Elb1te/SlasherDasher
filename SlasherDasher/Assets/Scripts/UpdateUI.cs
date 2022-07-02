using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private TextMeshProUGUI text;

    private string objectID;
    

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        objectID = objectPrefab.GetComponent<Object>().ID;
    }

    private void LateUpdate() 
    {
        text.text = PlayerPrefs.GetInt(objectID).ToString();
    }
}
