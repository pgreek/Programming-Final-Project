using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public SpriteRenderer dieSprite;
    public Color32[] basic; //array list of 5 colors

    public void SetValues(int n, int c)
    {
        int number = n; //number and color for later reference
        int color = c;

        dieSprite.color = basic[color]; //the color of the dice

        print(n + " " + c);
    }
}
