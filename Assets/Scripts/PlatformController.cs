using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float distance;

    Vector3 _originalPosition;
    Vector3 _targetPosition;

    private void Awake()
    {
        _originalPosition = transform.position;
        _targetPosition = _originalPosition;
        _targetPosition.x += distance;
    }

    private void FixedUpdate()
    {
        float time = Mathf.PingPong(Time.time * speed, 1.0F);
        Vector3 pos = Vector3.Lerp(_originalPosition, _targetPosition, time);
        transform.position = pos;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
