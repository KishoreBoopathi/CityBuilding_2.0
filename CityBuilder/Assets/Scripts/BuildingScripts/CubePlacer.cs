using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameObject Prefab;
    public BuildingsData data;
    public GameObject pgo = null;
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }
    private void Update()
    {
        if (data)
        {
            if (pgo == null)
            {
                pgo = Instantiate(data.Model);
                pgo.layer = 2;
            }
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "Resource" || hitInfo.collider.tag == "Building")
                {

                    pgo.transform.position = hitInfo.point;
                    pgo.GetComponent<Building>().ChangeTexError();

                    //pgo.transform.Find("Body").GetComponent<Renderer>().material.color = Color.red;
                }
                else if (hitInfo.collider.tag == "Terrain")
                {
                    pgo.transform.position = hitInfo.point;
                    pgo.GetComponent<Building>().ChangeTexNormal();
                    //pgo.transform.Find("Body").GetComponent<Renderer>().material.color = Color.gray;

                    if (Input.GetMouseButtonDown(0))
                    {
                        PlaceCubeNear(hitInfo.point);
                        //GetComponent<AudioSource>().Play();
                    }
                }
            }
        }
    }
    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        if (FindObjectOfType<GameManager>().CanPlace())
        {
            GameObject objectList = GameObject.Find("ObjectList");
            if (objectList == null)
            {
                objectList = new GameObject("ObjectList");
            }
            GameObject temp = Instantiate(data.Model);
            temp.transform.position = finalPosition;
            temp.transform.SetParent(objectList.transform);
            temp.tag = "Building";
            GameManager gm = FindObjectOfType<GameManager>();
            gm.AddnewBuilding(data.Name, finalPosition);

            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                data = null;
                Destroy(pgo);
            }
        }
    }

    public void PlaceCube(BuildingsData obj, Vector3 pos)
    {
        if (FindObjectOfType<GameManager>().CanPlace())
        {
            GameObject objectList = GameObject.Find("ObjectList");
            if (objectList == null)
            {
                objectList = new GameObject("ObjectList");
            }
            GameObject temp = Instantiate(obj.Model);
            temp.transform.position = pos;
            temp.transform.SetParent(objectList.transform);
            GameManager gm = FindObjectOfType<GameManager>();
            gm.AddnewBuilding(obj.Name, pos);
        }
    }
}
