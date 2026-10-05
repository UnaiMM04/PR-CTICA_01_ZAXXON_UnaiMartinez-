using UnityEngine;

public class Enemigos : MonoBehaviour
{
    float speed;
    [SerializeField] PlayerManager playerManager;




    void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {

            playerManager = player.GetComponent<PlayerManager>();
        }
        else         {
            Debug.LogError("PlayerManager not found on the player object.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.enemySpeed;
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        DestuccionEnemigo();
    }

    void DestuccionEnemigo()
    {
        if (transform.position.z < playerManager.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
    