using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public Rigidbody car;
    public float playerSpeed;
    public float jumpPower;
    public int directionInput;
    public bool groundCheck;
    public bool facingRight = true;
//
    void Start()
    {
        //ищем элемент на сцене с компонентом Rigidbody
        car = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if ((directionInput < 0) && (facingRight))
        {
            Flip();
        }

        if ((directionInput > 0) && (!facingRight))
        {
            Flip();
        }
        groundCheck = true;
    }

    
    //начало обработки событий нажатия на кнопки
    void FixedUpdate()
    {
        car.velocity = new Vector3(playerSpeed * directionInput, car.velocity.y, car.velocity.z);
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;
    }

    public void Jump(bool isJump)
    {
        isJump = groundCheck;

        if (groundCheck)
        {
            car.velocity = new Vector3(car.velocity.x, jumpPower, 100);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //конец обработки событий нажатия на кнопки
}