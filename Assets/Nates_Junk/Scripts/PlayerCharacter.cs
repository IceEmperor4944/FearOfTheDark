using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Camera cam;

    public float moveForce = 1.0f;
    public float sensitivity = 10.0f;

    void Start()
    {
        rb = (TryGetComponent(out Rigidbody r) ? r : null);
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


        //if mouse changed position this frame
        var lookDelta = Mouse.current.delta.ReadValue();
        if (lookDelta.magnitude > 0)
        {
            //set x rotation equal to change
            transform.Rotate(Vector3.up, lookDelta.x * sensitivity * Time.deltaTime);
            //transform.rotation.eulerAngles.Set(
            //    //(Mouse.current.delta.left.magnitude > Mouse.current.delta.right.magnitude) ? Mouse.current.delta.left.magnitude : Mouse.current.delta.right.magnitude,
            //    lookDelta.x,
            //    transform.rotation.eulerAngles.y,
            //    transform.rotation.eulerAngles.z
            //    );
            //set camera y rotation equal to change
            cam.transform.Rotate(Vector3.left, lookDelta.y * sensitivity * Time.deltaTime);
            //cam.transform.rotation.eulerAngles.Set(
            //    transform.rotation.eulerAngles.x,
            //    //(Mouse.current.delta.up.magnitude > Mouse.current.delta.down.magnitude) ? Mouse.current.delta.up.magnitude : Mouse.current.delta.down.magnitude,
            //    lookDelta.y,
            //    transform.rotation.eulerAngles.z);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 5.0f))
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

    //public void OnLook(InputAction.CallbackContext context)
    //{
    //    lookDelta = context.ReadValue<Vector2>();
    //}
}
