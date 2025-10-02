using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject hero;
    Vector3 offset;

    private float currentPitch;
    private float currentYaw;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("hero");

        transform.rotation = hero.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamByMouse();
        Raycast();
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
        Vector3 offset = rotation * new Vector3(0, 0, -5f);



        transform.position = hero.transform.position + offset;
        transform.LookAt(hero.transform);


        Debug.Log("Rotasi: " + transform.localEulerAngles);
    }

    private void Raycast()
    {
        float panjangRay = 300f;

        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * panjangRay, Color.red);

        if (Physics.Raycast(ray, out hit, panjangRay))
        {
            if (hit.transform.name == "tembok")
            {
                transform.Translate(Vector3.forward, Space.Self);
            }
            Debug.Log(hit.transform.name);
        }
    }
}
