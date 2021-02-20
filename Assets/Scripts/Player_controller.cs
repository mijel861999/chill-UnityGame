using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;

    public Transform arms;

    Vector3 viewPortActual, viewPortDelta, directionToMouse;

    public float speed = 2.0f;
    public float force = 3.0f;

    private const string horizontal = "Horizontal";

    private const string WALKING = "Walking";

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidbody.velocity = new Vector2(Input.GetAxis(horizontal) * speed, playerRigidbody.velocity.y);
        ComprobarCaminado();

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //arms.rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - arms.position);
        arms.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));


        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }


    void ComprobarCaminado() {
        if (Input.GetAxis(horizontal) > 0) {
            playerAnimator.SetBool(WALKING, true);
            playerRenderer.flipX = false;
        } else if (Input.GetAxis(horizontal) < 0) {
            playerAnimator.SetBool(WALKING, true);
            playerRenderer.flipX = true;
        } else if (Input.GetAxis(horizontal) == 0) {
            playerAnimator.SetBool(WALKING, false);
        }
    }

    void Jump() {
        playerRigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
