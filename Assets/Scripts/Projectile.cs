using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject vfxCollie;
    public GameObject vfxDestroy;


    private void Awake()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == gameObject.tag)
        {
            GameObject vfx = Instantiate(vfxCollie, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].score_current += 1;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].SetText();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            GameObject vfx = Instantiate(vfxDestroy, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);
            Destroy(gameObject);
        }
    }
}
