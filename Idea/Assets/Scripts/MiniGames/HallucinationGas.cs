using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallucinationGas : MonoBehaviour
{

    //bools
    public bool selected;

    //GameObjects

    public GameObject hallucinationGasScreen;

    void Start()
    {

    }

    void Update()
    {

    }

    public void GenerateRandomList() //will select a number of items from the available options and place them in an order
    {

    }
    public void SelectItem() // to be called on button click event checking if image clicked matches the correct next item in the list 
    {
        
        //might end up being game objects rather than buttons 

    }
    public void ShowList() // take generated list and show it on screend for a period of time
    {

    }

    public void OnListComplete()
    {

    }
    public void OnWrongClick()
    {
        GetComponent<GameController>().MiniGameFail();
        hallucinationGasScreen.SetActive(false);
 
    }
    public void OnRightClick()
    {

    }
    public void CheckClick()//checks if correct click or not 
    {

        //if incorrect then 
        OnWrongClick();

        //if correct then 
        OnRightClick();


      
    }

    
}