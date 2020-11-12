using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    public float speed;
    bool death = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death == false)
        {
            if (playerAnim.GetBool("isAttack") == false)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    playerAnim.SetBool("isStrafe", true);
                }
                else if (Input.GetKeyUp(KeyCode.W))
                {
                    playerAnim.SetBool("isStrafe", false);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector3.back * Time.deltaTime * -speed);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    playerAnim.SetBool("isStrafe", true);
                }
                else if(Input.GetKeyUp(KeyCode.S))
                {
                    playerAnim.SetBool("isStrafe", false);
                }
                if(Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    playerAnim.SetBool("isStrafe", true);
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    playerAnim.SetBool("isStrafe", false);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    playerAnim.SetBool("isStrafe", true);
                }
                else if (Input.GetKeyUp(KeyCode.D))
                {
                    playerAnim.SetBool("isStrafe", false);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.SetBool("isAttack", true);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                playerAnim.SetBool("isAttack", false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            playerAnim.SetTrigger("isDeath");
            death = true;
            playerAnim.SetBool("isStrafe", false);
            playerAnim.SetBool("isAttack", false);
        }
    }
}
