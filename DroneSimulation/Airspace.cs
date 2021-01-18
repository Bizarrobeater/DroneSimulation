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
            List<Drone[]> collidingDronePairs = new List<Drone[]>();
            List<Drone> collidingDrones = new List<Drone>();
            Drone xDrone;
            Drone yDrone;

            for (int i = 0; i < _drones.Count - 1; i++)
            {
                for (int j = i + 1; j < _drones.Count; j++)
                {
                    xDrone = _drones[i];
                    yDrone = _drones[j];
                    float distance = DroneDist(xDrone, yDrone);
                    if (distance < 5f)
                    {
                        if (!collidingDrones.Contains(xDrone) 
                            && !collidingDrones.Contains(xDrone))
                        {
                            collidingDronePairs.Add(new Drone[] { xDrone, yDrone });
                        }
                    }
                }
            }
        }

    }
}
