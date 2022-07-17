using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject StartMenu;
    public GameObject EndMenu;
    public SpawnManager1 spawnManager1;

    public  delegate void CurrentGameState();
    static CurrentGameState currentGameState;
     
    public float CurrentTime;

    
    

    public enum GameStates
    {
        Start,
        Play,
        End
    }
    public GameStates gameState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           
        }
        StartMenu = GameObject.Find("Start Screen");
        EndMenu = GameObject.Find("Game Over Screen");
        EndMenu.SetActive(false);
    }

    public void Start()
    {
       
       ChangeStateToStart();
    }

    void Update()
    {
        ChnageStateToEnd();
        PlayState();
    }

    public void ChangeStateToStart()
    {
        if (gameState != GameStates.Play && gameState!= GameStates.End)
        {
            ChnageStateTo(StartState);
        }
            
        Debug.Log("Start state");

    }

    public void ChangeStateToPlay()
    {
        StartMenu.SetActive(false);
        gameState = GameStates.Play;
        ChnageStateTo(PlayState);
        Debug.Log("play state");
        spawnManager1.gameObject.SetActive(true);
        
    }

    public void ChnageStateToEnd()
    {
        if(gameState == GameStates.Play && PlayerManager.instance.Health<=0 && gameState !=GameStates.End && gameState != GameStates.Start)
        {
            ChnageStateTo(EndState);
            Debug.Log("end state");
        }
    }
    void StartState()
    {
        
        spawnManager1 = FindObjectOfType<SpawnManager1>();
        CurrentTime = 0;
        gameState = GameStates.Start;
        EnableGameObjects(false, false);
        EnableGameMenues(true, false);
       
    }
    void PlayState()
    {
        if(gameState != GameStates.End && gameState == GameStates.Play)
        {
            CountDownTime();
            EnableGameObjects(true, true);
        }  
    }

    void EndState()
    {
        gameState = GameStates.End;
        EnableGameMenues(false, true);
        EnableGameObjects(false, false);
        spawnManager1.gameObject.SetActive(false);
    }

    void EnableGameObjects(bool player,bool enemies)
    {
        PlayerManager.instance.gameObject.transform.parent.gameObject.SetActive(player);
        foreach(EnemyAi ai in EnemyManager.instance.EnemyList)
        {
            ai.gameObject.transform.parent.gameObject.SetActive(enemies);
        }
    }

    void EnableGameMenues(bool start, bool End)
    {
        StartMenu.SetActive(start);
        EndMenu.SetActive(End);
    }

    void ChnageStateTo(CurrentGameState state)
    {
        currentGameState = state;
        currentGameState();
    }

    void CountDownTime()
    {
        CurrentTime += Time.deltaTime;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quitgame()
    {
        Application.Quit();
    }

    
}
