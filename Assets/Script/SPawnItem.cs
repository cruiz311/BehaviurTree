using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpawnPoint
{
    public Transform point;
    public bool Active=false;
    public SpawnPoint()
    { 
    
    }

}
public class SPawnItem : MonoBehaviour
{
    public int CountItem;
    public List<SpawnPoint> spawnPoint = new List<SpawnPoint>();
    public GameObject PrefabItem;

    public Color GizmoColor;
    public bool _DrawGizmo;
    [Range(0,1)]
    public float radiusSphereGizmos;
    public void DiscountItem()
    {
        CountItem = Mathf.Clamp(CountItem-1,0, spawnPoint.Count);
    }

    public void SpawnItem()
    {
        for (int i = 1; i <= CountItem; i++)
        {
            DoSpawnPoint();
        }

    }
    public void DoSpawnPoint()
    {
        #region FindSpaceEmpty
        List<SpawnPoint> spawnPointEmpty = new List<SpawnPoint>();

        foreach (var item in spawnPoint)
        {
            if (!item.Active)
                spawnPointEmpty.Add(item);
        }
        #endregion


        if (spawnPointEmpty.Count == 0) return;

        int index = (int)Random.Range(0, spawnPointEmpty.Count);

        SpawnPoint select = spawnPointEmpty[index];

        GameObject Spawnitem = GameObject.Instantiate(PrefabItem, select.point.position, Quaternion.identity);
        select.Active = true;
        Item itemObject = Spawnitem.GetComponent<Item>();

        itemObject.eventInvoke.Add();
    }

    public void DrawGizmos()
    {
        if (!_DrawGizmo) return;
        
        foreach (var item in spawnPoint)
        {
            if(item.Active)
                Gizmos.color = GizmoColor;
            else
                Gizmos.color = Color.black;

            Gizmos.DrawSphere(item.point.position, radiusSphereGizmos);
        }
       
    }
}
