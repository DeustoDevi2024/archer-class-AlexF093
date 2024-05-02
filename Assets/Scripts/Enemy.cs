using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cu�ntas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // M�todo que se llamar� cuando el enemigo reciba un impacto
        public void Hit()
        {
            // Reducir la cantidad de puntos de vida del enemigo
            hitPoints--;

            // Si el enemigo se queda sin puntos de vida, llamar al m�todo Die()
            if (hitPoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            animator.StopPlayback();

            // Desactivar el componente de colisi�n del enemigo (si es necesario)
            Collider enemyCollider = GetComponent<Collider>();
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
            }

            // Notificar que se ha agregado una puntuaci�n
            if (OnScoreAdded != null)
            {
                OnScoreAdded.Invoke(10);
            }
        }
    }

}