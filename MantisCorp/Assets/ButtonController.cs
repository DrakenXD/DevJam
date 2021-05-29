using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler , IPointerClickHandler 
{
    private MenuController menu;
    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuController>();
    }

    [Header("Type button")]
    public bool StartGame;
    public bool Controller;
    public bool Credits;
    public bool Quit;


    public int IdButton;
    public static int id;

    public GameObject ActiveGameObject;
    public GameObject DisableGameObject;

    public Animator anim;
    public Vector3 sizenormal;
    public Vector3 sizemodificado;

   

    public void EnterInButton()
    {
        MenuButtonJoystick.indexUpdate = IdButton;

        transform.localScale = sizemodificado;
    }
    public void ExitInButton()
    {
        MenuButtonJoystick.indexLast = IdButton;

        transform.localScale = sizenormal;
    }

    public void ClickInButton()
    {
        if (StartGame)
        {

        }
         
        if(ActiveGameObject != null)ActiveGameObject.SetActive(true);

        if(DisableGameObject != null) DisableGameObject.SetActive(false);

        MenuButtonJoystick.indexUpdate = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickInButton();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EnterInButton();   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ExitInButton();
    }
}
