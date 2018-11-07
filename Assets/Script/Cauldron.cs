using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private RecipeSerializable[] recipeArray;
    private int nbGoodIngredient;
    private int recipeSucessful = 0;
    private Container container;
    [SerializeField] private GameObject[] item;
    private const int RECIPE_ARRAY_LENGTH = 3;
    void Start ()
    {
        container = GetComponent<Container>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (container.CurrentContainObjectType.Count == RECIPE_ARRAY_LENGTH)
	    {
	        recipeSucessful = -1;
	        for (int recipeIndex = 0; recipeIndex < 3; recipeIndex++)
	        {
	            nbGoodIngredient = 0;
	            for (int recipeIngredientIndex = 0; recipeIngredientIndex < 3; recipeIngredientIndex++)
	            {
	                /*if (container.CurrentContainObjectType.Contains(recipeArray[recipeIndex].Recipe[recipeIngredientIndex]))
	                {
	                    nbGoodIngredient++;
	                    break;
	                }*/
                    for (int k = 0; k < 3; k++)
	                {
                        if (container.CurrentContainObjectType[k] == recipeArray[recipeIndex].Recipe[recipeIngredientIndex])
	                    {
	                        nbGoodIngredient++;
	                        break;
	                    }
	                }

                }
                if (nbGoodIngredient == 3)
	            {
	                recipeSucessful = recipeIndex;
	            }
            }

	        SetContainerNull();
            if (recipeSucessful > -1)
	        {
	            container.CurrentContainObjectType.Add(recipeArray[recipeSucessful].Potion);
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

}
