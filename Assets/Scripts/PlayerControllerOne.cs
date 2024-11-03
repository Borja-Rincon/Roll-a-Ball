using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerControllerOne : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text endGameText;

    public float speed = 10f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private int count = 0;

    private float movementX;
    private float movementY;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        endGameText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue jumpValue)
    {
        if (isGrounded && jumpValue.isPressed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Void"))
        {
            LoseGame();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void LoseGame()
    {
        endGameText.text = "GAME OVER";
        endGameText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void SetCountText()
    {
        countText.text = "Pumpkins: " + count.ToString();
        if (count >= 12)
        {
            StartCoroutine(WinGame());
        }
    }

    private IEnumerator WinGame()
    {
        endGameText.text = "WINNER";
        endGameText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SceneTwo");
    }
}
