using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("hero");

        transform.rotation = hero.transform.rotation;

        Vector3 posCam = hero.transform.localPosition;
        posCam -= transform.forward * 5f;
        transform.position = posCam;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(hero.transform);
    }
}
