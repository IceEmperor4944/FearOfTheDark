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
        if (other.tag == "Player") jumpscareAudio(); 
    }

    IEnumerator RunJumpscare()
    {
        Debug.Log("jumpscare running");

        //yield return new WaitForSeconds(2.0f);
        jumpscare.SetActive(true);

        yield return new WaitForSeconds(jumpscareLength);
        jumpscare.SetActive(false);
    }

   public void jumpscareAudio()
   {
        AudioSource  Audio = m_jsAudio;
        Audio.Play();  

   }
}
