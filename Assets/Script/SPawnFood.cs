using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPawnFood : SPawnItem
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    public override void DiscountItem()
    {
        base.DiscountItem();
    }

    private void OnDrawGizmos()
    {
        base.DrawGizmos();
    }
}
