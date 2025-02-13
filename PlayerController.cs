using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

//유니티 내부 클래스 호출
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //유니티엔진에서 키코드 함수를 가져와 전역변수 정의 후 키코드 속성을 활용하여 값 반영
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    //카메라 컨트롤러 파일의 카메라컨트롤러 클래스에서 카메라 컨트롤러 변수 지정
    private CameraController cameraController;
    //Movement3D 클래스가 담긴 스크립트 파일 호출
    private Movement3D movement3D;

    private void Awake()
    {
        //Movement3D 클래스 속성 사용 세팅
        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //x값만큼 방향키 좌/우 움직임
        float z = Input.GetAxisRaw("Vertical");   //y값만큼 방향키 위/아래 움직임

        //Movement3D 클래스의 MpveTo 속성에 벡터3를 동적할당하여 앞서 업데이트 중인 값 반영(x,z)
        movement3D.MoveTo(new Vector3(x, 0, z));

        //해당 키를 누를 경우 movement3D 클래스의 JumpTo 실행
        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.JumpTo();
        }

        float mouseX = Input.GetAxis("Mouse X"); //마우스 좌우 움직임
        float mouseY = Input.GetAxis("Mouse Y");   //마우스 위아래 움직임

        cameraController.RotateTo(mouseX, mouseY);
    }
}
