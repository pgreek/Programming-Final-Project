using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCircle : MonoBehaviour
{
    public Color32 color;
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
    }
    public IEnumerator GettingSmaller(float duration)
    {
        float t = 0f;
        Vector3 initialScale = transform.localScale;
        while (t < duration)
        {
            t += Time.deltaTime;
            //LERPHEREEEEEEEEEEEEEEEEEEEEEEEEEEE
            float scale = Mathf.Lerp(initialScale.x, 0f, t / duration);
            transform.localScale = new Vector3(scale, scale, 1f);
            yield return null;
        }
        Destroy(gameObject);
    }
}