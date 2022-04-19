using UnityEngine;

public class BarrelPresenter : MonoBehaviour, IDestroyable
{
    void IDestroyable.DestroySelf()
    {
        Destroy(gameObject);
    }

}
