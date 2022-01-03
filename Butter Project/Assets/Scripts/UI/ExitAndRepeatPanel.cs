using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitAndRepeatPanel : MonoBehaviour
{
    [SerializeField] private Transform _panel;

    public void PanelAppear()
    {
        _panel.gameObject.SetActive(true);
    }
}
