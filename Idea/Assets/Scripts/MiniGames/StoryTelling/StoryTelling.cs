using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

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
    public StoryTellingLabels labels;

    public List<string> currentItemList;
    public string currentItemString;
    private int _currentItemNum;
    public UnityEvent OnComplete;
    void Start()
    {
      GC = FindObjectOfType<GameController>();
      FindObjectOfType<StoryTellingLabels>();
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
       
        
    }


    public void CheckResult()
    {
        if(currentItemString == finalParagraph)
        {
            Clear();
            OnComplete.Invoke();
            Success();
        }
        if(currentItemString != finalParagraph)
        {
            Clear();
            OnComplete.Invoke();
            Lose();
        }
    }

    public void Clear()
    {
        _currentSentenceNum = 0;
        currentItemString = string.Empty;
        _currentItemNum = 0;
        _randomSentence = string.Empty;
        _sentencesList.Clear();
        currentItemList.Clear();
        finalParagraph = string.Empty;
        _ongoingParagraph.Clear();
        _textShown=false;
        _run = false;


    }

    public void Success()
    {
        Debug.Log("winner");
        Clear();
        OnComplete.Invoke();
        GC.StoryTellingMiniGameSuccess();
    }

    public void Lose()
    {
        Debug.Log("LOser");
        Clear();
        OnComplete.Invoke();
        GC.MiniGameFail();
    }

   
    public void AddStoryItem(GameObject item)
    {
        currentItemList.Add(item.GetComponent<StoryTellingLabels>().item);
        _currentItemNum += 1;
        Debug.Log(item);

        if (_currentItemNum == paragraphLength)
        {
            for (int i = 0; i < currentItemList.Count; i++)
            {
                string par = currentItemList[i];
                currentItemString += currentItemList[i];
                Debug.Log(currentItemString);
            
            }
            CheckResult();
        }
    }
}
