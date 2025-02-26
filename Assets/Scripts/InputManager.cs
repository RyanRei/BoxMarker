using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created

   




    private InputSystem_Actions action;

    private void Awake()
    {
        action=new InputSystem_Actions();
    }

    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }

    void Start()
    {
        action.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        //action.Touch.PrimaryContact.started += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {

    }

}
