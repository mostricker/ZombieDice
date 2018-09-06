using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBehavior : MonoBehaviour {

    public float speed = 1.0f;

    // Use this for initialization
    void Start () {
        Debug.Log("I am alive!");
    }

    // Update is called once per frame
    void Update () {
        float horizontalDistance = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalDistance);

        float verticalDistance = speed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * verticalDistance);
    }
}
