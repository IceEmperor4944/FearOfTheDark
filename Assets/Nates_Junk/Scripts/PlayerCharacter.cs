using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Camera cam;

    [SerializeField] float moveForce = 1.0f;

    void Start()
    {
        rb = (TryGetComponent(out Rigidbody r) ? r : null);
    }

    void Update()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(0, 0, 0);

            if (Keyboard.current.wKey.isPressed)
            {
                rb.AddForce(new Vector3(0, 0, 10 * moveForce));
            }
            if (Keyboard.current.sKey.isPressed)
            {
                rb.AddForce(new Vector3(0, 0, -10 * moveForce));
            }
            if (Keyboard.current.aKey.isPressed)
            {
                rb.AddForce(new Vector3(-10 * moveForce, 0, 0));
            }
            if (Keyboard.current.dKey.isPressed)
            {
                rb.AddForce(new Vector3(10 * moveForce, 0, 0));
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, /*cam.transform.forward*/ transform.forward, out hit, 5.0f))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if (hit.collider.TryGetComponent(out Interactible inter))
            {
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    inter.Interact(gameObject);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 5.0f, Color.green);
        }
    }
}
