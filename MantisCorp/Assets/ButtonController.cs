using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler , IPointerClickHandler 
{
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
      

        ActiveGameObject.SetActive(true);

        DisableGameObject.SetActive(false);

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
