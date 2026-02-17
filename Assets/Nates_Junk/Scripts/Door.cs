using System.Collections;
using UnityEngine;

public class Door : Interactible
{
    [SerializeField] Rigidbody rb;
    private bool isOpen = false;
    private bool isMoving = false;

    public override void Interact(GameObject other)
    {
        if (!isMoving)
        {
            if (!isOpen)
            {
                StartCoroutine(MoveDoor(1.0f));
                isOpen = true;
            }
            else
            {
                StartCoroutine(MoveDoor(-1.0f));
                isOpen = false;
            }
        }
    }

    IEnumerator MoveDoor(float dir)
    {
        rb.AddForce(new Vector3(0.0f, 0.0f, 5.0f * dir), ForceMode.VelocityChange);
        isMoving = true;
        yield return new WaitForSeconds(1.0f);

        rb.angularVelocity = new Vector3(0, 0, 0);
        isMoving = false;
    }
}
