using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField] GameObject invaderA;
    [SerializeField] GameObject invaderB;
    [SerializeField] GameObject invaderC;
    [SerializeField] GameObject invaderAUnbreak;
    [SerializeField] GameObject invaderBUnbreak;
    [SerializeField] GameObject invaderCUnbreak;
    [SerializeField] int nInvaders = 7;
    [SerializeField] float unbreakChance = 0.15f;
    [SerializeField] float cooldown = 1f;
    float timer = 0f, border;
    int flagX = 1; // 1 = direita ; -1 = esquerda
    bool flagY = true; // True = desce ; False = Não desce

    void Awake()
    {
        GameObject[] Invaders = { invaderA, invaderB, invaderC }; //Array com os invaders, de forma a não ter de criar um for para cada
        GameObject[] UnbreakInvaders = { invaderAUnbreak, invaderBUnbreak, invaderCUnbreak };

        float minX = Mathf.Ceil(nInvaders / 2) * -1; //Calculo automático do x mínino para que não seja preciso Serializar
        minX -= nInvaders % 2 == 0 ? 0.5f : 1f; //Ajuste de forma a ficarem no centro
        
        for(int l = 0; l < Invaders.Length; l++)
        {
            for (float r = 0; r < 1; r += 0.5f)
            {
                for (int i = 1; i <= nInvaders; i++)
                {
                    GameObject newInvader = null;
                    if(Random.value < unbreakChance)
                    {
                        newInvader = Instantiate(UnbreakInvaders[l], transform);
                    } else
                    {
                        newInvader = Instantiate(Invaders[l], transform);
                    }
                    newInvader.transform.position = new Vector3(minX + i, (l - 0.5f + r)/1.25f + 1f, 0);
                }
            }
        }

        border = (8 - (float)nInvaders) / 2; // Borda igual para qualquer quantidade de invaders
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            Vector3 position = transform.position;
            if (transform.position.x > -border && transform.position.x < border || !flagY)
            {
                position.x += (border / 5) * flagX; // Movimentam-se sempre 5 vezes entre o centro e a borda (11 de lado a lado)
                flagY = true;
            } else if (flagY)
            {
                position.y -= 0.4f;
                flagX *= -1;
                flagY = false;
            }
            transform.position = position;
            timer = 0f;
        }
    }
}
