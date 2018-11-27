using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class RecipeGUI : MonoBehaviour, IPointerDownHandler
{
    private Animator animator;

    private Sprite currentPotionCup;
    public Sprite CurrentPotionCup
    {
        get { return currentPotionCup; }
        set { currentPotionCup = value; }
    }

    [SerializeField] private GameObject[] ingredientItem;

    [SerializeField] private GameObject potionItem;
    [SerializeField] private GameObject nameText;

    private SO_Potion potion;
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
            potionItem.GetComponent<Image>().sprite = currentPotionCup;
            nameText.GetComponent<TextMeshProUGUI>().text = potion.PotionName;
        }
    }

    private bool open;

    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        animator = GetComponent<Animator>();
    }

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

    
}
