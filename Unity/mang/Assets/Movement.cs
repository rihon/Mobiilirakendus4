using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    float MoveSpeed;
    Vector3 jump;
    float jumpForce = 2.0f;
    bool isGrounded;
    Rigidbody rb;
    float resX = 25;
    float resY = 1;
    float resZ = 15;

    void Start()
    {
        MoveSpeed = 3f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        transform.position = new Vector3(25f, 2,10.0f);
    }



    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.y > (Screen.height / 2))
            {
                transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + 0.1f);
            }
            if (touch.position.y < (Screen.height / 2))
            {
                transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.z - 0.1f);
            }
            


        }
        transform.Translate(MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    } 


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(this.gameObject, new Vector3(resX, resY, resZ), Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Checkpoint")
        {
            resX = 25;
            resZ = 68;
            col.gameObject.transform.position = new Vector3(21.5f, 2, 67.2f);
        }

    }
}