using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour
{
    
    protected float FrameRate = 0;
    protected float Rate ;
    public float MinRate;
    public float MaxRate;
    public List< UnityEvent> eventInvoke;
    public LayerMask layerCollider;
    public bool Infinity = false;
    public void LoadArrayRate()
    {
         
            Rate = Random.Range(MinRate, MaxRate);
         
    }
    public void DestroyItem()
    {
        foreach (var item in eventInvoke)
        {
            item.Invoke();
        }
        Destroy(this.gameObject);
    }
}
