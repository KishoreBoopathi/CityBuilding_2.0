 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameObject Prefab;
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Prefab != null)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitInfo) && hitInfo.collider.tag != "Resource"){
                PlaceCubeNear(hitInfo.point);
            }
        }
    }
    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        if (FindObjectOfType<GameManager>().CanPlace())
        {
            Instantiate(Prefab).transform.position = finalPosition;
        }
    }
}
