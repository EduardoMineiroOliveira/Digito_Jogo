using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavusCam : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
