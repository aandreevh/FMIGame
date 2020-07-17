using Signals.Receivers.Unary;
using UnityEngine;
using World.Navigation;

namespace World.Objects.Traps
{
    public class Dispenser : UnaryReceiver
    {
        [SerializeField] private GameObject spawnObject;
        [SerializeField] private Point spawnPoint;

        protected override void OnSignalAcquired()
        {
            var obj = Instantiate(spawnObject);
            obj.transform.position = spawnPoint.Position;
            obj.SetActive(true);
            obj.transform.parent = transform;
        }
    }
}