using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour
{
    public string name;
    public bool start;
    public float time;
    private float t;
    public Animator anim;
    public GameObject windowleft;
    public FadeController fade;
    public void SceneName(string _name)
    {
        anim.Play("Start");
        start = true;
        t = time;
        name = _name;
       
    }
    private void Update()
    {
        if (start)
        {
            if (t<1)
            {
                fade.AnimTelaPreta();
            }
            if (t<=0)
            {
                SceneManager.LoadScene(name);
            }
            else
            {
                t -= Time.deltaTime;
            }
        }
    }
    public void WindowLeftActivate()
    {
        windowleft.SetActive(true);
    }
}
