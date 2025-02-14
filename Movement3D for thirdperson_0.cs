using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5; //�̵��ӵ�
    [SerializeField]
    public float maxmoveSpeed = 5.0f; //�ִ� �̵��ӵ�
    [SerializeField]
    public float minmoveSpeed = 2.0f; //�ּ� �̵��ӵ�
    private Vector3 moveDirection;  // �̵�����

    private CharacterController characterController;

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Clamp(value, minmoveSpeed, maxmoveSpeed);
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //�̵�����, CharacterController�� Move() �Լ��� �̿��� �̵�
        characterController.Move(moveDirection*moveSpeed*Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }
}
