using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject commandePanel;
    [SerializeField] private GameObject recipePrefab;
    private bool welcomed = false;
    private void OnMouseDown()
    {
        if (!welcomed)
        {
            Instantiate(recipePrefab, commandePanel.transform);
            welcomed = true;
        }
    }
}
