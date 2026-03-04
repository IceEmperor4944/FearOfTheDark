using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject winUI;
    [SerializeField] TMP_Text noteCount;
    [HideInInspector] public int notesCollected = 0;

    [HideInInspector] public enum GameState { MainMenu, Playing, NoteOpen, Complete }
    [HideInInspector] public GameState currentState = GameState.MainMenu;

    void Update()
    {
        noteCount.text = "Notes Collected: " + notesCollected + "/6";

        switch (currentState)
        {
            case GameState.MainMenu:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                titleUI.SetActive(true);
                gameUI.SetActive(false);
                winUI.SetActive(false);
                break;
            case GameState.Playing:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                titleUI.SetActive(false);
                gameUI.SetActive(true);
                winUI.SetActive(false);
                break;
            case GameState.NoteOpen:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gameUI.SetActive(false);
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