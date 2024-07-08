using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BallFire());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BallFire()
    {
        while (true)
        {
            Instantiate(Ball, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void LateUpdate()
    {
        this.transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
