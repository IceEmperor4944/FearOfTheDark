using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject flashlight;
    [SerializeField] AudioSource footstepAudio;

    public float moveForce = 1.0f;
    public float sensitivity = 10.0f;
    public bool isMoving = false; 


    void Start()
    {
        rb = TryGetComponent(out Rigidbody r) ? r : null;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(0, 0, 0); 
          

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
            if (Keyboard.current.dKey.isPressed )
            {
                rb.AddRelativeForce(new Vector3(10 * moveForce, 0, 0));
                isMoving = true;
            }
            
         
        }


        if (flashlight.TryGetComponent(out Light l))
        {
            if (Keyboard.current.fKey.wasPressedThisFrame) l.enabled = !l.enabled;
        }

        //if mouse changed position this frame
        var lookDelta = Mouse.current.delta.ReadValue();
        if (lookDelta.magnitude > 0)
        {
            //set x rotation equal to change
            transform.Rotate(Vector3.up, lookDelta.x * sensitivity * Time.deltaTime);
            //set camera y rotation equal to change
            cam.transform.Rotate(Vector3.left, lookDelta.y * sensitivity * Time.deltaTime);
            //flashlight.transform.Rotate(Vector3.left, lookDelta.y * sensitivity * Time.deltaTime);
        }

        RaycastHit hit;
        Vector3 head = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        if (Physics.Raycast(head, cam.transform.forward, out hit, 5.0f))
        {
            Debug.DrawLine(head, hit.point, Color.red);
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
            Debug.DrawRay(head, cam.transform.forward * 5.0f, Color.green);
        }

        if (isMoving == true)
        {
            footstepAudio.Play();
        }
        else
        {
            footstepAudio.Stop();
        }
        
    }
}
