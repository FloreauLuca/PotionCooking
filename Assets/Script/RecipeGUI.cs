using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class RecipeGUI : MonoBehaviour, IPointerDownHandler
{
    private Animator animator;

    [SerializeField] private SO_Potion potion;

    [SerializeField] private GameObject[] ingredientItem;

    [SerializeField] private GameObject potionItem;
    [SerializeField] private GameObject nameText;
    [SerializeField] private GameObject timeText;
    private bool open;

    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    
	

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameManager.GetComponent<GameManager>().Unpaused)
        {
            if (open)
            {
                animator.SetBool("MouseOver", false);
                open = false;
            }
            else
            {
                animator.SetBool("MouseOver", true);
                open = true;
            }
        }
    }

    public SO_Potion Potion
    {
        get { return potion; }
        set
        {
            potion = value;
            for (int i = 0; i < ingredientItem.Length; i++)
            {
                ingredientItem[i].GetComponent<Image>().sprite = potion.Recipe[i];
            }
            potionItem.GetComponent<Image>().sprite = potion.CurrentPotionCup;
            nameText.GetComponent<TextMeshProUGUI>().text = potion.PotionName;
            timeText.GetComponent<TextMeshProUGUI>().text = "Time : " + potion.CookingTime.ToString();
        }
    }
}
