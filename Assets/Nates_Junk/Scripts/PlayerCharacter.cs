using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCharacter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject lookControl;
    [SerializeField] GameObject flashlight;
    [SerializeField] AudioSource footstepAudio;
    [SerializeField] AudioSource flashlightAudio;
    public float moveForce = 1.0f;
    public float sensitivity = 10.0f;
    public bool isMoving = false;
    void Start()
    {
        rb = TryGetComponent(out Rigidbody r) ? r : null;
    }
    void Update()
    {
        isMoving = false;

        if (rb != null)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

            if (Keyboard.current.wKey.isPressed)
            {
                rb.AddRelativeForce(new Vector3(0, 0, 10 * moveForce));
                isMoving = true;
            }
            if (Keyboard.current.sKey.isPressed)
            {
                rb.AddRelativeForce(new Vector3(0, 0, -10 * moveForce));
                isMoving = true;
            }
            if (Keyboard.current.aKey.isPressed)
            {
                rb.AddRelativeForce(new Vector3(-10 * moveForce, 0, 0));
                isMoving = true;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                rb.AddRelativeForce(new Vector3(10 * moveForce, 0, 0));
                isMoving = true;
            }
        }

        if (flashlight.TryGetComponent(out Light l))
        {
            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                l.enabled = !l.enabled;
                flashlightAudio.Play();
            }
        }

        var lookDelta = Mouse.current.delta.ReadValue();
        if (lookDelta.magnitude > 0)
        {
            transform.Rotate(Vector3.up, lookDelta.x * sensitivity * Time.deltaTime);
            lookControl.transform.Rotate(Vector3.left, lookDelta.y * sensitivity * Time.deltaTime);
        }

        RaycastHit hit;
        if (Physics.Raycast(lookControl.transform.position, lookControl.transform.forward, out hit, 10.0f))
        {
            Debug.DrawLine(lookControl.transform.position, hit.point, Color.red);
            if (hit.collider.TryGetComponent(out Interactible inter))
            {
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    inter.Interact(gameObject);
                }
            }
        }
        else Debug.DrawRay(lookControl.transform.position, lookControl.transform.forward * 5.0f, Color.green);

        HandleAudio();
    }

    void HandleAudio()
    {
        if (isMoving && !footstepAudio.isPlaying)
            footstepAudio.Play();
        else if (!isMoving)
            footstepAudio.Stop();
    }
}