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

    private int _scrambleMiniGameWinConvinced;
    private int _hallucinaitonGasMiniGameWinConvinced;
    private int _storyTellingMiniGameWinConvinced;



    //bools



    //UI text

    public TMP_Text timerText;

    //Scenes
    public string Lose;
    public string Win;
    public string MainMenu;

    //game objects 
    public GameObject pauseMenu;
    public GameObject journal;


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

        //select model and play relevant animation 


    }
    public void SetJournal()//set values and text on journal in relation to selected character values
    {



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

    public void TimerTextUpdate()
    {
        timerText.SetText(_timeRemaining.ToString("00"));
        
    }
    public void NewTimer()
    {
        _timeRemaining = timePerCharacter -= Time.deltaTime;
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
