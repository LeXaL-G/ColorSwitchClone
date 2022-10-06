using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private string currentColor;
    [SerializeField] private Color[] color;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        SetRandomColor();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ColorChanger"))
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag!=currentColor)
        {
            Debug.Log("Game Over");
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color=color[0];
                break;
            case 1:
                currentColor = "Yellow";
                sr.color=color[1];
                break;
            case 2:
                currentColor = "Magenta";
                sr.color=color[2];
                break;
            case 3:
                currentColor = "Purple";
                sr.color = color[3];
                break;
        }
    }
}