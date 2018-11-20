using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine.Audio;

public class Cauldron : MonoBehaviour
{

    [SerializeField] private SO_Potion[] recipeArray;
    private int nbGoodIngredient;
    private int recipeSucessfulIndex = -1;
    private Container container;
    [SerializeField] private GameObject[] item;
    private const int RECIPE_ARRAY_LENGTH = 3;

    [SerializeField] private Sprite fillInvisibility;
    [SerializeField] private Sprite fillLevitation;
    [SerializeField] private Sprite fillMetamorphose;
    private Sprite emptySprite;
    private float recipeTime;
    private bool cooking = false;

    [SerializeField] private Animator sandGlassAnimator;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private ParticleSystem bubbleInvisibility;
    [SerializeField] private ParticleSystem bubbleLevitation;
    [SerializeField] private ParticleSystem bubbleMetamorphose;
    [SerializeField] private GameObject bubbleSpawner;


    void Start ()
    {
        foreach (SO_Potion recipe in recipeArray)
        {
            recipe.CurrentPotionCup = recipe.PotionCupSprites[Random.Range(0, recipe.PotionCupSprites.Length)];
        }
        container = GetComponent<Container>();
        emptySprite = spriteRenderer.sprite;
    }
	
	// Update is called once per frame
	void Update () {
	    if (container.CurrentContainObjectType.Count == RECIPE_ARRAY_LENGTH)
	    {
	        recipeSucessfulIndex = -1;
	        for (int recipeIndex = 0; recipeIndex < recipeArray.Length; recipeIndex++)
	        {
	            nbGoodIngredient = 0;
	            foreach (Sprite recipeIngredientIndex in recipeArray[recipeIndex].Recipe)
	            {
	                foreach (Sprite ingredientIndex in container.CurrentContainObjectType)
	                {
	                    if (ingredientIndex == recipeIngredientIndex)
	                    {
	                        nbGoodIngredient++;
	                        break;
	                    }
	                }
	            }
                if (nbGoodIngredient == 3)
	            {
	                recipeSucessfulIndex = recipeIndex;
                    Debug.Log("RecipeSucessful");
	            }
            }

	        SetContainerNull();
            if (recipeSucessfulIndex > -1)
            {
                recipeTime = recipeArray[recipeSucessfulIndex].CookingTime;
                StartCoroutine(Cooking());
                sandGlassAnimator.SetFloat("Speed", 1/recipeTime);
            }
        }
	    for (int i = 0; i < container.CurrentContainObjectType.Count; i++)
	    {
	        item[i].GetComponentInChildren<SpriteRenderer>().sprite = container.CurrentContainObjectType[i];
        }
        Debug.Log(container.CurrentContainObjectType.Any());
	    if (container.CurrentContainObjectType.Any())
	    {

	        if (container.CurrentContainObjectType[0].name == "PotionInvisibility")
	        {
	            spriteRenderer.sprite = fillInvisibility;

            }
	        else if (container.CurrentContainObjectType[0].name == "PotionLevitation")
	        {
	            spriteRenderer.sprite = fillLevitation;

            }
	        else if (container.CurrentContainObjectType[0].name == "PotionMetamorphose")
	        {
	            spriteRenderer.sprite = fillMetamorphose;

	            Instantiate(bubbleMetamorphose, bubbleSpawner.transform);
            }
	        else
	        {
	            spriteRenderer.sprite = emptySprite;


            }
	    }
	    else
	    {
	        spriteRenderer.sprite = emptySprite;
        }
	}

    public void SetContainerNull()
    {
        container.CurrentContainObjectType = new List<Sprite>();
        for (int i = 0; i < 3; i++)
        {
            item[i].GetComponentInChildren<SpriteRenderer>().sprite = null;
        }
    }

    IEnumerator Cooking()
    {

        Instantiate(bubbleInvisibility, bubbleSpawner.transform);
        yield return new WaitForSeconds(recipeTime);
        container.CurrentContainObjectType.Add(recipeArray[recipeSucessfulIndex].PotionCauldron);
        cooking = false;

        sandGlassAnimator.SetFloat("Speed", 0);
    }

}
