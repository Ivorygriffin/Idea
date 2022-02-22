using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class HallucinationGas : MonoBehaviour
{

    //bools
   
    private bool _listShowing;
    private bool _run;

    //GameObjects

    public GameObject hallucinationGasScreen;
    public GameObject listImage;

    //lists/arrays
    public List<string> _currentIngredients;
    public string[] ingredients;

    // UI

    public TMP_Text ingredientList;

    //ints
    public int numberOfIngredients;
    private int _currentNumberOfIngredients = 0;

    public List<string> ongoingList;


    private string _ingredientsString, _ongoingString;

    private GameController GC;

    public UnityEvent OnFail;
    public UnityEvent OnSuccess;

    public void Start()
    {
        GC = FindObjectOfType<GameController>();
    }

    void Update()
    {
        GenerateRandomList();
        OnListComplete();
    }

    public void GenerateRandomList() //will select a number of items from the available options and place them in an order
    {
        if(numberOfIngredients != _currentNumberOfIngredients)
        {
            
            _currentIngredients.Add(ingredients[Random.Range(0, ingredients.Length)]);
    
            Debug.Log(string.Format("{0}", _currentIngredients[_currentNumberOfIngredients]));
        
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
            ShowList();
            _listShowing = false;
            
        }
       

    }
    public void AddToList(GameObject word)
    {
        ongoingList.Add(word.GetComponent<HGIngredient>().ingredientName);
        //need to add if incorrect word added them run OnWrongClick
        //if (_currentIngredients[_currentNumberOfIngredients] != _ingredientsString)
        //{
            //OnWrongClick();
       // }
        //this didnt work
    }
    
    public void ShowList() //take generated list and show it on screen for a period of time
    {
        if(_run == false)
        {
            for (int i = 0; i < _currentIngredients.Count; i++)
            {
                string Ingredient = _currentIngredients[i];
                _ingredientsString += _currentIngredients[i];
            }

            ingredientList.text = string.Format("{0}", _ingredientsString);


            listImage.SetActive(true);
            _run = true;
        }
        
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        listImage.SetActive(false);
        _listShowing = false;
    }

    public void OnListComplete()
    {
        if (ongoingList.Count == 5)
        {
            for (int i = 0; i < ongoingList.Count; i++)
            {
                string Ingredient = ongoingList[i];
                _ongoingString += ongoingList[i];
                Debug.Log(_ongoingString);
                Debug.Log(_ingredientsString);
            }
            //add bool
            if (_ingredientsString == _ongoingString)
            {
                Success();
            }
            if(_ingredientsString != _ongoingString)
            {
                OnWrongClick();
            }
        }
    }
    public void OnWrongClick()
    {
        Debug.Log("wrong");
        ClearLists();
        OnFail.Invoke();
        GC.MiniGameFail();
        hallucinationGasScreen.SetActive(false);
      
      
 
    }
    public void Success()
    {
        Debug.Log("correct");
        GC.HallucinationGasMiniGameSuccess();
        ClearLists();
        OnSuccess.Invoke();
        hallucinationGasScreen.SetActive(false);
    }
    public void ClearLists()
    {
        _currentNumberOfIngredients = 0;
        ongoingList.Clear();
        _currentIngredients.Clear();
        _ingredientsString = string.Empty;
        _run = false;
    }

    
}