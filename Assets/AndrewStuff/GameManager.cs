using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject settingsUI;


    static GameManager instance;
    public static GameManager Instacnce { get { return instance; } }

    enum GameState
    {
        MainMenu,
        Playing,
        Settings,
        Complete
    }

    GameState currentState = GameState.MainMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                titleUI.SetActive(true);
                gameUI.SetActive(false);
                winUI.SetActive(false);
                settingsUI.SetActive(false);
                break;
            case GameState.Playing:
                titleUI.SetActive(false);
                gameUI.SetActive(true);
                winUI.SetActive(false);
                settingsUI.SetActive(false);
                break;
            case GameState.Settings:
                titleUI.SetActive(false);
                gameUI.SetActive(false);
                winUI.SetActive(false);
                settingsUI.SetActive(true);
                break;
            case GameState.Complete:
                titleUI.SetActive(false);
                gameUI.SetActive(false);
                winUI.SetActive(true);
                settingsUI.SetActive(false);
                break;
        }
    }

    public void OnStartGame()
    {
        currentState = GameState.Playing;
    }
    public void OnSettings()
    {
        currentState = GameState.Settings;
    }
    public void OnMainMenu()
    {
        currentState = GameState.MainMenu;
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
