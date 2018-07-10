using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    private float timeBtwAttack = -1;

    [SerializeField] private string target;
    [SerializeField] private float startTimeBtwAttack;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject boom;

    private void Update()
    {
        if (timeBtwAttack <= 0)
        {

            //Behaviour for player 
            if (target == "enemy")
            {
                if(Input.GetMouseButton(0))
                {
                    
                    anim.SetBool("Crouch", true);
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].gameObject.GetComponent<EnemyController>().Hp -= damage;
                        Instantiate(boom, enemiesToDamage[i].gameObject.transform.position, Quaternion.identity);
                    }
                }
                else
                    anim.SetBool("Crouch", false);
            }
            //Behaviour for enemies
            else if (target == "Player")
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    
                        enemiesToDamage[i].gameObject.GetComponent<PlayerController>().Hp -= damage;
                        Instantiate(boom, enemiesToDamage[i].gameObject.transform.position, Quaternion.identity);
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            //anim.SetBool("Crouch", false);
            timeBtwAttack -= Time.fixedDeltaTime;
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
