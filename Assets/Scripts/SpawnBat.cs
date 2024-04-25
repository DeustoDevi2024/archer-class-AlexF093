using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jugador;
    public int rangoDistancia;
    public GameObject monstruoPrefab;
    public int cantidad;

    void Start()
    {
        GenerarMonstruos();
    }

    void GenerarMonstruos()
    {
        for (int i = 0; i < cantidad; i++)
        {
            float distancia;
            Vector3 posicionAleatoria;
            while(true){
                posicionAleatoria = new Vector3(Random.Range(-9f, 10f), 0f, Random.Range(-8f, 8f));
                distancia = Vector3.Distance(jugador.transform.position, posicionAleatoria);
                if (distancia > rangoDistancia)
                {
                    break;
                }
            }

            GameObject nuevoMonstruo = Instantiate(monstruoPrefab, posicionAleatoria, Quaternion.identity);
        }
    }
}
