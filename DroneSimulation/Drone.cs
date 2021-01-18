using System;
using System.Collections.Generic;
using System.Text;

namespace DroneSimulation
{
    class Drone
    {
        float _speed;
        float[] _destination;

        public float[] Position { get; private set; }

        public Drone(float[] position, float speed, float[] destination)
        {
            Position = position;
            _speed = speed;
            _destination = destination;
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public bool IsFinished()
        {
            throw new NotImplementedException();
        }

    }
}
