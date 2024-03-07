using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//USED YOUTUBE TUTORIAL https://www.youtube.com/watch?v=E8lR59Yb2A0

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRb;
    [SerializeField] private Rigidbody2D backTireRb;
    [SerializeField] private Rigidbody2D carRb;
    [SerializeField] private float speed = 250f;
    [SerializeField] private float rotationSpeed = 300f;
    private float movInput;

    [SerializeField] private float balanceForce = 50f; // Fuerza para balancear el carro
    private float balanceInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movInput = Input.GetAxisRaw("Horizontal");
        balanceInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
  
        
        if (!IsCarFlipped())
        {
            frontTireRb.AddTorque(-movInput * speed * Time.fixedDeltaTime);
            backTireRb.AddTorque(-movInput * speed * Time.fixedDeltaTime);
            carRb.AddTorque(movInput * rotationSpeed * Time.fixedDeltaTime);
            carRb.AddForce(Vector2.right * balanceInput * balanceForce * Time.fixedDeltaTime);
        }
        else
        {
            // Detener el movimiento del carro
            frontTireRb.velocity = Vector2.zero;
            backTireRb.velocity = Vector2.zero;
            carRb.velocity = Vector2.zero;
        }
        if (IsCarFlipped())
        {
            EndGame();
        }
    }
    private bool IsCarFlipped()
    {
        float angle = Mathf.Abs(transform.eulerAngles.z);
        return angle > 90f && angle < 270f;
    }

    private void EndGame()
    {
        Debug.Log("Game Over - Car Flipped!");
        GameMngr.Instance.RestartGame();
    }
}
