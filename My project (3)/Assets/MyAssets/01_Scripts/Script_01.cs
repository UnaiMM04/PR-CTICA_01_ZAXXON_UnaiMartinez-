using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    public float enemySpeed;
    Vector2 moveXY;

    float rotation;
    [SerializeField] float rotationSpeed = 2;

    float maxRotationZ = 15f;
    float maxRotationX = 15f;
    


    //ROTACION SUAVIZADA
    [SerializeField] float smoothRotation = 0.05f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;

    //LIMITES DE MOVIMIENTO
    [SerializeField] float minX = -20f;
    [SerializeField] float maxX = 20f;
    [SerializeField] float minY = -20f;
    [SerializeField] float maxY = 20f;




    ImputActions imputActions;
    

    private void Awake()
    {
        imputActions = new ImputActions();

        //MOVIMIENTO
        imputActions.Player.Move.performed += ctx => moveXY = ctx.ReadValue<Vector2>();
        imputActions.Player.Move.canceled += _ => moveXY = Vector2.zero;

        //DISPARO
        imputActions.Player.Fire.started += _ => Fire();


        speed = 50f;
        enemySpeed = 100f;


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
        //transform.Translate(Vector3.right * moveXY.x * speed * Time.deltaTime, Space.World);
        //transform.Translate(Vector3.up * moveXY.y * speed * Time.deltaTime, Space.World);

        // 1. Calculamos el desplazamiento deseado este frame
        Vector3 displacement = new Vector3(moveXY.x, moveXY.y, 0f) * speed * Time.deltaTime;

        // 2. Aplicamos la nueva posición
        Vector3 newPosition = transform.position + displacement;

        // 3. Restringimos (Clamp) la posición dentro de los rangos min/max
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // 4. Asignamos la posición final delimitada
        transform.position = newPosition;

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
