using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmallCircle : MonoBehaviour
{
    public Color32 color;
    public void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
        StartCoroutine(GettingSmaller(2.5f));
    }

    public IEnumerator GettingSmaller(float duration)
    {
        float t = 0f;
        Vector3 initialScale = transform.localScale;
        while (t < duration)
        {
            //lerpHERE
            t += Time.deltaTime;
            float scale = Mathf.Lerp(initialScale.x, 0f, t / duration);
            transform.localScale = new Vector3(scale, scale, 1f);
            yield return null;
        }
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
    }
}