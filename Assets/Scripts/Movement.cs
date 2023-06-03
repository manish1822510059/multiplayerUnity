using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float walkSpeed = 4f;
    public float rotationSpeed = 4f;
    public float maxVelocityChange = 10f;

    private Vector2 input;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateRotation();
        CalculatePositon();
    }

    private void CalculateRotation()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        float rotationValue = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationValue, 0);
    }

    private void CalculatePositon()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        Vector3 movementDirection = transform.forward * verticalInput;
        Vector3 positionChange = movementDirection * walkSpeed * Time.deltaTime;
        this.transform.position += positionChange;
    }
}
