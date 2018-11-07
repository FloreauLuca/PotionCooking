using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private RecipeJSON[] nbRecipe;
    private int nbGoodIngredient;
    private int recipeSucessful = 0;
    private Container container;
    [SerializeField] private GameObject[] item;

    void Start ()
    {
        container = GetComponent<Container>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (container.currentContainObjectType.Count == 3)
	    {
	        recipeSucessful = -1;
	        for (int nbRecipeIndex = 0; nbRecipeIndex < 3; nbRecipeIndex++)
	        {
	            nbGoodIngredient = 0;
	            for (int j = 0; j < 3; j++)
	            {
	                //container.currentContainObjectType.Contains(nbRecipe[nbRecipeIndex].recipe[j]);
                    for (int k = 0; k < 3; k++)
	                {
                        Debug.Log("i : " + nbRecipeIndex);
                        Debug.Log("J : " + j);
	                    Debug.Log("k : " + k);

	                    Debug.Log(container.currentContainObjectType[k]);
	                    Debug.Log(nbRecipe[nbRecipeIndex].recipe[j]);
                        if (container.currentContainObjectType[k] == nbRecipe[nbRecipeIndex].recipe[j])
	                    {
	                        nbGoodIngredient++;
	                        
	                        Debug.Log("nbGoodIngredient : " + nbGoodIngredient);
	                        break;

	                    }
	                }

	            }
                if (nbGoodIngredient == 3)
	            {
	                recipeSucessful = nbRecipeIndex;
                    Debug.Log("recipeSucessful " + recipeSucessful);
	            }
             

            }

	        container.currentContainObjectType = new List<Sprite>();
	        for (int i = 0; i < 3; i++)
	        {
	            item[i].GetComponentInChildren<SpriteRenderer>().sprite = null;
	        }

	        Debug.Log("recipeSucessful " + recipeSucessful);
            if (recipeSucessful > -1)
	        {
	            Debug.Log(container.currentContainObjectType);
	            container.currentContainObjectType.Add(nbRecipe[recipeSucessful].potion);

            }
        }
	    for (int i = 0; i < container.currentContainObjectType.Count; i++)
	    {
	            item[i].GetComponentInChildren<SpriteRenderer>().sprite = container.currentContainObjectType[i];
	    }

	}

}
