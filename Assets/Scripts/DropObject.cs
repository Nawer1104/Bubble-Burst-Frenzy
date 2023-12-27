using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public GameObject vfxCollie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Wall"))
        {
            GameObject vfx = Instantiate(vfxCollie, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);
            Destroy(gameObject);
        }
    }
}
