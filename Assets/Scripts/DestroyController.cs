using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    [SerializeField]
    LayerMask ignoreMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterController2D controller = collision.GetComponent<CharacterController2D>();
            controller.Die();
            return; 
        }
        if ((ignoreMask & (1 << collision.gameObject.layer)) != 0)
        {
            return;
        }
        Destroy(collision.gameObject);
    }
}
