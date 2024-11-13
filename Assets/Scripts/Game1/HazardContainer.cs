using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game1
{
    public class HazardContainer : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float destroyDelay;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            Destroy(gameObject, destroyDelay);
        }


        private void Update()
        {
            rb.velocity = Vector3.left * speed;
        }
    }

}