using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] GameObject fire = null;
    [SerializeField] float cdMax = 10f; // Máximo do cooldown de disparo
    [SerializeField] float cdMin = 1f; // Mínimo para o cooldown de disparo
    [SerializeField] int armor = 10;
    float cooldown, timer = 0f;

    private void Start()
    {
        SetCooldown(); // Começar com um cooldown aleatório
    }

    private void Update()
    {
        if(tag == "Breakable")
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                Instantiate(fire, transform.position, transform.rotation);
                timer = 0f;
                SetCooldown(); // Mudar depois de cada tiro
            }
        }
    }

    private void SetCooldown()
    {
        cooldown = Random.Range(cdMin, cdMax); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        armor--;
        if (tag == "Breakable" || armor <= 0)
        {
            Destroy(gameObject);
        }
        Destroy(collision.gameObject);
    }
}
