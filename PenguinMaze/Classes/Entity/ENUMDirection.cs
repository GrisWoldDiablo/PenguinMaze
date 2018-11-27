using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.Entity
{
    /// <summary>
    /// Enumerator for entity movement heading.
    /// 
    /// </summary>
    enum Direction
    {
        /// <summary>
        /// Not moving
        /// </summary>
        NONE,
        /// <summary>
        /// Heading North
        /// </summary>
        UP,
        /// <summary>
        /// Heading South 
        /// </summary>
        DOWN,
        /// <summary>
        /// Heading West 
        /// </summary>
        LEFT,
        /// <summary>
        /// Heading East
        /// </summary>
        RIGHT
    }
    
}
