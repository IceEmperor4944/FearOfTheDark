using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] GameObject noteFrame;

    [SerializeField] GameObject gameManager;

    public void DisplayNote(string text)
    {
        var noteText = noteFrame.GetComponentInChildren<TextMeshPro>();
        if (noteText != null)
        {
            noteFrame.SetActive(true);

            if (noteText.TryGetComponent(out TextMeshPro textMesh))
            {
                textMesh.text = text;
                gameManager.TryGetComponent(out GameManager manager);
                manager.notesCollected++;
            }
        }
    }

    public void CloseNote()
    {
        noteFrame.SetActive(false);
    }

    public void EndGame()
    {
        gameManager.BroadcastMessage("EndGame");
    }
}