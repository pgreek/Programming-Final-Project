using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public static int Health;
    public Sprite[] sprites; //sprite array

    // Start is called before the first frame update
    void Start()
    {
        Health = 7;
        GetComponent<SpriteRenderer>().sprite = sprites[Health];
    }

    // Update is called once per frame
    void Update()
    {
    if (Health >= 0 && Health < sprites.Length)
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Health];
    }
    if (Health <= 0)
    {
        SceneManager.LoadScene("GameOver");
    }
}

    }

