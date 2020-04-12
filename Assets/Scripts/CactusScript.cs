using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;

    public Animator myAnimator;

    public bool gotJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && (gotJump == true))
        {
            myAnimator.Play("JumpAnim");
            rb.AddForce(new Vector2(0, jumpForce));
            gotJump = false;
        }

        if(Cactus_GameManager.Instance.isAlive == false)
        {
            myAnimator.Play("DeathAnim");
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            myAnimator.Play("RunAnim");
            gotJump = true;
        }
    }
}