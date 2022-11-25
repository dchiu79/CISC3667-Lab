using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed = 5;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool isAtBorder = false;
    // Start is called before the first frame update
    void Start() 
    {
        if(rigid==null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
    }

    void FixedUpdate() 
    {
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder.x, rightBorder.x), transform.position.y, 0);
        if(transform.position.x<=leftBorder.x || transform.position.x>=rightBorder.x)
            isAtBorder = true;
        if(isAtBorder && isFacingRight || isAtBorder && !isFacingRight)
            Flip();
    }

    void Flip() 
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
        speed *= -1;
        isAtBorder = false;
    }
}