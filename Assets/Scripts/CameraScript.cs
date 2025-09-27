using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject hero;

    private float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("hero");

        transform.rotation = hero.transform.rotation;

        Vector3 posCam = hero.transform.localPosition;
        posCam -= transform.forward * 5f;
        posCam += transform.up * 3f;
        transform.position = posCam;

        transform.LookAt(hero.transform);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamByMouse();
    }

    private void MoveCamByMouse()
    {
        transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * 4f);
        transform.RotateAround(hero.transform.position, Vector3.left, Input.GetAxis("Mouse Y") * 4f);
        transform.LookAt(hero.transform);
        Debug.Log("Rotasi: " + transform.localEulerAngles);
    }

    private void MoveCamByKeyboard()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 50;
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            speed = -50;
        }
        transform.LookAt(hero.transform);
        transform.RotateAround(hero.transform.position, Vector3.up, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (Vector3.Distance(transform.position, hero.transform.position) > 1f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
            }
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (Vector3.Distance(transform.position, hero.transform.position) < 5f)
            {
                transform.Translate(Vector3.back * Time.deltaTime, Space.Self);
            }
        }
    }
}
