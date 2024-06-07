using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (currentOneWayPlatform != null)
                {
                    StartCoroutine(DisableCollision());
                }
            }
        }
        if (gameObject.name == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentOneWayPlatform != null)
                {
                    StartCoroutine(DisableCollision());
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

}
