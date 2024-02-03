using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Vector2 throwForce;

    public bool isActive = true;

    public Rigidbody2D rb;
    public BoxCollider2D knifeCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = rb.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && isActive)
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;

            GameController.instance.GameUI.DecrementDisplayKnifeCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
        {
            return;
        }

        isActive = false;

        if(collision.collider.tag=="Lag")
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType=RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);

            GameController.instance.OnSucessFukKnifeHit();
        }

        else if(collision.collider.tag=="Knife")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            GameController.instance.StartGameOverSequence(false);
        }
    }

}
