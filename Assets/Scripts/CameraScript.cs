using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject hero;

    private float speed = 0f;
    private float currentPitch;
    private float currentYaw;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("hero");
        currentPitch = 0f;
        currentYaw = 0f;

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
        // identifikasi input mouse
        float rotationY = Input.GetAxis("Mouse Y");
        float rotationX = Input.GetAxis("Mouse X");
        currentPitch -= rotationY * 4f;
        currentYaw += rotationX * 4f;

        currentPitch = Mathf.Clamp(currentPitch, 0f, 70f);

        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 offset = rotation * new Vector3(0, 0, -2f);



        transform.position = hero.transform.position + offset;
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
