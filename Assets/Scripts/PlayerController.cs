using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer sr; 

    [SerializeField] private float speed; 
    public Vector3 Inputs { get; private set; }

    public bool IsAttacking { get; private set; }

    private void Start() 
    {
        sr = GetComponent<SpriteRenderer>(); 
    }

    private void Update() 
    {
        MoveX();  
        Flip(); 
        CheckAttack(); 
    }

    private void MoveX()
    {
        Inputs = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f); 

        transform.Translate(Inputs * speed * Time.deltaTime); 
    }

    private void Flip()
    {
        if(Inputs.x == 0) return; 

        sr.flipX = Inputs.x > 0 ? false : true;
    }

    private void CheckAttack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsAttacking = true; 
        }
    }

    public void OnEndAttack() => IsAttacking = false; 
}