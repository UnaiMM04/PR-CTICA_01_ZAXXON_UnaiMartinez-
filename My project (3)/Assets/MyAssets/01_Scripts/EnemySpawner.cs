using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject Enemigoo;
    [SerializeField] float interval = 0.5f;
    [SerializeField] float randomX;
    [SerializeField] float randomY;

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

            randomX = Random.Range(-10f, 10f);
            randomY = Random.Range(-10f, 10f);
            Vector3 despl = new Vector3(randomX, randomY, 0);
            Vector3 instPost = transform.position + despl;
            Instantiate( Enemigoo, instPost, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
