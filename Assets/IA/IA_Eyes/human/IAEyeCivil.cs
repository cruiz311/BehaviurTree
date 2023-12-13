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
        UpdateScan();
    }


    public override void UpdateScan()
    {

        if (Framerate > arrayRate[index])
        {

            index++;
            index = index % arrayRate.Length;
            this.Scan();
            Framerate = 0;
        }

        Framerate += Time.deltaTime;

        if (ViewEnemy != null && ((ViewEnemy.IsDead) || (!ViewEnemy.IsCantView)))
        {
            ViewEnemy = null;
        }
        if (ViewEnemy != null)
        {
            mainDataView.Sight = false;
            RadioActionDataView.Sight = false;
        }

    }

    public override void Scan()
    {
        if (health.HurtingMe != null) return;
        ViewAllie = null;
        ViewEnemy = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, mainDataView.Distance, mainDataView.Scanlayers);
        CountEnemyView = 0;
        countSoldierView = 0;
        countCivilView = 0;
        count = colliders.Length;


        float min_dist = 10000000000f;

        for (int i = 0; i < count; i++)
        {

            GameObject obj = colliders[i].gameObject;

            if (this.IsNotIsThis(this.gameObject, obj))
            {

                Health Scanhealth = obj.GetComponent<Health>();
                if (Scanhealth != null &&
                    obj.activeSelf &&
                    !Scanhealth.IsDead &&
                    Scanhealth.IsCantView &&
                    mainDataView.IsInSight(Scanhealth.AimOffset))
                {
                    if (IsAllies(Scanhealth))
                    {
                        base.ExtractViewAllied(ref min_dist, Scanhealth);
                    }
                    else
                       base.ExtractViewEnemy(ref min_dist, Scanhealth);
                }

            }

        }
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
