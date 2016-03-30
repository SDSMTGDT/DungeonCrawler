﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SDSMTGDT.GWorks.Physics.Collisions;
using SDSMTGDT.GWorks.Physics.Collisions.Routes;

namespace SDSMTGDT.GWorks.Physics
{
    /// <summary>
    /// Object designed to test the Physics Manager's Collision system
    /// </summary>
    public class TestColliderA : Collidable
    {
        public bool collided { get; private set; } = false;
        public TestColliderA(PhysicsManager physics)
        {
            var publisher = physics.getCollisionHook(this);
            var router = new CollisionEventRouter();
            router.addCollisionRoute(new TypeCollisionRoute<TestColliderA, TestColliderB>(testBCollision));
            publisher.registerEventSubscriber(router);
        }

        /// <summary>
        /// Returns the location, width, and height of the object
        /// TODO: ACTUALLY IMPLEMENT
        /// </summary>
        /// <returns>An axis aligned bounding box</returns>
        public Rectangle getBounds()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Code to be called when this object collides with
        /// </summary>
        /// <param name="thisInstance">Reference to this object</param>
        /// <param name="collided">The object of type TestColliderB this instance collided with</param>
        public void testBCollision(TypedCollisionEventInfo<TestColliderA, TestColliderB> info)
        {
            collided = true;
        }
    }
}
