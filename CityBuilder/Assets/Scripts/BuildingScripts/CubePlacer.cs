using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameObject Prefab;
    public BuildingsData data;
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && data != null)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.tag != "Resource")
            {
                PlaceCubeNear(hitInfo.point);
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
            GameManager gm = FindObjectOfType<GameManager>();
            gm.AddnewBuilding(data.Name, finalPosition);

            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                data = null;
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
