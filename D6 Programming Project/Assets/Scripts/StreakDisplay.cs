using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StreakDisplay : MonoBehaviour
{

    public TextMeshProUGUI Streak;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Streak.text = ("Streak: "+ (int)DiceManager.streak);
        
    }
    


}
