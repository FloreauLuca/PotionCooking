using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Cauldron : MonoBehaviour
{

    [SerializeField] private SO_Potion[] recipeArray;
    private int nbGoodIngredient;
    private int recipeSucessfulIndex = -1;
    private Container container;
    [SerializeField] private GameObject[] item;
    private const int RECIPE_ARRAY_LENGTH = 3;
    void Start ()
    {
        foreach (SO_Potion recipe in recipeArray)
        {
            recipe.CurrentPotionCup = recipe.PotionCupSprites[Random.Range(0, recipe.PotionCupSprites.Length)];
        }
        container = GetComponent<Container>();
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
	            }
            }

	        SetContainerNull();
            if (recipeSucessfulIndex > -1)
            {
                StartCoroutine(Cooking(recipeArray[recipeSucessfulIndex].CookingTime));
            }
        }
	    for (int i = 0; i < container.CurrentContainObjectType.Count; i++)
	    {
	        item[i].GetComponentInChildren<SpriteRenderer>().sprite = container.CurrentContainObjectType[i];
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

    IEnumerator Cooking(int cookingTime)
    {
        yield return new WaitForSeconds(cookingTime);
        container.CurrentContainObjectType.Add(recipeArray[recipeSucessfulIndex].PotionCauldron);
    }
}
