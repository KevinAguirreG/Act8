using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    public float min_X, max_X;

   [ SerializeField ]
    private GameObject bullet;

    [SerializeField]
    private Transform attackPoint;

    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        currentAttackTimer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
        //Derecha
        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;  
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_X)
            {
                temp.x = max_X;
            }

            transform.position = temp;

        }
        //Izquierda
        else if (Input.GetAxisRaw("Horizontal") < 0f){
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < min_X)
            {
                temp.x = min_X;
            }


            transform.position = temp;
        }
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if(attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {

            if (canAttack)
            {

                canAttack = false;
                attackTimer = 0f;

                Instantiate(bullet, attackPoint.position, Quaternion.identity);
            }
        }
    }


}
