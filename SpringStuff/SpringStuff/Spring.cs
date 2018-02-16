using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class Spring
{
    public Vector2 beginPoint, endPoint;
    public float restLength, newLength, stiffness, radius;
    public float stretch = 0.0f;

    public Spring(Vector2 beginPoint, Vector2 endPoint, float restLength, float newLength, float stiffness, float radius, float stretch)
    {
        this.beginPoint = beginPoint;
        this.endPoint = endPoint;
        this.restLength = restLength;
        this.stiffness = stiffness;
        this.radius = radius;
        this.stretch = stretch;
    }

    public void Physics()
    {
        float mass = 5.0f;
        float downForce = mass * 9.81f;
        float upForce = -stiffness * stretch;
        float move = downForce / stiffness + upForce;
        newLength = restLength + move;
        stretch = newLength - restLength;
    }
}
