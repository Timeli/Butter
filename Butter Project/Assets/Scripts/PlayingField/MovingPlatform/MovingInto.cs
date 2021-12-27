using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInto : MonoBehaviour
{
    [SerializeField] private Vector3 _finishPos;

    private void Start()
    {
        StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp()
    {
        Vector3 finishPoint = new Vector3(0, 0, 12);
        while (transform.position != finishPoint)
        {
            transform.position += new Vector3(0, 0.03f, 0);
            yield return null;
        }
        transform.GetChild(0).parent = null;
    }
}
