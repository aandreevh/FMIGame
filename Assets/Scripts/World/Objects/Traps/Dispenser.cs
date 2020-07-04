using Signals.Receivers.Unary;
using UnityEngine;
using World.Navigation;

namespace World.Objects.Traps
{
    public class Dispenser : UnaryReceiver
    {
        [SerializeField] private Point spawnPoint;
        [SerializeField] private GameObject spawnObject;
        protected override void OnSignalAcquired()
        {
            var obj = Instantiate(spawnObject);
            obj.transform.position = spawnPoint.Position;
            obj.SetActive(true);
            obj.transform.parent = transform;
        }
    }
}