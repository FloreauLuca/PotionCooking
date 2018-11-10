using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject commandePanel;
    [SerializeField] private SO_Potion potion;
    private bool welcomed = false;
    private GameObject currentRecipe;
    private Container container;
    private GameObject gameManager;
    private void Start()
    {
        container = GetComponent<Container>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnMouseDown()
    {
        if (!welcomed)
        {
            currentRecipe = Instantiate(potion.PanelPrefab, commandePanel.transform);
            welcomed = true;
        }
    }

    public void Reception()
    {
        if (container.GetComponent<Container>().CurrentContainObjectType[0] == potion.Potion && welcomed)
        {
            gameManager.GetComponent<GameManager>().NewCustomer();
            Destroy(currentRecipe);
            Destroy(gameObject);
        }
        else
        {
            container.CurrentContainObjectType = new List<Sprite>();
        }
    }

}
