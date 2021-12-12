using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //sliders
    public Slider convinced;
    public Slider suspicion;

    //floats
    private float _currentConvinced;
    private float _currentSuspicion;

    public float maxConvinced;
    public float maxSuspicion;

    public float timePerCharacter;
    private float _timeRemaining;

    //ints

    private int _scrambleMiniGameWinConvinced;
    private int _hallucinaitonGasMiniGameWinConvinced;
    private int _storyTellingMiniGameWinConvinced;

    public int maxRound;
    private int _currentRound;


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



    void Start()
    {
        NewCharacter();
    }

    void Update()
    {
        CheckSuspicion();
        TimerTextUpdate();
        SetConvinced();
        SetSuspicion();
        PauseMenu();
        
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
        NewTimer();

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
        if(_timeRemaining == 0)
        {
            TimerComplete();
        }
    }
  

    public void SelectCharacter()//randomly select which characters will be appearing in the level and how many will be appearing
    {
        _scrambleMiniGameWinConvinced = Random.Range(1, 15);
        _storyTellingMiniGameWinConvinced = Random.Range(1, 15);
        _hallucinaitonGasMiniGameWinConvinced = Random.Range(1, 15);

        SetJournal();

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
    public void MiniGameFail()//will + or - a float in relation to max value of suspicion 
    {
        _currentSuspicion += 15;
    }


    //timer
    public void TimerTextUpdate()
    {
        timerText.SetText(_timeRemaining.ToString("00"));
        
    }
    public void NewTimer()
    {
        _timeRemaining = timePerCharacter -= Time.deltaTime;
    }

    //journal stuff
    public void SetJournal()//set values and text on journal in relation to selected character values
    {
        //Hallucination gas

        if(_hallucinaitonGasMiniGameWinConvinced <= 5)
        {
            journalTextHGMiniGame.SetText("blah"); //make 3 variations one for less effective one for medium effective one for very effective

        }
        if ((_hallucinaitonGasMiniGameWinConvinced <= 10) && (_hallucinaitonGasMiniGameWinConvinced > 5))
        {
            journalTextHGMiniGame.SetText("blah");
        }
        if ((_hallucinaitonGasMiniGameWinConvinced <= 15) && (_hallucinaitonGasMiniGameWinConvinced > 10))
        {
            journalTextHGMiniGame.SetText("blah");
        }

        //Scramble

        if(_scrambleMiniGameWinConvinced <= 5)
        {
            journalTextSMiniGame.SetText("blah");
        }
        if((_scrambleMiniGameWinConvinced <= 10)&&(_scrambleMiniGameWinConvinced > 5))
        {
            journalTextSMiniGame.SetText("blah");
        }
        if((_scrambleMiniGameWinConvinced <= 15)&&(_scrambleMiniGameWinConvinced > 10))
        {
            journalTextSMiniGame.SetText("blah");
        }  
        
        //storyTelling
        
        if(_storyTellingMiniGameWinConvinced <= 5)
        {
            journalTextSTMiniGame.SetText("blah");
        }
        if((_storyTellingMiniGameWinConvinced <= 10)&&(_scrambleMiniGameWinConvinced > 5))
        {
            journalTextSTMiniGame.SetText("blah");
        }
        if((_storyTellingMiniGameWinConvinced <= 15)&&(_scrambleMiniGameWinConvinced > 10))
        {
            journalTextSTMiniGame.SetText("blah");
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
        }
    }


}
