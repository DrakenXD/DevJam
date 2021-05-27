using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuButtonJoystick : MonoBehaviour
{
    private InputButton input;

    public Transform buttonsParent;

    private ButtonController[] buttoncontroller;
    public int indexButton;
    public static int indexLast;
    public static int indexUpdate;
    public bool ClickUp;
    public bool ClickDown;

    public float timenextbutton = .5f;
    private float T_N_B;

    private void Awake()
    {
        input = new InputButton();

        
    }
    private void Start()
    {
        buttoncontroller = buttonsParent.GetComponentsInChildren<ButtonController>();

        indexButton = buttoncontroller.Length-1;

       
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void OnEnable()
    {
        input.Enable();
    }

    private void Update()
    {
        buttoncontroller[indexLast].anim.SetBool("Activate", false);
        buttoncontroller[indexUpdate].anim.SetBool("Activate",true);

        buttoncontroller[indexLast].ExitInButton();
        buttoncontroller[indexUpdate].EnterInButton();
       

        if (ClickUp)
        {
            indexLast = indexUpdate;

            if (T_N_B <= 0)
            {
                if (indexUpdate >= indexButton)
                {
                    indexUpdate = 0;
                    buttoncontroller[indexUpdate].EnterInButton();
                }
                else
                {
                    indexUpdate++;
                    buttoncontroller[indexUpdate].EnterInButton();
                }
                T_N_B = timenextbutton;
            }
     


        }

        if (ClickDown)
        {
            indexLast = indexUpdate;

            if (T_N_B <= 0)
            {

                if (indexUpdate <= 0)
                {
                    indexUpdate = indexButton;
                    buttoncontroller[indexUpdate].EnterInButton();

                }
                else
                {
                    indexUpdate--;
                    buttoncontroller[indexUpdate].EnterInButton();
                }

                T_N_B = timenextbutton;
            }
        



        }

        T_N_B -= Time.deltaTime;
    }
    public void OnButtonUp(InputAction.CallbackContext context)
    {
        ClickUp = context.ReadValueAsButton();

       

        

        
    }
    public void OnButtonDown(InputAction.CallbackContext context)
    {
        ClickDown = context.ReadValueAsButton();

     

    

     
    }
    public void OnButtonClick(InputAction.CallbackContext context)
    {
        bool Click = context.ReadValueAsButton();

        if (Click)
        {
            buttoncontroller[indexUpdate].EnterInButton();
        }
    }
}
