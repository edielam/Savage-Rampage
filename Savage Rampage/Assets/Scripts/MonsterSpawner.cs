 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterRef;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex, randomSide;
    

    // Start is called before the first frame update
   
    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterRef.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterRef[randomIndex]);

            //left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(2, 5);
                spawnedMonster.GetComponent<Monster>().sr.flipX = false;
                //spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); //for flipping on x-axis
                //this command seems to affect the size of the spaawned object
            }
            //right side
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(2, 5);
                spawnedMonster.GetComponent<Monster>().sr.flipX = true;
            }
        }
    }
}
