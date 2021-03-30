using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField] GameObject invaderA;
    [SerializeField] GameObject invaderB;
    [SerializeField] GameObject invaderC;
    [SerializeField] int nInvaders = 7;

    void Awake()
    {
        GameObject[] Invaders = { invaderA, invaderB, invaderC }; //Array com os invaders, de forma a não ter de criar um for para cada

        float minX = Mathf.Ceil(nInvaders / 2) * -1; //Calculo automático do x mínino para que não seja preciso Serializar
        minX -= nInvaders % 2 == 0 ? 0.5f : 1f; //Ajuste de forma a ficarem no centro
        
        for(int l = 0; l < Invaders.Length; l++)
        {
            for (float r = 0; r < 1; r += 0.5f)
            {
                for (int i = 1; i <= nInvaders; i++)
                {
                    GameObject newInvader = Instantiate(Invaders[l], transform);
                    newInvader.transform.position = new Vector3(minX + i, l - 0.5f + r, 0);
                }
            }
        }
    }
}
