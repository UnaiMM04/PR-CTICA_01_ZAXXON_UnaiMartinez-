using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    bool isAlive;
    public float speed;
    Vector2 moveXY;
    

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


    }
    private void Update()
    {
        {
            transform.Translate(Vector2.right * desplSpeedx * Time.deltaTime);
            transform.Translate(Vector2.up * desplSpeedy * Time.deltaTime);
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
