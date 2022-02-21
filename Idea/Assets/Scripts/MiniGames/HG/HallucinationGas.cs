using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HallucinationGas : MonoBehaviour
{

    //bools
   
    private bool _listShowing;

    //GameObjects

    public GameObject hallucinationGasScreen;
    public GameObject listImage;

    //lists/arrays
    private List<string> _currentIngredients;
    public string[] ingredients;

    // UI

    public TMP_Text ingredientList;

    //ints
    public int numberOfIngredients;
    private int _currentNumberOfIngredients = 0;

    public List<string> ongoingList;


    void Update()
    {
        GenerateRandomList();
       
    }

    public void GenerateRandomList() //will select a number of items from the available options and place them in an order
    {
        if(numberOfIngredients != _currentNumberOfIngredients)
        {
            var rand = new System.Random();
            int index = rand.Next(ingredients.Length);
            //_currentIngredients.Add(ingredients[index]);
            //find a way to fix this
            Debug.Log(string.Format("{0}", ingredients[index]));
        
            _currentNumberOfIngredients += 1;
            Debug.Log(_currentNumberOfIngredients);
        }
        if(numberOfIngredients == _currentNumberOfIngredients)
        {
            _listShowing = true;
            
        }
        if(_listShowing == true)
        {
            StartCoroutine(Wait());
            _listShowing = false;
            ShowList();
        }
        
    }
    public void AddToList(GameObject word)
    {
        ongoingList.Add(word.GetComponent<HGIngredient>().ingredientName);
        //need to add if incorrect word added them run OnWrongClick
    }
    
    public void ShowList() //take generated list and show it on screen for a period of time
    {
        ingredientList.text = string.Format("{0}", _currentIngredients);
        listImage.SetActive(true);
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        listImage.SetActive(false);
        _listShowing = false;
    }

    public void OnListComplete()
    {
        if (ongoingList.Count == 5)
        {
            if (_currentIngredients == ongoingList)
            {
                Success();
            }
        }
    }
    public void OnWrongClick()
    {
        GetComponent<GameController>().MiniGameFail();
        hallucinationGasScreen.SetActive(false);
 
    }
    public void Success()
    {
        GetComponent<GameController>().HallucinationGasMiniGameSuccess();
        hallucinationGasScreen.SetActive(false);
    }
    

    
}