using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    Rigidbody rb;

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
    }
}
