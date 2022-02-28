using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Scramble : MonoBehaviour
{

    //picking and scrambling
    public string[] words;
    public string _currentWord;
    public List<char> _currentWordList;
    public List<char> scrambledWord;
    private char _randLetter;
    private string _scrambleString;
    private bool _run, _hasRun;
    private int numLetters;
    private int letters;
    public TMP_Text word;

    public GameObject UI;
    public GameObject scram;
    public UnityEvent OnComplete;

    //player click
    public List<char> lettersClicked;
    public string wordCheck;
    public GameController GC;


    private void Start()
    {
        _hasRun = false;
        GC = FindObjectOfType<GameController>();
    }
    void Update()
    {
        Pickword();
        if(lettersClicked.Count == _currentWord.Length)
        {
            CheckClick();
        }
    }

    void Pickword()
    {
        if(_run == false)
        {
            _currentWord = words[Random.Range(0, words.Length)];
            
            letters = _currentWord.Length;
            Debug.Log(_currentWord);
            _run = true;

            for (int i = 0; i < _currentWord.Length; i++)
            {
                _currentWordList.Add(_currentWord[i]);
            }

        }
 
        ScrambleWord();

    }

    void ScrambleWord()
    {
        if(numLetters != letters)
        {
            int LetterPos = Random.Range(0, _currentWordList.Count);
            _randLetter = _currentWordList[LetterPos];
            scrambledWord.Add(_randLetter);
            _currentWordList.RemoveAt(LetterPos);


            numLetters += 1;
        }
        if(_hasRun == false)
        {
            ConvertToString();
        }

    }

    public void ConvertToString()
    {
        if (numLetters == letters)
        {


            for (int i = 0; i < scrambledWord.Count; i++)
            {
                char scram = scrambledWord[i];
                _scrambleString += scrambledWord[i];
                Debug.Log(_scrambleString);
                word.text = _scrambleString;
            }
            _hasRun = true;
            

        }
    }

    public void CheckClick()
    {
        foreach(char character in lettersClicked)
        {
            wordCheck += character;
            
        }
        Debug.Log(wordCheck);
        if (wordCheck == _currentWord)
        {
            Clear();
            GC.ScrambleMiniGameSuccess();
        }
        if(wordCheck != _currentWord)
        {
            Clear();
            GC.MiniGameFail();
        }


    }
    public void LetterClick(GameObject letters)
    {
        lettersClicked.Add(letters.GetComponent<ScramLetters>().Letter);
        
    }

    public void Clear()
    {
        wordCheck = string.Empty;
        word.text=string.Empty;
        numLetters = 0;
        scrambledWord.Clear();
        lettersClicked.Clear();
        _currentWord = string.Empty;
        _currentWordList.Clear();
        UI.SetActive(false);
        _run = false;
        _hasRun=false;
        OnComplete.Invoke();
        scram.SetActive(false);
       

    }








}
