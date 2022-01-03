using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameScreen : MonoBehaviour
{
    [SerializeField] private Transform _panel;

    public void PanelAppear()
    {
        _panel.gameObject.SetActive(true);
    }
}
