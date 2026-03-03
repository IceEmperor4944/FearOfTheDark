using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject winUI;
    [SerializeField] TMP_Text notesObject;

    [HideInInspector] public int notesCollected = 0;

    static GameManager instance;
    public static GameManager Instacnce { get { return instance; } }

    enum GameState
    {
        MainMenu,
        Playing,
        NoteOpened,
        Complete
    }

    GameState currentState = GameState.MainMenu;

    void Update()
    {
       
        notesObject.text = "Notes Collected: " + notesCollected + "/6";

        switch (currentState)
        {
            case GameState.MainMenu:
                titleUI.SetActive(true);
                gameUI.SetActive(false);
                winUI.SetActive(false);
                break;
            case GameState.Playing:
                titleUI.SetActive(false);
                gameUI.SetActive(true);
                winUI.SetActive(false);
                break;
            case GameState.Complete:
                titleUI.SetActive(false);
                gameUI.SetActive(false);
                winUI.SetActive(true);
                break;
        }
    }
    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(5.0f);

        currentState = GameState.MainMenu;
    }
    public void EndGame()
    {
        currentState = GameState.Complete;
        StartCoroutine(ReturnToMainMenu());
    }
    public void OnStartGame()
    {
        currentState = GameState.Playing;
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