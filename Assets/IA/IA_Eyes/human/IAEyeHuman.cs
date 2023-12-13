using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeHuman : IAEyeBase
{
    public Health ViewAllie;
    public int countSoldierView;
    public int countCivilView;

    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }


    public override void UpdateScan()
    {
        base.UpdateScan();
        

    }

    private void OnValidate()
    {
        mainDataView.CreateMesh();
        RadioActionDataView.CreateMesh();
    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        RadioActionDataView.OnDrawGizmos();
    }
    public void ExtractViewAllied(ref float min_dist, Health _health)
    {

        if (IsAllies(_health))
        {
            if (_health._UnitGame == UnitGame.Soldier)
            {
                float dist = (transform.position - _health.transform.position).magnitude;
                if (min_dist > dist)
                {
                    ViewAllie = _health;
                    min_dist = dist;

                }
                countSoldierView++;
            }
            else if (_health._UnitGame == UnitGame.Civil)
            {
                float dist = (transform.position - _health.transform.position).magnitude;
                if (min_dist > dist)
                {
                    ViewAllie = _health;
                    min_dist = dist;

                }
                countCivilView++;
            }
        }
    }


    public float DistanceAllied
    {
        get
        {
            return (this.ViewAllie != null) ? (transform.position - this.ViewAllie.transform.position).magnitude : -1;
        }
    }
    public Vector3 DirectionAllied
    {
        get
        {
            if (this.ViewAllie != null)
            {
                return (this.ViewAllie.transform.position - transform.position).normalized;
            }
            return Vector3.zero;
        }
    }

}
