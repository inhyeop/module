using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    private Movement3D movement3D;

    private void Awake()
    {
        Cursor.visible = false;                     //마우스 커서를 보이지 않게
        Cursor.lockState = CursorLockMode.Locked;   //마우스 커서 위치 고정

        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        //방향키를 눌러 이동
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //이동속도 설정 (앞으로 이동할때만 맥스스피드, 나머지는 최소 스피드)
        movement3D.MoveSpeed = z > 0 ? movement3D.maxmoveSpeed : movement3D.minmoveSpeed;
        //이동 함수 호출(카메라가 보고있는 방향을 기준으로 방향키에 따라 이동)
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));
    }
}