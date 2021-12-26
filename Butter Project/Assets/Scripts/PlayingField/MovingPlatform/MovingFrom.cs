using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFrom : MonoBehaviour
{
    private bool _isReached;
    private float _durationBeforeStart = 0.5f;
    public bool IsReached => _isReached;

    private void OnCollisionEnter(Collision collision)
    {
        _isReached = true;
        collision.transform.SetParent(transform);
    }

    public void MoveToNextLevel(float height)
    {
        StartCoroutine(MoveUp(height));
    }

    private IEnumerator MoveUp(float height)
    {
        float finishPoint = transform.position.y + height;
        yield return new WaitForSeconds(_durationBeforeStart);

        while (transform.position.y < finishPoint)
        {
            transform.position += new Vector3(0, 0.03f, 0);
            yield return null;
        }
    }
}
