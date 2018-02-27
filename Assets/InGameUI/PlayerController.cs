using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform view;
    [SerializeField] float rotationSpeed;

    CharacterController character;
    bool isCursorOverriden;

    void Start()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        UpdateMovement();
        UpdateLook();
    }

    void Update()
    {
        UpdateCursorOverride();
    }

    void UpdateMovement()
    {
        Vector3 movement = new Vector3(
                               Input.GetAxis("Horizontal"),
                               0,
                               Input.GetAxis("Vertical")
                           );
        
        movement = transform.TransformVector(movement);
        character.SimpleMove(movement * speed);
    }

    void UpdateCursorOverride()
    {
        if (Input.GetButtonDown("CursorOverride"))
        {
            isCursorOverriden = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetButtonUp("CursorOverride"))
        {
            isCursorOverriden = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void UpdateLook()
    {
        if (!isCursorOverriden)
        {
            var h = Input.GetAxis("HorizontalView");
            var v = Input.GetAxis("VerticalView");

            transform.Rotate(Vector3.up, h * rotationSpeed * 90 * Time.fixedDeltaTime);
            view.Rotate(Vector3.right, v * rotationSpeed * 90 * Time.fixedDeltaTime);
        }
    }
}
