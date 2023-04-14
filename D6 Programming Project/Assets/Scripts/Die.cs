using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Die : MonoBehaviour
{
    public DiceManager diceManager; //dicemanager script
    public Transform currentDiceSlot; //slot where stacking happens
    public SpriteRenderer dieSprite;
    public Color32[] basic; //array list of 5 colors

    [SerializeField] private int DiceNumber; //number and color for later reference
    [SerializeField] private int DiceColor;
    [SerializeField] private int DicePlacement;

    public bool inCurrentSlot = false;
    public int layerMask = 1 << 5; //bitshift for layer 5, will ignore sprites
    

    RaycastHit2D hit;

    public void Awake()
    {
         diceManager = FindObjectOfType<DiceManager>();
         currentDiceSlot = GameObject.Find("CurrentDiceSlot").transform;

         DiceNumber = diceManager.number;
         DiceColor = diceManager.color;
         DicePlacement = diceManager.CurrentPlacement;

         dieSprite.color = basic[DiceColor]; //the color of the dice

        
    }

    public void OnMouseDown()
    {

        if (DicePlacement >= 5 && inCurrentSlot == false) //if the dice is on the bottom row and not in the stack
        {

            int[] temp = new int[3]; //array to send data to diceManager

            temp[0] = DiceNumber;
            temp[1] = DiceColor;
            temp[2] = DicePlacement;

            diceManager.SendMessage("DiceCheck", temp); //send dice stats to method within diceManager to check if the move is valid

            
            if (diceManager.moveOK) //if diceManager has given the OK to move
            {
                transform.position = currentDiceSlot.position; //move dice to the stack
                hit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, 5); 

                if (hit != false) //the raycast hit an object
                {
                    Destroy(hit.transform.gameObject); //destroy that object
                }

                diceManager.slotOpen = true; //this dice's slot is now open
                inCurrentSlot = true; //dice now occupies current slot
            }

            diceManager.moveOK = false; 
        }
        else if(inCurrentSlot == true) //discard the dice from the stack by clicking on it
        {
            HealthBar.Health--;
            DiceManager.streak = 0;
            print("reached");
            diceManager.CurrentNumber = -1; //reset values to default
            diceManager.CurrentColor = -1;
            Destroy(transform.gameObject);
        }
    }

    private void Update() //try and keep this as clean as possible, we don't want too much stuff running every frame for 11 different objects
    {
        if (Input.GetMouseButtonDown(0) == true && diceManager.slotOpen == true && DicePlacement == (diceManager.ChosenPlacement - 5)) //a click happened, and a movement was just permitted, and this dice is behind the chosen dice
        {
            transform.position = diceManager.Placements[DicePlacement + 5].position;
            DicePlacement = DicePlacement + 5;
            diceManager.slotOpen = false;
        }
    }
}
