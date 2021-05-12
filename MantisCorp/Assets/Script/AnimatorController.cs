using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;
    private string currentname;


    public void ChangeAnimator(string newName)
    {
        if (currentname == newName) return;

        if (newName != currentname)
        {
            anim.Play(newName);
        }

        currentname = newName;
    }
}
