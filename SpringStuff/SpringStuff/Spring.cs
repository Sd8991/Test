using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class Spring
{
    public Vector2 beginPoint, endPoint;
    public double restLength, newLength, stiffness, radius, move, area, innerArea, length;
    public double stretch = 0.0f;
    double thyme = 0;

    public Spring(Vector2 beginPoint, Vector2 endPoint, int nrOfWinding/*, float stiffness*/, float radius, float stretch, float materialThickness, float displacmentThingy = 69000, float move = 0)
    {
        this.beginPoint = beginPoint;
        this.endPoint = endPoint;
        this.radius = radius;
        this.stretch = stretch + 5;
        this.move = move;
        restLength = materialThickness * nrOfWinding;
        this.newLength = restLength;
        area = Math.PI * radius;
        innerArea = Math.PI * (radius - materialThickness);
        length = area * nrOfWinding;
        stiffness = (displacmentThingy * Math.Pow(materialThickness, 4)) / (8 * nrOfWinding * Math.Pow((area - innerArea) / 2, 3));
    }

    public void SLS(GameTime gameTime, float mass = 5.0f)//Simple Liniear Spring
    {
        thyme += (double)gameTime.ElapsedGameTime.Milliseconds / 1000;
        move = Math.Sin(thyme * Math.Sqrt(stiffness / mass));
        newLength += move;
        stretch = newLength - restLength;
    }

    public void CodeStash()
    {/*
        double upForce = -stiffness * stretch;
        double downForce = mass * 9.81f;
        double resultForce = upForce - downForce;
        double acc = stretch / ((thyme * thyme));
        double resultMass = Math.Abs(resultForce / acc);
        float mass = 0;
    float damping = 1;
    //float acc = downForce / mass;;*/
    }
}
