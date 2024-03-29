﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Intro RPG/Player/Heart")]
public class HeartHealth : MonoBehaviour
{
    #region Variables
    [Header("Player Stats")]
    //public maxHealth
    public static int maxHealth;
    //public curHealth
    public static int curHealth;
    [Header("Heart Slots")]
    //Canvas Image heartSlots array
    public Image[] heartSlots;
    //Sprite hearts array
    public Sprite[] hearts;
    //private percent healthPerSection
    private float healthPerSection;
    #endregion
    #region Start
    private void Start()
    {
        UpdateHearts();
    }
    #endregion
    #region Update 
    private void Update()
    {
        int i = 0;
        foreach (Image slot in heartSlots)
        {
            if (curHealth >= ((healthPerSection * 4)) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[0];
            }
            else if (curHealth >= ((healthPerSection * 3)) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[1];
            }
            else if (curHealth >= ((healthPerSection * 2)) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[2];
            }
            else if (curHealth >= ((healthPerSection * 1)) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[3];
            }
            else
            {
                heartSlots[i].sprite = hearts[4];
            }
            i++;
        }
    }
    #endregion
    #region UpdateHearts
    private void UpdateHearts()
    {
        healthPerSection = curHealth / (heartSlots.Length * 4);
    }
    #endregion
}