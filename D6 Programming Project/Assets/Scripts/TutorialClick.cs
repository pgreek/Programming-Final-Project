using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialClick : MonoBehaviour
{
    public Sprite[] sprites; //sprite array
    private int spriteIndex;

    private void Start()
    {
        spriteIndex = 0; //starts at 0
        GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
    }

    private void OnMouseDown()
    {
        if (spriteIndex >= sprites.Length - 1)
        {
            SceneManager.LoadScene("Menu");
            return;
        }
        spriteIndex++;
        GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex]; //renders the sprite at the index
    }
}
