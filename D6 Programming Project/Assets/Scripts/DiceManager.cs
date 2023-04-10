using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public Sprite[] DiceSprites;
    public Transform[] Placements;
    public GameObject DicePrefab;

    void Start()
    {
        foreach (Transform t in Placements) //for every transform value in the array, run this code once (which spawns one dice)
        {
            int number = Random.Range(0, DiceSprites.Length); //random number 1-6 (0-5)
            int color = Random.Range(0, 5); //random color 0-5
            GameObject go = Instantiate(DicePrefab);
            DicePrefab.GetComponent<Die>().SetValues(number, color); //stores relevant data in the dice's prefab

            go.GetComponent<SpriteRenderer>().sprite = DiceSprites[number]; //looks through and finds prefab spriterenderer, then changes the sprite to a random sprite it generated earlier
            go.transform.parent = t; //sets the game object as a child to the current placement transform
            go.transform.localPosition = Vector3.zero;
        }

    }


}
