using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            // Reducir la cantidad de puntos de vida del enemigo
            hitPoints--;

            // Si el enemigo se queda sin puntos de vida, llamar al método Die()
            if (hitPoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            animator.StopPlayback();

            // Desactivar el componente de colisión del enemigo (si es necesario)
            Collider enemyCollider = GetComponent<Collider>();
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
            }

            // Notificar que se ha agregado una puntuación
            if (OnScoreAdded != null)
            {
                OnScoreAdded.Invoke(10);
            }
        }
    }

}