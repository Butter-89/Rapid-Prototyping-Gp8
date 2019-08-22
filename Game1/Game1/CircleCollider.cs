using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

//  how to use this class for a 2D circle collider:
//  Create a Circle variable (initialize the center position & radius if possible)
//  Update the circle collider's position (and raius if needed)
//  For point collision checking, use the Collide() function
//  For two circle collider checking, use the Intersects() function.

namespace Game1
{
    public struct Circle
    {
        public Vector2 Center { get; set; }
        public float Radius { get; set; }

        public Circle(Vector2 center, float radius) //constructor for the Circle struct
        {
            Center = center;
            Radius = radius;
        }

        public void UpdateCollider(Vector2 center, float radius) //used to update the collider position in each update.
        {
            Center = center;
            Radius = radius;
        }
        public void UpdateColliderPosition(Vector2 center)
        {
            Center = center;
        }

        public bool Collide(Vector2 centerPoint) // used for the player-debris-collision checking
        {
            return ((centerPoint - Center).Length() <= Radius); //centerPoint is the center coordination of the other object.
        }
        public bool Intersects(Circle other)
        {
            return ((other.Center - Center).Length() < (other.Radius + Radius));
        }
    }
}
