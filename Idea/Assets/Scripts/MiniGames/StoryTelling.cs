using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTelling : MonoBehaviour
{

    public string[] sentences;
    public List<string> _sentencesList;
    public TMP_Text displayedText;
    public List<string> _ongoingParagraph;
    public string finalParagraph;
    private string _randomSentence;
    private int _currentSentenceNum;
    private bool _run, _textShown;
    public GameController GC;
    public int paragraphLength;
    void Start()
    {
       GC = FindObjectOfType<GameController>();
      
    }

    void Update()
    {

        PickRandomParagraph();
    }

    public void PickRandomParagraph()
    {
       
        if (_currentSentenceNum != paragraphLength)
        {
            
          
            if(_run == false)
            {
                foreach (string sentence in sentences)
                {
                    _sentencesList.Add(sentence);
                    _run = true;
                }
            }

            int numSentenceSelected = Random.Range(0, _sentencesList.Count);
            _randomSentence = _sentencesList[numSentenceSelected];

            _ongoingParagraph.Add(_randomSentence);
            _sentencesList.RemoveAt(numSentenceSelected);
            _currentSentenceNum += 1;
            Debug.Log(_currentSentenceNum);
            Debug.Log(_randomSentence);

            if (_textShown == false)
            {
                DisplayParargraphText();
             
            }
        }
      

    }
    public void DisplayParargraphText()
    {
        if(_currentSentenceNum == paragraphLength)
        {
            for (int i = 0; i < _ongoingParagraph.Count; i++)
            {
                string par = _ongoingParagraph[i];
                finalParagraph += _ongoingParagraph[i];
                Debug.Log(finalParagraph);
                displayedText.text = finalParagraph;
            }
            _textShown = true;
        }
       
        //only showing one sentence
    }


    public void CheckResult()
    {

    }

    public void Clear()
    {

    }

    public void Success()
    {
        GC.StoryTellingMiniGameSuccess();
    }

    public void Lose()
    {
        GC.MiniGameFail();
    }

   
    public void AddStoryItem()
    {

    }
}
