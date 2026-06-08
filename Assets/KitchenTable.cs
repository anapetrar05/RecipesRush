using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class KitchenTable : MonoBehaviour
{
    public string tableName;
    public float maxTime = 60f;
    private float currentTime;

    [Header("UI")]
    public TMP_Text recipeText;
    public TMP_Text timerText;

    
    public static int reteteCompleteTotal = 0; 
    public int numarRetetePentruWin = 1; 

   
    public static int ingredienteCorecteTotal = 0;
    public static int ingredienteGresiteTotal = 0;
    public static float timpTotalScurs = 0f;

    private string[][] allRecipes = new string[][]
    {
        new string[] { "salata", "castravete", "rosie" },
        new string[] { "spaghete", "chiftelute", "sos rosii" },
        new string[] { "carne", "cartof", "ou" }
    };

    public List<string> currentRequiredIngredients = new List<string>();
    public List<string> deliveredIngredients = new List<string>();

    void Start()
    {
        
        reteteCompleteTotal = 0; 
        ingredienteCorecteTotal = 0;
        ingredienteGresiteTotal = 0;
        timpTotalScurs = 0f;

        GenerateNewRecipe();
    }

    void Update()
    {
        
        timpTotalScurs += Time.deltaTime;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = "Timp: " + Mathf.Ceil(currentTime).ToString();
            }
        }
        else
        {
            TimeExpired();
        }
    }

    void GenerateNewRecipe()
    {
        deliveredIngredients.Clear();
        int randomIndex = Random.Range(0, allRecipes.Length);
        currentRequiredIngredients = new List<string>(allRecipes[randomIndex]);
        currentTime = maxTime;
        UpdateRecipeUI();
    }

    public void ReceiveIngredient(string ingredientName)
    {
        string ingredientCurat = ingredientName.ToLower().Trim().Replace("_0", "");

        if (ingredientCurat == "sos rosi") 
        {
            ingredientCurat = "sos rosii";
        }

        if (currentRequiredIngredients.Contains(ingredientCurat) && !deliveredIngredients.Contains(ingredientCurat))
        {
            deliveredIngredients.Add(ingredientCurat);
            
            
            ingredienteCorecteTotal++;
            
            UpdateRecipeUI();

            if (deliveredIngredients.Count == currentRequiredIngredients.Count)
            {
                reteteCompleteTotal++;

                if (reteteCompleteTotal >= numarRetetePentruWin)
                {
                    
                    SceneManager.LoadScene("WinnerScene"); 
                }
                else
                {
                    GenerateNewRecipe();
                }
            }
        }
        else
        {
            
            ingredienteGresiteTotal++;

            currentTime -= 5f;
            if (recipeText != null)
            {
                StopAllCoroutines();
                StartCoroutine(ArataEroarePeEcran(ingredientCurat));
            }
        }
    }

    void UpdateRecipeUI()
    {
        if (recipeText == null) return;

        string formattedText = "";
        for (int i = 0; i < currentRequiredIngredients.Count; i++)
        {
            string ingredient = currentRequiredIngredients[i];
            if (deliveredIngredients.Contains(ingredient))
            {
                formattedText += "<color=green>" + ingredient + "</color>";
            }
            else
            {
                formattedText += ingredient;
            }

            if (i < currentRequiredIngredients.Count - 1)
            {
                formattedText += "\n";
            }
        }
        recipeText.text = formattedText;
    }

    System.Collections.IEnumerator ArataEroarePeEcran(string ceAmPrimit)
    {
        string ingredienteCerute = string.Join(", ", currentRequiredIngredients);
        recipeText.text = "<color=red>Gresit! </color>\nAm primit: [" + ceAmPrimit + "]\nMasa vrea: [" + ingredienteCerute + "]";
        yield return new WaitForSeconds(3f);
        UpdateRecipeUI();
    }

    void TimeExpired()
    {
        GenerateNewRecipe();
    }
}