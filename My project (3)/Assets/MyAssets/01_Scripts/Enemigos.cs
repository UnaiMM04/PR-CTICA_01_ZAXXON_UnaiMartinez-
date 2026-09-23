using UnityEngine;

public class Enemigos : MonoBehaviour
{
    float speed;
    [SerializeField] PlayerManager playerManager;
    void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * - speed * Time.deltaTime);
        speed = playerManager.speed;
    }
}
