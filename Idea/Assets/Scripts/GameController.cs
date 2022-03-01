using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    //sliders
    public Slider convinced;
    public Slider suspicion;

    //floats
    private float _currentConvinced;
    public float _currentSuspicion;

    public float maxConvinced;
    public float maxSuspicion;

    public float timePerCharacter;
    public float _timeRemaining;

    //ints

    private int _scrambleMiniGameWinConvinced;
    private int _hallucinaitonGasMiniGameWinConvinced;
    private int _storyTellingMiniGameWinConvinced;

    public int maxRound;
    private int _currentRound = 0;


    //bools



    //text

    public TMP_Text timerText;

    public TMP_Text journalTextHGMiniGame;
    public TMP_Text journalTextSTMiniGame;
    public TMP_Text journalTextSMiniGame;



    //Scenes
    public string Lose;
    public string Win;
    public string MainMenu;

    //game objects 
    public GameObject pauseMenu;
    public GameObject journal;
   
    //images

    public Image journalCharacter1; 
    public Image journalCharacter2; 
    public Image journalCharacter3;

    public GameObject[] people;
    private GameObject _selectedPerson;

    void Start()
    {
        StartGame();
        _timeRemaining = timePerCharacter;
    }

    void Update()
    {
        StartTimer();
        CheckSuspicion();
        TimerTextUpdate();
        SetConvinced();
        SetSuspicion();
        PauseMenu();
        CheckRound();
        CheckTime();
        
    }
    public void StartGame()
    {
        
        SelectCharacter();
        _currentRound += 1;
    }

    public void CheckRound()
    {
        if (_currentRound == maxRound && _currentSuspicion != maxSuspicion)
        {
            WinScene();
        }
    }
  
    public void SetConvinced() //to be used to check number the variables have changed to in update and change slider
    {
        convinced.value = _currentConvinced;

    }
    public void SetSuspicion() // as above
    {

        suspicion.value = _currentSuspicion;


    }
    public void CheckSuspicion()
    {
        if(_currentSuspicion == maxSuspicion)
        {
            GameOver();
        }
    }
    public void NewCharacter()//after timer reaches 0 this will get a new character to start in the scene and start new timer 
    {
        SelectCharacter();
        _timeRemaining = timePerCharacter;
        _currentRound += 1;
        Debug.Log(_currentRound);


    }
    public void TimerComplete()//will check if failed to convince character or succeeded, call to update suspicion funciton call to new character function
    {
        if(_currentConvinced != maxConvinced)
        {
            _currentSuspicion += 10;
            Debug.Log(_currentSuspicion);
        }
    }
    public void CheckTime()
    {
        if(_timeRemaining <= 0)
        {
            TimerComplete();
            NewCharacter();
        }
    }
  

    public void SelectCharacter()//randomly select which characters will be appearing in the level
    {
        _scrambleMiniGameWinConvinced = Random.Range(1, 15);
        _storyTellingMiniGameWinConvinced = Random.Range(1, 15);
        _hallucinaitonGasMiniGameWinConvinced = Random.Range(1, 15);

        SetJournal();

        _selectedPerson = people[Random.Range(0, people.Length)];
        _selectedPerson.SetActive(true);



        //Randomly select model and play relevant animation 
        //pick corresponding journal character image 

    }


    public void HallucinationGasMiniGameSuccess()//will +or- a float in relation to max value of convinced 
    {
        _currentConvinced += _hallucinaitonGasMiniGameWinConvinced;
        Debug.Log(_currentConvinced);

    }
    public void StoryTellingMiniGameSuccess()
    {
        _currentConvinced += _storyTellingMiniGameWinConvinced;
        Debug.Log(_currentConvinced);
      
    }
    public void ScrambleMiniGameSuccess()
    {
        _currentConvinced += _scrambleMiniGameWinConvinced;
        Debug.Log(_currentConvinced);

    }
    public void MiniGameFail()//will + a float in relation to max value of suspicion 
    {
        _currentSuspicion += 15;
        Debug.Log(_currentSuspicion);
  
    }


    //timer
    public void TimerTextUpdate()
    {
        timerText.SetText(_timeRemaining.ToString("00"));

    }
    public void StartTimer()
    {
        
        _timeRemaining -= Time.deltaTime;
    }


    //journal stuff
    public void SetJournal()//set values and text on journal in relation to selected character values
    {
        //Hallucination gas

        if(_hallucinaitonGasMiniGameWinConvinced <= 5)
        {
            journalTextHGMiniGame.SetText("HG <5"); //make 3 variations one for less effective one for medium effective one for very effective

        }
        if ((_hallucinaitonGasMiniGameWinConvinced <= 10) && (_hallucinaitonGasMiniGameWinConvinced > 5))
        {
            journalTextHGMiniGame.SetText("HG <= 10 >5");
        }
        if ((_hallucinaitonGasMiniGameWinConvinced <= 15) && (_hallucinaitonGasMiniGameWinConvinced > 10))
        {
            journalTextHGMiniGame.SetText("HG <=15 >10");
        }

        //Scramble

        if(_scrambleMiniGameWinConvinced <= 5)
        {
            journalTextSMiniGame.SetText("S <5");
        }
        if((_scrambleMiniGameWinConvinced <= 10)&&(_scrambleMiniGameWinConvinced > 5))
        {
            journalTextSMiniGame.SetText("S <= 10 > 5");
        }
        if((_scrambleMiniGameWinConvinced <= 15)&&(_scrambleMiniGameWinConvinced > 10))
        {
            journalTextSMiniGame.SetText("S <=15 > 10");
        }  
        
        //storyTelling
        
        if(_storyTellingMiniGameWinConvinced <= 5)
        {
            journalTextSTMiniGame.SetText("ST <5");
        }
        if((_storyTellingMiniGameWinConvinced <= 10)&&(_scrambleMiniGameWinConvinced > 5))
        {
            journalTextSTMiniGame.SetText("ST <=10 >5");
        }
        if((_storyTellingMiniGameWinConvinced <= 15)&&(_scrambleMiniGameWinConvinced > 10))
        {
            journalTextSTMiniGame.SetText("ST <=15 >10");
        }
        


    }
    public void OpenJournal()
    {
        journal.SetActive(true);
    }
    public void CloseJournal()
    {
        journal.SetActive(false);
    }

    //Scene Loader

    public void GameOver()//when all characters set to appear in the level are complete will conplete end of level actions
    {
        SceneManager.LoadScene(Lose);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void WinScene()
    {
        SceneManager.LoadScene(Win);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    

  


}
