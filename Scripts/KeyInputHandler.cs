using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "InputKeybinds", menuName = "CustomStuff/Inputkeybinds", order = 1)]
public class KeyInputHandler : ScriptableObject
{
    public List<string> movement;
}

public class RegisterInputs : MonoBehaviour
{
    public InputActionAsset asset;
    public GameObject pauseMenu;
    private InputAction movement, escape, space, interact;

    public Vector3 MoveDir { get; private set; }
    public bool Jump { get; private set; }
    public bool Grounded { get; private set; }

    private void Awake()
    {
        movement = asset.FindAction("Movement");
        escape = asset.FindAction("Escape");
        space = asset.FindAction("Space");
        interact = asset.FindAction("Interact");
        
        //WITH CANCEL
        movement.performed += MoveCharacter;
        movement.canceled += MoveCharacter;
        space.performed += Space;

        //WITHOUT CANCEL
        escape.performed += Escape;
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        movement.performed -= MoveCharacter;
        movement.canceled -= MoveCharacter;
        space.performed -= Space;
        escape.performed -= Escape;
    }

    public void MoveCharacter(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        MoveDir = new Vector3(dir.x, 0, dir.y);
    }

    public void Escape(InputAction.CallbackContext context)
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
    }

    public void Space(InputAction.CallbackContext context)
    {
        if (Grounded)
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
        Jump = false; 
    }
}
