using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackMenu : MonoBehaviour
{
    private InputButton input;

    [SerializeField] private ButtonController buttoncontroller;

    private void Awake()
    {
        input = new InputButton();
    }
    private void Update()
    {
        buttoncontroller.anim.SetBool("Activate", true);
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void OnEnable()
    {
        input.Enable();
    }


    public void OnButtonClick(InputAction.CallbackContext context)
    {

        if (context.ReadValueAsButton()) buttoncontroller.ClickInButton();
    }
}
