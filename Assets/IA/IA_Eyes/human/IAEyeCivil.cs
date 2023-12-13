using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeCivil : IAEyeHuman
{
    
    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        base.UpdateScan();
    }


   
   
    public override void LoadComponent()
    {
        base.LoadComponent();
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
}
