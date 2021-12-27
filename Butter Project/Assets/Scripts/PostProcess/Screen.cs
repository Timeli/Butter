using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Screen : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcess;

    private ColorGrading _colorGrading;

    public void Start()
    {
        _colorGrading = _postProcess.profile.GetSetting<ColorGrading>();
    }

    public void InitialDimmingScreen()
    {
        StartCoroutine(DimmingScreen());
    }

    private IEnumerator DimmingScreen()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 150; i++)
        {
            _colorGrading.postExposure.value = (-10.0f * i) / 150;
            yield return null;
        }
    }
}
