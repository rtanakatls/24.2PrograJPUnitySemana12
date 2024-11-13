using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game1
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float verticalForce;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameController.Instance.GameOver();
        }

        private void OnTriggerExit(Collider collision)
        {
            GameController.Instance.UpdateScore(1);
        }

    }

}