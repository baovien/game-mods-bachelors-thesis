﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementScrollList : MonoBehaviour
{
	
	private ItemDatabase itemDatabase;
	private RecipeDatabase recipeDatabase;

	public Transform contentPanel;
	public SimpleObjectPool buttonObjectPool;
	
	// Use this for initialization
	void Start ()
	{
		itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		recipeDatabase = GameObject.FindGameObjectWithTag("RecipeDatabase").GetComponent<RecipeDatabase>();
		RemoveButtons();
	}

	/**
	 * Updates the requirements for a given craftable item
	 */
	public void UpdateRequirements(Item item)
	{
		RemoveButtons();
		AddButtons(item);
	}

	/**
	 * Removes all child members of the contentPanel in Req. scrollList
	 */
	private void RemoveButtons() //TODO: ERROR: Setting the parent of a transform which resides in a prefab is disabled to prevent data corruption.
	{
		for (int i = 0; i < contentPanel.GetChildCount(); i++)
		{
			GameObject toRemove = transform.GetChild(i).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}
	
	/**
	 * Add button for each requirement of a craftable item - to req. scrollList
	 */
	private void AddButtons(Item craftableItem)
	{
		//Finding the recipe for the item to be crafted
		for (int i = 0; i < recipeDatabase.recipes.Count; i++)
		{
			if (recipeDatabase.recipes[i].itemName == craftableItem.itemName)
			{
				Recipe recipe = recipeDatabase.recipes[i];
				
				//Iterating through and making a button for every requirement
				foreach (var req in recipe.items.Keys)
				{
					GameObject newButton = buttonObjectPool.GetObject();
					newButton.transform.SetParent(contentPanel, false);
					
					//This is needed to find the correct requirement itemicon, because a recipe does not have a image. //TODO: Legge til itemicon i recipes?
					foreach (var item in itemDatabase.items)
					{
						if (item.itemName == req)
						{
							RequirementBtn requirementBtn = newButton.GetComponent<RequirementBtn>();
							requirementBtn.Setup(req, recipe.items[req], item.itemIcon);
						}
					}
				}
			}
		}
	}
	
}