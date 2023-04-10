using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClickDetect : MonoBehaviour
{
    void OnMouseDown() //Detects when button is clicked and loads corresponding scene.
    {
        Debug.Log("Menu Click");
        if (gameObject.tag == "PlayButton") //Load Main game scene
        {
            SceneManager.LoadScene("SampleScene");
        } else if (gameObject.tag == "HowToPlayButton") //Load Tutorial Scene
        {
            SceneManager.LoadScene("How To Play");
        } else if (gameObject.tag == "StatsButton" ) // Load Stats Scene
        {
            SceneManager.LoadScene("Stats");
        }
    }
}
