using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static bool PlayerMoving = true;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
         
    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerMoving){
        CalculateRotation();
        CalculatePositon();
      } 
    }

    private void CalculateRotation()
    {
        float playerRotationSpeed =  player.GetComponent<Player>().rotationSpeed;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float rotationValue = horizontalInput * playerRotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationValue, 0);
    }

    private void CalculatePositon()
    {
        float playerWalkSpeed =  player.GetComponent<Player>().walkSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movementDirection = transform.forward * verticalInput;
        Vector3 positionChange = movementDirection * playerWalkSpeed * Time.deltaTime;
        this.transform.position += positionChange;
    }
}
