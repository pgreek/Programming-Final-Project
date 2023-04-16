using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalScore : MonoBehaviour
{

    public TextMeshProUGUI Score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Score.text = ("Total Score: " + (int)DiceManager.totalscore);
        //forChecking
        Debug.Log(Score);
    }



}
