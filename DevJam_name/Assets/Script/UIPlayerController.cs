using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerController : MonoBehaviour
{
    private PlayerStats stats;

    public Image hpbar;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        ImageBar(hpbar);
    }

    void ImageBar(Image bar)
    {
        bar.fillAmount = stats.life / stats.Maxlife;
    }
}
