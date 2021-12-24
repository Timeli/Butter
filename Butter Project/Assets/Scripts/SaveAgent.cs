using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAgent : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSave;

    private void Start()
    {
        for (int i = 0; i < objectsToSave.Length; i++)
        {
            DontDestroyOnLoad(objectsToSave[i]);
        }
    }
}
