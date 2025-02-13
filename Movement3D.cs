using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]  //�ν�����â���� ���� ������ �������� ���� �� Ȱ���ϸ�, �ٷ� �ϴ� �ٸ� �ݿ���
    private float moveSpeed = 5.0f; //�̵��ӵ�
    [SerializeField]
    private float jumpForce = 3.0f; //�ٴ� ��
    private float gravity = -9.81f; //�߷� ���
    private Vector3 moveDirection;  //�̵�����

    [SerializeField]
    private Transform cameraTransfom; //����Ƽ���� �Ӽ� Ʈ�������� ���� ī�޶� ���� Ʈ������ �������� ����


    //����Ƽ ���� ���� Ŭ������ ĳ������Ʈ�ѷ��� ������ ĳ������Ʈ�ѷ� ���� ����
    private  CharacterController characterController;

    //Awake �ǹ�
    //������ �����ϱ� ���� ���� ���� �ʱ�ȭ�ϱ� ���� ���
    //��ũ��Ʈ�� ����� �� ���� ó�� 1�� ����Ǵ� �Լ�
    //�ڷ�ƾ ����� �Ұ���
    //private���� �ش� �Լ� ������ �� ���� ����
    //GetComponent<�Ӽ��� ������ Ŭ������>�� ���� �ش� Ŭ������ �Ӽ��� ������
    //�̶� �Ű������� ���⿡ ()�� ǥ��
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    //Update �ǹ�
    //���� �� �ǽð����� ����Ǵ� �����͸� �ݿ��Ͽ� �Լ� ����
    //��ũ��Ʈ�� ����� �� ���� ó�� 1�� ����Ǵ� �Լ�
    //�ڷ�ƾ ����� �Ұ���
    //private���� �ش� �Լ� ������ �� ���� ����
    //�ռ� ������ Ŭ������ �Ӽ��� [.]���� ȣ���� �� Ȱ���� �Ű����� �Է�
    //deltaTime = 1/10�� �� 1���� ���������� �ݿ� (Frame Per Second ���� ����)
    //deltaTime�� ������ ���� ������ ����־� ��Ƽ�� ��� 
    //�� �÷��̾ �ٸ� �������� ���� �� ������� �����Ͽ� ���� ����
    private void Update()
    {
        //if���� ����� �߷°��� �����Ͽ� ���� ������� ���� ��� y�࿡ �߷°��*��ŸŸ�� �� �ݿ�
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    //MoveTo �Լ� ���� �� ()�� �������� ���Ǵ� �Ű������� ������(����3�� �𷺼�)
    //�Ű������� ���� �ռ� �����ߴ� �̵��������� ����
    //���� �Լ����� ������Ʈ�� �����Ͽ��⿡ �ش� �Լ� �Ʒ� ������ ������Ʈ �� �ڵ� ����
    //���������� �ǽð� ������Ʈ�����μ� �ݿ�
    //public���� �����Ͽ� �ٸ� ��ũ��Ʈ ���Ͽ��� �ش� �Ӽ� ȣ�� ����
    public void MoveTo(Vector3 direction)
    {
        //moveDirection = direction;
        //ī�޶� ���� �������� ���Ⱚ ���
        Vector3 movedis = cameraTransfom.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
        //y���� ���߿� ���ִ��� üũ�ϴ� ���̱⿡ �Ű������� moveDirection.y��� ���� �־� ���� �Ұ����ϵ��� ����
    }

    //if������ üũ���� �� ������ �ش簪�� Ȱ���ϱ⿡ �Լ� ���� �� �Ű������� void�� ����
    public void JumpTo()
    {
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
