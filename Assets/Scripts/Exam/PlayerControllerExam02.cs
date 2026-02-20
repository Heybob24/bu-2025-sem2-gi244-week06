using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam02 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    private float verticalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.right);
        
        if (shootAction.triggered)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
        
    }
}
