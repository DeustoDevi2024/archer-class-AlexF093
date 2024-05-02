using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;

    private bool gameEnded = false;

    private void Update()
    {
        // Verificar si el jugador salió del mapa
        if (player.transform.position.y < -10f)
        {
            EndGame();
        }

        // Verificar si el jugador mató a todos los enemigos
        if (enemies.Length == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("Juego terminado");

            // Reiniciar la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
