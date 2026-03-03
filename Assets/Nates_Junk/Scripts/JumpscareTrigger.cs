using System.Collections;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    [SerializeField] AudioSource m_jsAudio;
    [SerializeField] GameObject jumpscare;
    public float jumpscareLength = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") StartCoroutine(RunJumpscare());
    }

    IEnumerator RunJumpscare()
    {
        Debug.Log("jumpscare running");

        //yield return new WaitForSeconds(2.0f);
        jumpscare.SetActive(true);

        jumpscare.SetActive(true);
        m_jsAudio.Play();

        yield return new WaitForSeconds(jumpscareLength);
        jumpscare.SetActive(false);

        jumpscare.SetActive(false);
        m_jsAudio.Stop();
    }

}