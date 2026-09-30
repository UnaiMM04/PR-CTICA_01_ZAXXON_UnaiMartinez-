using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject Enemigoo;
    [SerializeField] GameObject Enemigo02;
    [SerializeField] float interval;
    [SerializeField] float randomX;
    [SerializeField] float randomY;
    [SerializeField] float limitX = 30f;
    [SerializeField] float limitY = 30f;

    [SerializeField] int minEnemiesPerWave = 0;  // Cantidad mínima de enemigos por oleada
    [SerializeField] int maxEnemiesPerWave = 6;  // Cantidad máxima de enemigos por oleada
    [SerializeField] float minScale = 0.5f;       // Tamaño mínimo (ej. 50%)
    [SerializeField] float maxScale = 2.0f;       // Tamaño máximo (ej. 200%)


    //Enemigos intermedios
    [SerializeField] private float fristEnemyDistance;
    [SerializeField] float distanceEntreEnemigos;

    [SerializeField] PlayerManager playerManager;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
        EnemigoIntermedio();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {

            int enemyCount = Random.Range(minEnemiesPerWave, maxEnemiesPerWave + 1);

            for (int i = 0; i < enemyCount; i++)
            {

                SacarEnemigo02(0);
                SacarEnemigo01(0);
            }

            interval = distanceEntreEnemigos / playerManager.speed;

            yield return new WaitForSeconds(interval);



        }
    }


    
    void SacarEnemigo01(float distZ)
    {
        // Lógica para sacar la nave
        randomX = Random.Range(-limitX, limitY);
        randomY = Random.Range(-limitY, limitY);
        Vector3 despl = new Vector3(randomX, randomY, distZ);
        Vector3 instPost = transform.position - despl;
        //Instantiate(Enemigoo, instPost, Quaternion.identity);

        // Instanciar el enemigo
        GameObject newEnemy = Instantiate(Enemigoo, instPost, Quaternion.identity);
        

        // Aplicar tamaño (escala) aleatorio uniforme
        float randomScale = Random.Range(minScale, maxScale);
        newEnemy.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

    void SacarEnemigo02(float distZ)
    {
        // Lógica para sacar la nave
        randomX = Random.Range(-limitX, limitY);
        randomY = Random.Range(-limitY, limitY);
        Vector3 despl = new Vector3(randomX, randomY, distZ);
        Vector3 instPost = transform.position - despl;
        //Instantiate(Enemigoo, instPost, Quaternion.identity);

        // Instanciar el enemigo
        GameObject newEnemy02 = Instantiate(Enemigo02, instPost, Quaternion.identity);


        // Aplicar tamaño (escala) aleatorio uniforme
        float randomScale = Random.Range(minScale, maxScale);
        newEnemy02.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }
    void EnemigoIntermedio()
    {
        float fristEnemy = transform.position.z - fristEnemyDistance;
        float n = fristEnemy / distanceEntreEnemigos;
        int ciclos = Mathf.FloorToInt(n);
        print("Ciclos: " + ciclos);

        for (int i = 0; i < ciclos; i++)
        {
            SacarEnemigo02(fristEnemy);
            
            fristEnemy -= distanceEntreEnemigos;
        }

        
    }


}
