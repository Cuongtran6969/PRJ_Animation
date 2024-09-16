using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //(neu su dung public thi co the keo doi tuong vao va khong can khoi tao)
    //(neu su dung pprivate ko co slot keo tha, va mk can khoi tao no khi start)
    public Rigidbody2D rb;
    public int speed = 4;
    public float direction;
    public bool isFacingRight = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");//left=-1, right=1, no=0 (lay gia tri khi di chuyen theo truc ngang)
        rb.velocity = new Vector2(speed*direction, rb.velocity.y);
        if(isFacingRight == true && direction == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }
        if (isFacingRight == false && direction == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }
        animator.SetFloat("run", Mathf.Abs(direction));
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }
}
