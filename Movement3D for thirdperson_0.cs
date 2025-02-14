using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5; //이동속도
    [SerializeField]
    public float maxmoveSpeed = 5.0f; //최대 이동속도
    [SerializeField]
    public float minmoveSpeed = 2.0f; //최소 이동속도
    private Vector3 moveDirection;  // 이동방향

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
        //이동설정, CharacterController의 Move() 함수를 이용한 이동
        characterController.Move(moveDirection*moveSpeed*Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }
}
