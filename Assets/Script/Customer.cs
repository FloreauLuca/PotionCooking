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
    private Sprite currentPotionCup;
    private float currentWaiting = 0;
    [SerializeField] private float waitingLimit;

    private float currentAskWaiting = 0;
    [SerializeField] private float askWaitingLimit;

    private GameObject parent;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] drinkAudioClip;
    [SerializeField] private AudioClip badReception;

    [SerializeField] private GameObject frustrationBar;
    [SerializeField] private GameObject potionBubbleSprite;
    [SerializeField] private GameObject bubbleGameObject;

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
        audioSource = GetComponent<AudioSource>();
        currentPotionCup = potion.PotionCupSprites[Random.Range(0, potion.PotionCupSprites.Length)];
    }

    private void Update()
    {
        if (!welcomed)
        {
            currentWaiting += Time.deltaTime;

            GetComponentInChildren<SpriteRenderer>().color = Color.white - Color.cyan * (currentWaiting / waitingLimit) + Color.black;
        }
        else
        {
            currentAskWaiting += Time.deltaTime;

            GetComponentInChildren<SpriteRenderer>().color = Color.white - Color.cyan * (currentAskWaiting / askWaitingLimit) + Color.black;
            frustrationBar.GetComponent<SpriteRenderer>().size = new Vector2(frustrationBar.GetComponent<SpriteRenderer>().size.x,(currentAskWaiting/ askWaitingLimit)*1.575f);
        }

        if (currentWaiting > waitingLimit || currentAskWaiting > askWaitingLimit)
        {
            RageQuit();
        }
    }

    private void OnMouseDown()
    {
        if (!welcomed && gameManager.GetComponent<GameManager>().Unpaused)
        {
            currentRecipe = Instantiate(potion.PanelPrefab, commandePanel.transform);
            currentRecipe.GetComponent<RecipeGUI>().CurrentPotionCup = currentPotionCup;
            currentRecipe.GetComponent<RecipeGUI>().Potion = potion;

            welcomed = true;
            parent.GetComponent<WaitingLine>().Customers.Remove(gameObject);
            parent.GetComponent<WaitingLine>().LineOrganization();
            transform.SetParent(parent.GetComponent<WaitingLine>().OtherLine.transform);
            parent = transform.parent.gameObject;
            parent.GetComponent<WaitingLine>().Customers.Add(gameObject);
            parent.GetComponent<WaitingLine>().LineOrganization();
            bubbleGameObject.SetActive(true);
            potionBubbleSprite.GetComponent<SpriteRenderer>().sprite = currentPotionCup;
        }
    }

    public void Reception(Sprite cupSprite)
    {
        //Debug.Log("Reception");
        if (container.GetComponent<Container>().CurrentContainObjectType[0] == potion.PotionCauldron && welcomed && cupSprite == currentPotionCup)
        {
            parent.GetComponent<WaitingLine>().Customers.Remove(gameObject);
            parent.GetComponent<WaitingLine>().LineOrganization();
            GetComponentInParent<SpawnCustomer>().HappyCustomer();
            audioSource.clip = drinkAudioClip[Random.Range(0, drinkAudioClip.Length)];
            audioSource.Play();
            Destroy(currentRecipe);
            StartCoroutine(audioWait());
        }
        else
        {
            container.CurrentContainObjectType = new List<Sprite>();
            audioSource.clip = badReception;
            audioSource.Play();
        }
    }

    public void RageQuit()
    {
        parent.GetComponent<WaitingLine>().Customers.Remove(gameObject);
        parent.GetComponent<WaitingLine>().LineOrganization();
        GetComponentInParent<SpawnCustomer>().MadCustomer();
        Destroy(currentRecipe);
        Destroy(gameObject);
    }

    IEnumerator audioWait()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

}
