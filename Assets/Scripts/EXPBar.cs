using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Intro RPG/Player/EXPBar")]
public class EXPBar : MonoBehaviour
{
    [Header("XP Reference")]
    public float maxXp;
    public float curXP, delayXp;
    [Header("Delay Speed")]
    public float speed = 5f;
    [Header("UI Reference")]
    public Slider xpSlider;
    public Image xpFill;
    public Slider delaySlider;
    public Image delayFill;

    void Update()
    {
        xpSlider.value = Mathf.Clamp01(curXP / maxXp);
        if (delayXp < curXP)
        {
            delayXp += Time.deltaTime * speed;
        }
        delaySlider.value = Mathf.Clamp01(delayXp / maxXp);
        ManageXPBar();
    }

    void ManageXPBar()
    {
        if (delayXp > curXP)
        {
            xpFill.enabled = true;
            delayXp = curXP;
            delaySlider.value = xpSlider.value;
        }
    }
}
