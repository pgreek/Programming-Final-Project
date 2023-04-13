using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public Sprite[] DiceSprites;
    public Transform[] Placements;
    public GameObject DicePrefab;

    public int number; //stats generated for a dice at startup
    public int color;

    //dice statistics for the existing dice in the stack
    public int CurrentPlacement;
    public int CurrentNumber; 
    public int CurrentColor;

    //dice statistics for the dice that the player just chose
    public int ChosenNumber;
    public int ChosenColor;
    public int ChosenPlacement;

    public bool moveOK = false;
    public bool slotOpen = false;

    public Transform t;

    void Start()
    {
        CurrentNumber = -1; //default values for checking if space is free
        CurrentColor = -1;

        foreach (Transform t in Placements) //for every transform value in the array, run this code once (which spawns one dice per slot)
        {
            DiceGen(t);
        }

    }

    void DiceGen(Transform t2) //accepts a transform position
    {
        CurrentPlacement = System.Array.IndexOf(Placements, t2); //specific placement for this dice

        number = Random.Range(0, DiceSprites.Length); //random number 1-6 (0-5 in array)
        color = Random.Range(0, 6); //random color 0-5
        GameObject go = Instantiate(DicePrefab);

        go.GetComponent<SpriteRenderer>().sprite = DiceSprites[number]; //looks through and finds prefab spriterenderer, then changes the sprite to a random sprite it generated earlier
        go.transform.parent = t2; //sets the game object as a child to the current placement transform
        go.transform.localPosition = Vector3.zero;
    }

    void DiceCheck(int[] chosenDiceStats)
    {
        ChosenNumber = chosenDiceStats[0];
        ChosenColor = chosenDiceStats[1];
        ChosenPlacement = chosenDiceStats[2]; //accept data sent from clicked dice

        if (CurrentNumber != -1)
        {
            if(ChosenNumber == CurrentNumber + 1)
            {
                //increase streak
                moveOK = true;
                CurrentNumber = ChosenNumber; //the chosen dice inherits the space
                CurrentColor = ChosenColor;

                Transform t = Placements[chosenDiceStats[2] - 5];
                DiceGen(t);

            }
            else if (ChosenColor == CurrentColor)
            {
                //increase streak
                moveOK = true;
                CurrentNumber = ChosenNumber; //the chosen dice inherits the space
                CurrentColor = ChosenColor;

                Transform t = Placements[chosenDiceStats[2] - 5];
                DiceGen(t);


            }
            else if (ChosenNumber == 0 && CurrentNumber == 5)
            {
                //increase streak
                moveOK = true;
                CurrentNumber = ChosenNumber; //the chosen dice inherits the space
                CurrentColor = ChosenColor;

                Transform t = Placements[chosenDiceStats[2] - 5];
                DiceGen(t);

            }
            else //illegal move
            {
                moveOK = false;
            }
        }
        else //space is free, put whatever dice was chosen in here
        {
            
            CurrentNumber = ChosenNumber; //the chosen dice inherits the space
            CurrentColor = ChosenColor;


            //move new dice over old dice
            moveOK = true;
            Transform t = Placements[chosenDiceStats[2] - 5];
            DiceGen(t);
        } 
    }
}
