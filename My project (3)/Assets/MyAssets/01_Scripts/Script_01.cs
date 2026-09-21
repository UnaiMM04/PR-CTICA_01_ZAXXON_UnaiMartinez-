using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    bool isAlive;
    public float speed;
    Vector2 moveXY;

    float rotation;
    float maxRotation = - 45f;
    [SerializeField] float rotationSpeed = 2;


    //ROTACION SUAVIZADA
    Vector3 origin;
    Vector3 destiny;
    Vector3 velocity;
    [SerializeField] float smoothRotation = 0.5f;

    [SerializeField] float desplSpeedx;
    [SerializeField] float desplSpeedy;

    

    ImputActions imputActions;
    

    private void Awake()
    {
        imputActions = new ImputActions();
        imputActions.Player.Move.performed += ctx => desplSpeedx = -speed * ctx.ReadValue<Vector2>().x;
        imputActions.Player.Move.performed += ctx => desplSpeedy = speed * ctx.ReadValue<Vector2>().y;
        imputActions.Player.Move.canceled += _ => desplSpeedx = - speed * 0;
        imputActions.Player.Move.canceled += _ => desplSpeedy = speed * 0;

        imputActions.Player.Rotate.performed += ctx => rotation = ctx.ReadValue<float>();
        imputActions.Player.Rotate.canceled += _ => rotation = 0;



    }
    private void Update()
    {
        {

            MovePlayer();
            RotatePlayer();

        }
    }

    void MovePlayer()
    {
        transform.Translate(Vector3.right * desplSpeedx * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * desplSpeedy * Time.deltaTime, Space.World);
        
    }
    void RotatePlayer() 
    {
        //transform.Rotate(Vector3.forward * rotation * - rotationSpeed * Time.deltaTime * -360, Space.World);
        //transform.eulerAngles = Vector3.forward * maxRotation * moveXY;

        //origin = transform.rotation.eulerAngles;
        //destiny = Vector3.forward * moveXY * - maxRotation;
        //transform.eulerAngles = Vector3.SmoothDamp(origin, destiny, ref velocity, smoothRotation);

        Vector3 vectorRotZ = Vector3.forward * maxRotationZ * moveXY.x;
        Vector3 vectorRotX = Vector3.right * maxRotationX * moveXY.y;
        Vector3 vectorRot = vectorRotZ + vectorRotX;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothRotation);
        transform.eulerAngles = currentRot;
    }

    private void OnEnable()
    {
        imputActions.Enable();
    }

    private void OnDisable()
    {
        imputActions.Disable();
    }
}
