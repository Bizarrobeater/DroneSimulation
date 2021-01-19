using System;
using System.Collections.Generic;
using System.Text;

namespace DroneSimulation
{
    class Airspace
    {
        List<Drone> _drones = new List<Drone>();
        List<Drone[]> _collidingDrones = new List<Drone[]>();


        public void FlyDrones()
        {
            foreach(Drone drone in _drones)
            {
                drone.Fly();
            }
        }

        public float DroneDist(Drone x, Drone y)
        {
            float xRelPos = x.Position[0] - y.Position[0];
            float yRelPos = y.Position[1] - y.Position[1];
            float sqrtDistance = (float)(Math.Pow(xRelPos, 2) + Math.Pow(yRelPos, 2));
            return (float)Math.Sqrt(sqrtDistance);
        }

        public void AddDrone(Drone newDrone)
        {
            _drones.Add(newDrone);
        }


        // TODO: finish this method, should probably be in several methods.
        public void WillCollide()
        {
            List<Drone[]> collisionPairs = new List<Drone[]>();

            for (int i = 0; i < _drones.Count - 1; i++)
            {
                Drone xDrone = _drones[i];
                for (int j = i + 1; j < _drones.Count; j++)
                {
                    Drone yDrone = _drones[j];
                    float distance = DroneDist(xDrone, yDrone);
                    if (distance < 5f)
                    {
                        collisionPairs.Add(new Drone[] { xDrone, yDrone });
                    }
                }
            }

            collisionPairs = CheckForMulitpleCollisions(collisionPairs);
            _collidingDrones.AddRange(collisionPairs);

        }

        private void RemoveDestroyedDrone(List<Drone[]> collisionPairs)
        {

        }

        private List<Drone[]> CheckForMulitpleCollisions(List<Drone[]> collisionPairs)
        {
            Dictionary<Drone, List<Drone>> collidingDrones = new Dictionary<Drone, List<Drone>>();
            
            foreach (Drone[] pair in collisionPairs)
            {
                AddDronesToCollisionDict(pair[0], pair[1], ref collidingDrones);
                AddDronesToCollisionDict(pair[1], pair[2], ref collidingDrones);
            }

            foreach (KeyValuePair<Drone, List<Drone>> collisions in collidingDrones)
            {
                if (collisions.Value.Count <= 1)
                    continue;

            }

            return new List<Drone[]>();
        }

        private void AddDronesToCollisionDict(Drone xDrone, Drone yDrone, ref Dictionary<Drone, List<Drone>> collidingDrones)
        {
            if (collidingDrones.ContainsKey(xDrone))
                collidingDrones[xDrone].Add(yDrone);
            else
                collidingDrones[xDrone] = new List<Drone> { yDrone };
        }

        // TODO find the least distance between multiple crashing drones and have them crash, other drones involved will be safe
        private void CrashLeastDistanceDrones(Drone keyDrone, Dictionary<Drone, List<Drone>> collidingDrones)
        {
            foreach (Drone crashDrone in collidingDrones[keyDrone])
            {

            }
        }

    }
}
