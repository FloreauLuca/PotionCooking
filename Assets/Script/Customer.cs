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

    private GameObject parent;

    public SO_Potion Potion
    {
        get { return potion; }
        set { potion = value; }
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        container = GetComponent<Container>();
        parent = transform.parent.gameObject;
        parent.GetComponent<WaitingLine>().Customers.Add(gameObject);
        parent.GetComponent<WaitingLine>().LineOrganization();
        commandePanel = GameObject.Find("OrderPanel");
    }

    private void OnMouseDown()
    {
        if (!welcomed)
        {
            currentRecipe = Instantiate(potion.PanelPrefab, commandePanel.transform);
            welcomed = true;
            parent.GetComponent<WaitingLine>().Customers.Remove(gameObject);
            parent.GetComponent<WaitingLine>().LineOrganization();
            transform.SetParent(parent.GetComponent<WaitingLine>().OtherLine.transform);
            parent = transform.parent.gameObject;
            parent.GetComponent<WaitingLine>().Customers.Add(gameObject);
            parent.GetComponent<WaitingLine>().LineOrganization();
        }
    }

    public void Reception(Sprite cupSprite)
    {
        Debug.Log("Reception");
        if (container.GetComponent<Container>().CurrentContainObjectType[0] == potion.PotionCauldron && welcomed && cupSprite == potion.CurrentPotionCup)
        {
            gameManager.GetComponent<GameManager>().SpawnCustomer();
            parent.GetComponent<WaitingLine>().Customers.Remove(gameObject);
            parent.GetComponent<WaitingLine>().LineOrganization();
            Destroy(currentRecipe);
            Destroy(gameObject);
        }
        else
        {
            container.CurrentContainObjectType = new List<Sprite>();
        }
    }

}
