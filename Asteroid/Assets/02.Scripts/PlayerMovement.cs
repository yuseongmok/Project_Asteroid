using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public Camera mainCamera; // ī�޶�
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �÷��̾� �̵� �Է� ó��
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �÷��̾� �̵� ó��
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = moveDirection * moveSpeed;

        // ī�޶� �̵� ó��
        Vector3 cameraPosition = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition, Time.deltaTime * 5f);
    }
}
