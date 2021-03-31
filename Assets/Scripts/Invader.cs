using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] GameObject fire = null;
    [SerializeField] float cooldown = 1.5f;
    float timer = 0f;

    private void Update()
    {
        if(tag == "Breakable")
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                Instantiate(fire, transform.position, transform.rotation);
                timer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            Destroy(gameObject);
        }
        Destroy(collision.gameObject);
    }
}
