using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    Vector2 moveXY;

    float rotation;
    [SerializeField] float rotationSpeed = 2;

    float maxRotationZ = 35f;
    float maxRotationX = 15f;
    


    //ROTACION SUAVIZADA
    [SerializeField] float smoothRotation = 0.05f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;


    

    ImputActions imputActions;
    

    private void Awake()
    {
        imputActions = new ImputActions();

        //MOVIMIENTO
        imputActions.Player.Move.performed += ctx => moveXY = ctx.ReadValue<Vector2>();
        imputActions.Player.Move.canceled += _ => moveXY = Vector2.zero;

        //DISPARO
        imputActions.Player.Fire.started += _ => Fire();


        speed = 100f;


    }

    private void Start()
    {
        
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
        transform.Translate(Vector3.right * moveXY.x * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * moveXY.y * speed * Time.deltaTime, Space.World);
        
    }
    void RotatePlayer() 
    {
        
        //ROTACION LOCA
        //transform.Rotate(Vector3.forward * rotation * - rotationSpeed * Time.deltaTime * -360, Space.World);

        //transform.eulerAngles = Vector3.forward * -maxRotationZ * moveXY.x;


        //ROTACION SUAVIZADA
        Vector3 vectorRotZ = Vector3.forward * -maxRotationZ * moveXY.x;
        Vector3 vectorRotX = Vector3.right * -maxRotationX * moveXY.y;
        Vector3 vectorRot = vectorRotZ + vectorRotX;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothRotation);
        transform.eulerAngles = currentRot;
    }

    void Fire()
    {
        print("POOM");
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
