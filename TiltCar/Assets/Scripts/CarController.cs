using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//USED YOUTUBE TUTORIAL https://www.youtube.com/watch?v=E8lR59Yb2A0

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRb;
    [SerializeField] private Rigidbody2D backTireRb;
    [SerializeField] private Rigidbody2D carRb;
    [SerializeField] private float speed = 150f;
    [SerializeField] private float rotationSpeed = 300f;
    private float movInput; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        frontTireRb.AddTorque(-movInput * speed * Time.fixedDeltaTime);
        backTireRb.AddTorque(-movInput * speed * Time.fixedDeltaTime);
        carRb.AddTorque(movInput * rotationSpeed * Time.fixedDeltaTime);
    }
}
