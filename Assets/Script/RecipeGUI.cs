using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class RecipeGUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    [SerializeField] private SO_Potion potion;

    [SerializeField] private GameObject[] ingredientItem;

    [SerializeField] private GameObject potionItem;
    [SerializeField] private GameObject nameText;
    [SerializeField] private GameObject timeText;
    [SerializeField] private RectTransform rectTransform;
    private GameObject mousePrefab;
    void Start()
    {
        mousePrefab = GameObject.FindGameObjectWithTag("Mouse");
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    /*private void Update()
    {

        Debug.Log(Camera.main.ScreenToWorldPoint(mousePrefab.transform.position));
        Debug.Log(Camera.main.WorldToScreenPoint(mousePrefab.transform.position));
        Debug.Log(Camera.main.WorldToViewportPoint(mousePrefab.transform.position));
        Debug.Log(rectTransform.anchorMin + rectTransform.anchorMax);

        Debug.Log(rectTransform.rect);
        Rect recttest = new Rect(rectTransform.rect.position, rectTransform.rect.size);
        Debug.Log(recttest);

        if (rectTransform.rect.Contains(mousePrefab.transform.position))
        {
            animator.SetBool("MouseOver", true);
        }
        else
        {
            animator.SetBool("MouseOver", false);
        }
    }*/


    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("MouseOver", false);
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
