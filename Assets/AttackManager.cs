using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    //private Animator s_Anim;
    [SerializeField]
    private string target;
    [SerializeField]
    private int dmg = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("sword") && collision.gameObject.CompareTag(target))
        {
            Debug.Log(target + "  " + collision.gameObject.tag);
            if(target == "enemy")
            {
                EnemyController tmp = collision.gameObject.GetComponent<EnemyController>();
                if (tmp != null)
                    tmp.Hp -= dmg;
            }
            else if(target == "Player")
            {
                collision.gameObject.GetComponent<PlayerController>().Hp -= dmg;
            }
        }
    }

}
