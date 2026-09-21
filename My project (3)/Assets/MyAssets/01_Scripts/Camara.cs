using UnityEngine;

public class Camara : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    //[SerializeField] Transform playerRotate;


    [SerializeField] float distance = 7;
    [SerializeField] float verticalOffset =2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
       Vector3 offset = new Vector3(0f, verticalOffset, distance);

        transform.position = playerTransform.position + offset;
        //transform.rotation = playerRotate.rotation;

    }
}
