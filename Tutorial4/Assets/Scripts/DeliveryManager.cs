using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public static DeliveryManager Instance { get; private set; }


    [SerializeField] private RecipeListSO recipeListSO;

    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTImerMax = 4f;
    private int waitingRecipesMax = 4;

    private void Awake()
    {
        Instance = this;
        waitingRecipeSOList = new List<RecipeSO>();
    }
    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTImerMax;

            if (waitingRecipeSOList.Count < waitingRecipesMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                // Has the same number of ingredients
                bool plateContentsMatchesRecipe = true;
                foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    // Cycling through all ingredients in the Recipe
                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        // Cycling through all ingredients in the Plate
                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            // Ingredient matches!
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        // This Recipe ingredient was not found on the Plate
                        plateContentsMatchesRecipe = false;
                    }
                }

                if (plateContentsMatchesRecipe)
                {

                    //Player got the right recipe
                    //Debug.Log("Player got the correct recipe!");
                    waitingRecipeSOList.RemoveAt(i);
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    return;

                }
                //Debug.Log(plateContentsMatchesRecipe);
            }
        }

        //No Matches found!
        //Player idd not deliver a correct recipe
        //Debug.Log("Player did not deliver a correct recipe");
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;

    }

    /*
     * public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
{
    for (int i = 0; i < waitingRecipeSOList.Count; i++)
    {
        RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

        if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
        {
            // same number of ingredients
            bool plateCountentsMatchesRecipe = true;

            foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
            {
                // ingredients are cycled
                bool ingredientFound = false;

                foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                {
                    // cycling through all ingredients in the plate
                    if (plateKitchenObjectSO == recipeKitchenObjectSO)
                    {
                        // ingredient matches!
                        ingredientFound = true;
                        break;
                    }
                }

                if (!ingredientFound)
                {
                    // recipe ingredient not found on plate
                    plateCountentsMatchesRecipe = false;
                }
            }

            if (plateCountentsMatchesRecipe)
            {
                // Player got the right recipe
                Debug.Log("Player got the correct recipe!");
                waitingRecipeSOList.RemoveAt(i);
                return;
            }
        }
    }

    // No Matches found!
    // Player did not deliver a correct recipe
    Debug.Log("Player did not deliver a correct recipe");
}
     */
}
