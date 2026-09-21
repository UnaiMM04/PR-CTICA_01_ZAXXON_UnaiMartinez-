using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    bool isAlive;
    public float speed;
    Vector2 moveXY;
    float rotation;
    [SerializeField] float rotationSpeed;

    [SerializeField] float desplSpeedx;
    [SerializeField] float desplSpeedy;

    

    ImputActions imputActions;
    

    private void Awake()
    {
        imputActions = new ImputActions();
        imputActions.Player.Move.performed += ctx => desplSpeedx = speed * ctx.ReadValue<Vector2>().x;
        imputActions.Player.Move.performed += ctx => desplSpeedy = speed * ctx.ReadValue<Vector2>().y;
        imputActions.Player.Move.canceled += _ => desplSpeedx = speed * 0;
        imputActions.Player.Move.canceled += _ => desplSpeedy = speed * 0;

        imputActions.Player.Rotate.performed += ctx => rotation = ctx.ReadValue<float>();
        imputActions.Player.Rotate.canceled += _ => rotation = 0;



    }
    private void Update()
    {
        {
            transform.Translate(Vector3.right * desplSpeedx * Time.deltaTime);
            transform.Translate(Vector3.up * desplSpeedy * Time.deltaTime);
            transform.Rotate(Vector3.forward * rotation * rotationSpeed * Time.deltaTime * -360);
        }
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
