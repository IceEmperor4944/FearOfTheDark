using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    [SerializeField] GameObject jumpscare;

    private void OnTriggerEnter(Collider other)
    {
        jumpscare.SetActive(true);
    }
}
