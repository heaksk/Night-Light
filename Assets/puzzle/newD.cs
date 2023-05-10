using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newD : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 screenPoint;
    private Vector3 offset;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        rb.MovePosition(curPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
    }
}
