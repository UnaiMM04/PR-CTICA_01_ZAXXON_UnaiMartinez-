using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject Enemigoo;
    [SerializeField] float interval = 0.5f;
    [SerializeField] float randomX;
    [SerializeField] float randomY;


    [SerializeField] int minEnemiesPerWave = 1;  // Cantidad mínima de enemigos por oleada
    [SerializeField] int maxEnemiesPerWave = 5;  // Cantidad máxima de enemigos por oleada
    [SerializeField] float minScale = 0.5f;       // Tamaño mínimo (ej. 50%)
    [SerializeField] float maxScale = 2.0f;       // Tamaño máximo (ej. 200%)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      StartCoroutine(SpawnEnemy());
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

                randomX = Random.Range(-20f, 20f);
                randomY = Random.Range(-20f, 20f);
                Vector3 despl = new Vector3(randomX, randomY, 0);
                Vector3 instPost = transform.position + despl;
              //Instantiate(Enemigoo, instPost, Quaternion.identity);

                // Instanciar el enemigo
                GameObject newEnemy = Instantiate(Enemigoo, instPost, Quaternion.identity);

                // 3. Aplicar tamaño (escala) aleatorio uniforme
                float randomScale = Random.Range(minScale, maxScale);
                newEnemy.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            }

            yield return new WaitForSeconds(interval);

           
            //yield return new WaitForSeconds(interval);
        }
    }

    
}
