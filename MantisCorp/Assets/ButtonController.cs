using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator anim;

    public Vector3 sizenormal;
    public Vector3 sizemodificado;

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("Activate",true);
        transform.localScale = sizemodificado;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("Activate", false);
        transform.localScale = sizenormal;
    }
}
