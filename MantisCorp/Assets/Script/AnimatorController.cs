using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animPlayer;
    private string currentnamePlayer;
    public Animator animUI;
    private string currentnameUI;

    public void ChangeAnimatorPlayer(string newName)
    {
        if (currentnamePlayer == newName) return;

        if (newName != currentnamePlayer)
        {
            animPlayer.Play(newName);
        }

        currentnamePlayer = newName;
    }

    public void ChangeAnimatorUI(string newName)
    {
        if (currentnameUI == newName) return;

        if (newName != currentnameUI)
        {
            animUI.Play(newName);
        }

        currentnameUI = newName;
    }
}
