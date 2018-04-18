﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase : MonoBehaviour
{
    public List<Recipe> recipes = new List<Recipe>();
    public RecipeDatabase()
    {
        recipes.Add(new Recipe("Stoneblock", new Dictionary<string, int>() { { "Wood", 1 }, { "Stone", 2 } }));
        recipes.Add(new Recipe("Woodblock", new Dictionary<string, int>() { { "Wood", 2 } }));
    }
}