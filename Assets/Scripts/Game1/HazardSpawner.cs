using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game1
{
    public class HazardSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay;
        [SerializeField] private GameObject hazardPrefab;
        [SerializeField] private float topRandomValue;
        [SerializeField] private float bottomRandomValue;


        private void Start()
        {
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while(true)
            {
                GameObject obj = Instantiate(hazardPrefab);
                obj.transform.position=transform.position;
                obj.transform.position += Vector3.up * Random.Range(bottomRandomValue, topRandomValue);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

}