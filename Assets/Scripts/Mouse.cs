using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    Camera cam;
    GameObject target;
    public LayerMask holesLayer;
    Color originColor;
    GameObject hitObject;
    GameObject boom;
    bool boomClicked = false;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        target = GameObject.Find("Barrel(Clone)");
    }


    private void Update()
    {
        Vector3 targetPosition = target.transform.position;

        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        transform.LookAt(targetPosition);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90); //검 z축 90도로 고정

        FireRay();
        PirateJump();
        SwordColor();
        
    }

    public void FireRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스위치로부터 Ray 만들기
        RaycastHit hitData;

        Physics.Raycast(ray, out hitData); // 레이캐스트 사용하여 충돌여부 확인
        //Vector3 hitPosition = hitData.point;

        if(Physics.Raycast(ray, 10, holesLayer))
        {
            hitData.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;  //충돌객체 색바꾸기 
            hitObject = hitData.transform.gameObject;

            UseSword();

        }
        else
        {
            if (hitObject != null)
            {
                hitObject.GetComponent<MeshRenderer>().material.color = Color.black;
                hitObject = null;
            }
        }

    }

    void UseSword()
    {
        if (this.enabled == false)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector3 stTarget = new Vector3(hitObject.transform.position.x, hitObject.transform.position.y, hitObject.transform.position.z);
            transform.position = stTarget;
            this.enabled = false;

            hitObject.gameObject.SetActive(false);

            Object sword = Resources.Load("Sword");
            Instantiate(sword);

            //boom = GameObject.FindWithTag("Boom");
            if(hitObject.CompareTag("Boom"))
            {
                boomClicked = true;
            }

        }

    }

    public void PirateJump()
    {
        GameObject pirate;
        pirate = GameObject.Find("Pirate(Clone)");

        if (boomClicked)
        {
            Debug.Log("Boom Clicked");

            float randomx = Random.Range(0, 10f);
            float randomz = Random.Range(0, 10f);

            pirate.GetComponent<Rigidbody>().AddForce(new Vector3(randomx, 15f, randomz), ForceMode.Impulse);
            //pirate.transform.position = new Vector3(pirate.transform.position.x+randomx, pirate.transform.position.y+0.1f, pirate.transform.position.z+radomz);
        }
    }

    public void SwordColor()
    {
        GameObject sword;
        sword = GameObject.Find("Sword(Clone)");
        sword.GetComponent<MeshRenderer>().material.color = Color.red;
        originColor = sword.GetComponent<MeshRenderer>().material.color;

        if (Input.GetMouseButton(0))
        {
            if (originColor == Color.red)
            {
                originColor = Color.yellow;
            }
            else if (originColor == Color.yellow)
            {
                originColor = Color.blue;
            }
            else if (originColor == Color.blue)
            {
                originColor = Color.green;
            }
        }
    }
}
