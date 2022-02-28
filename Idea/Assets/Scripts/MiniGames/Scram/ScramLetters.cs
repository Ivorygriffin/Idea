using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScramLetters : MonoBehaviour
{
    public Scramble scram;
    public char Letter;
    private void Start()
    {
        scram.GetComponent<Scramble>();
    }
    public void OnButtonClicked()
    {
        scram.LetterClick(gameObject);
     
    }
   

  
  
}
