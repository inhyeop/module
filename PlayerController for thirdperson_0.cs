using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    private Movement3D movement3D;

    private void Awake()
    {
        Cursor.visible = false;                     //���콺 Ŀ���� ������ �ʰ�
        Cursor.lockState = CursorLockMode.Locked;   //���콺 Ŀ�� ��ġ ����

        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        //����Ű�� ���� �̵�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //�̵��ӵ� ���� (������ �̵��Ҷ��� �ƽ����ǵ�, �������� �ּ� ���ǵ�)
        movement3D.MoveSpeed = z > 0 ? movement3D.maxmoveSpeed : movement3D.minmoveSpeed;
        //�̵� �Լ� ȣ��(ī�޶� �����ִ� ������ �������� ����Ű�� ���� �̵�)
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));
    }
}