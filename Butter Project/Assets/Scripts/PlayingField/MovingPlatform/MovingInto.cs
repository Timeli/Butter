using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInto : MonoBehaviour
{
    private bool _isReached;
    public bool IsReached => _isReached;

    public void MoveToCurrentLevel(float height)
    {
        StartCoroutine(MoveUp(height));
    }

    private IEnumerator MoveUp(float height)
    {
        float finishPoint = 0;
        while (transform.position.y < finishPoint)
        {
            transform.position += new Vector3(0, 0.03f, 0);
            yield return null;
        }
    }
}
