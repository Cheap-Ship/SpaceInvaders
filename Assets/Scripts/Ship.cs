using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] Transform nozzle;
    [SerializeField] float velocity = 5f;
    [SerializeField] int lives = 3;

    float minX, maxX;

    private void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 0.5f;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fire, nozzle.position, nozzle.rotation);
        }

        Mover();
    }

    private void Mover()
    {
        float hMov = Input.GetAxis("Horizontal");
        transform.position += hMov * velocity * Vector3.right * Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        lives--;
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
