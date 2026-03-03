using System.Collections;
using UnityEngine;

public class Note : Interactible
{
    public int noteId;
    [SerializeField] GameObject ui;
    [SerializeField] AudioSource noteAudio;

#nullable enable
    [SerializeField] GameObject? jumpscare;
    private bool hasJumpscare = false;
    public float jumpscareLength = 0.0f;

    private string[] noteTexts =
    {
        "They said I wouldn\'t last ten minutes in there. It\'s just an old lady\'s land. Tomorrow it\'s all coming down anyway.",
        "He keeps talking about selling. He doesn\'t hear what I hear.",
        "He said I was sick. He said the land isn\'t alive. He doesn\'t know.",
        "They drilled too deep. The soil moved after they left. Something is breathing beneath us.",
        "I did what had to be done. The ground accepted him.",
        "If you\'re reading this, you\'ve already stayed too long."
    };

    void Start()
    {
        if (jumpscare != null) hasJumpscare = true;
    }

    public override void Interact(GameObject other)
    {
        Debug.Log($"read note {noteId}");
        ui.BroadcastMessage("DisplayNote", noteTexts[noteId]);
        if (hasJumpscare) StartCoroutine(Jumpscare());
        noteAudio.Play();

    }

    IEnumerator Jumpscare()
    {
        yield return new WaitForSeconds(10.0f);
        jumpscare?.SetActive(true);

        yield return new WaitForSeconds(jumpscareLength);
        ui.BroadcastMessage("EndGame");
    }
}