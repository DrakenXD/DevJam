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

    public bool ActivePagController;
    public bool DesactivePagController;

    public bool ActivePagCredits;
    public bool DesactivePagCredits;

    public bool Quit;


    [SerializeField] private string nameScene;

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
        PagMenu.indexUpdate = IdButton;

        anim.SetBool("Activate", true);

        transform.localScale = sizemodificado;
    }
    public void ExitInButton()
    {
        MenuButtonJoystick.indexLast = IdButton;
        PagMenu.indexLast = IdButton;

        anim.SetBool("Activate", false);

        transform.localScale = sizenormal;
    }

    public void ClickInButton()
    {
        if (StartGame)
        {
            menu.StartGame();
        }

      

        if(ActiveGameObject != null) ActiveGameObject.SetActive(true);

        if(DisableGameObject != null) DisableGameObject.SetActive(false);

        

        // ativar a animação de pagina dos controles
        if (DesactivePagController) menu.ActivateControle(false);
        if (ActivePagController) menu.ActivateControle(true);

        if (ActivePagCredits) menu.ActivateCreditos(true);
        if (DesactivePagCredits) menu.ActivateCreditos(false);
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
