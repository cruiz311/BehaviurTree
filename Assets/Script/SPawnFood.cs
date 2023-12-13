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

    public void DiscountFood()
    { 
    
    }

    private void OnDrawGizmos()
    {
        base.DrawGizmos();
    }
}
