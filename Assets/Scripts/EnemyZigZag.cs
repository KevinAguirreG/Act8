using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : EnemySpaceship
{

    [SerializeField] private float zigzagWidth = 2f;  
    [SerializeField] private float zigzagSpeed = 2f;   
    private float startX;                             

    // Start is called before the first frame update
    new void Start()
    {
        base.Start(); 
        startX = transform.position.x; 
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed * Time.deltaTime;

        float newX = startX + Mathf.Sin(Time.time * zigzagSpeed) * zigzagWidth;
        rb.MovePosition(new Vector2(newX, rb.position.y - speed * Time.deltaTime));
    }

    
}
