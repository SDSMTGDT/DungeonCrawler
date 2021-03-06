﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDSMTGDT.GWorks.Physics.Collisions.DataStructures.Factories
{
    /// <summary>
    /// Encapsulates the information needed to create a CollisionQuadTree
    /// Used by collisions manager to create quad tree backed collision groups
    /// </summary>
    public class CollisionQuadTreeFactory : CollisionStructureFactory
    {
        private readonly int x;
        private readonly int y;
        private readonly int size;

        public CollisionQuadTreeFactory(int x, int y, int size)
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        internal override CollisionStructure CreateCollisionStructure()
        {
            return new CollisionQuadTree(x, y, size);
        }
    }
}
