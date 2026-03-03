using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] GameObject noteFrame;
    [SerializeField] TMP_Text noteText;
    [SerializeField] GameManager gameManager;

    public void DisplayNote(string text)
    {
        noteFrame.SetActive(true);

        noteText.text = text;
        gameManager.notesCollected++;
        gameManager.currentState = GameManager.GameState.NoteOpen;
    }

    public void CloseNote()
    {
        noteFrame.SetActive(false);
        gameManager.currentState = GameManager.GameState.Playing;
    }

    public void EndGame()
    {
        gameManager.BroadcastMessage("EndGame");
    }
}