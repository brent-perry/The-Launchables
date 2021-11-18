using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public AnimationCurve fadeCurve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime;
            float alpha = fadeCurve.Evaluate(time);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime;
            float alpha = fadeCurve.Evaluate(time);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
