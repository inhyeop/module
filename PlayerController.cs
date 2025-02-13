using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

//����Ƽ ���� Ŭ���� ȣ��
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //����Ƽ�������� Ű�ڵ� �Լ��� ������ �������� ���� �� Ű�ڵ� �Ӽ��� Ȱ���Ͽ� �� �ݿ�
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    //ī�޶� ��Ʈ�ѷ� ������ ī�޶���Ʈ�ѷ� Ŭ�������� ī�޶� ��Ʈ�ѷ� ���� ����
    private CameraController cameraController;
    //Movement3D Ŭ������ ��� ��ũ��Ʈ ���� ȣ��
    private Movement3D movement3D;

    private void Awake()
    {
        //Movement3D Ŭ���� �Ӽ� ��� ����
        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //x����ŭ ����Ű ��/�� ������
        float z = Input.GetAxisRaw("Vertical");   //y����ŭ ����Ű ��/�Ʒ� ������

        //Movement3D Ŭ������ MpveTo �Ӽ��� ����3�� �����Ҵ��Ͽ� �ռ� ������Ʈ ���� �� �ݿ�(x,z)
        movement3D.MoveTo(new Vector3(x, 0, z));

        //�ش� Ű�� ���� ��� movement3D Ŭ������ JumpTo ����
        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.JumpTo();
        }

        float mouseX = Input.GetAxis("Mouse X"); //���콺 �¿� ������
        float mouseY = Input.GetAxis("Mouse Y");   //���콺 ���Ʒ� ������

        cameraController.RotateTo(mouseX, mouseY);
    }
}
