using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anm; 
    private PlayerController controller; 
    
    private string currentState; // Estado atual da animação 

    private const string PLAYER_ATTACK = "player_attack"; 
    private const string PLAYER_IDLE = "player_idle"; 
    private const string PLAYER_RUN = "player_run"; 

    private void Start() 
    {
        anm = GetComponent<Animator>(); 
        controller = GetComponent<PlayerController>(); 
    }

    private void Update() 
    {
        ChenckAnimationState(); 
    }

    private void ChenckAnimationState()
    {
        if(controller.IsAttacking)
        {
            ChangeAnimationState(PLAYER_ATTACK); 
        }
        else if(controller.Inputs.x != 0)
        {
            ChangeAnimationState(PLAYER_RUN);
        }
        else
        {
            ChangeAnimationState(PLAYER_IDLE); 
        }
    }
    
    // Método que tenta mudar o estado de animação atual 
    private void ChangeAnimationState(string nextState)
    {
        if(currentState == nextState) return; 

        anm.Play(nextState); 
        currentState = nextState; 
    }
}
