using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]  //인스펙터창에서 조절 가능한 전역변수 선언 시 활용하며, 바로 하단 줄만 반영됨
    private float moveSpeed = 5.0f; //이동속도
    [SerializeField]
    private float jumpForce = 3.0f; //뛰는 힘
    private float gravity = -9.81f; //중력 계수
    private Vector3 moveDirection;  //이동방향

    [SerializeField]
    private Transform cameraTransfom; //유니티엔진 속성 트랜스폼을 통해 카메라 방향 트랜스폼 전역변수 선언


    //유니티 엔진 내부 클래스인 캐릭터콘트롤러를 가져와 캐릭터콘트롤러 변수 생성
    private  CharacterController characterController;

    //Awake 의미
    //게임을 시작하기 전에 변수 등을 초기화하기 위해 사용
    //스크립트가 실행될 때 가장 처음 1번 실행되는 함수
    //코루틴 사용이 불가능
    //private으로 해당 함수 내에서 한 번만 실행
    //GetComponent<속성을 가져올 클래스명>을 통해 해당 클래스의 속성을 가져옴
    //이때 매개변수가 없기에 ()로 표기
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    //Update 의미
    //게임 내 실시간으로 변경되는 데이터를 반영하여 함수 실행
    //스크립트가 실행될 때 가장 처음 1번 실행되는 함수
    //코루틴 사용이 불가능
    //private으로 해당 함수 내에서 한 번만 실행
    //앞서 가져온 클래스의 속성을 [.]으로 호출한 수 활용할 매개변수 입력
    //deltaTime = 1/10초 당 1개의 프레임으로 반영 (Frame Per Second 개념 참고)
    //deltaTime은 프레임 보정 개념이 들어있어 멀티의 경우 
    //각 플레이어가 다른 프레임을 가질 때 결과값을 보정하여 공평성 보장
    private void Update()
    {
        //if문을 사용해 중력값을 적용하여 땅에 닿아있지 않을 경우 y축에 중력계수*델타타임 값 반영
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    //MoveTo 함수 선언 후 ()에 방향으로 사용되는 매개변수를 가져옴(벡터3의 디렉션)
    //매개변수의 값을 앞서 정의했던 이동방향으로 넣음
    //앞의 함수에서 업데이트를 선언하였기에 해당 함수 아래 구간은 업데이트 시 자동 실행
    //전역변수를 실시간 업데이트함으로서 반영
    //public으로 설정하여 다른 스크립트 팡일에도 해당 속성 호출 가능
    public void MoveTo(Vector3 direction)
    {
        //moveDirection = direction;
        //카메라가 보는 방향으로 방향값 재공
        Vector3 movedis = cameraTransfom.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
        //y측은 공중에 떠있는지 체크하는 값이기에 매개변수에 moveDirection.y라는 값을 넣어 조작 불가능하도록 설정
    }

    //if문으로 체크해준 후 고정된 해당값을 활용하기에 함수 선언 시 매개변수는 void로 설정
    public void JumpTo()
    {
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
