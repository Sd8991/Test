using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class Spring
{
    public Vector2 beginPoint, endPoint;
    public float rustLength, newLength, stiffness, radius;

    public Spring(Vector2 beginPoint, Vector2 endPoint, float rustLength, float newLength, float stiffness, float radius)
    {
        this.beginPoint = beginPoint;
        this.endPoint = endPoint;
        this.rustLength = rustLength;
        this.stiffness = stiffness;
        this.radius = radius;
    }

    public void Physics()
    {
        float mass = 5.0f;
        float downForce = mass * 9.81f;
        float move = downForce / stiffness;
        newLength = rustLength + move;
    }
}
