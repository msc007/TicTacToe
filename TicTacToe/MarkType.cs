using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// The type of value a cell in the game is currently at
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// Cell Value = Not Clicked Yet
        /// </summary>
        Free,
        /// <summary>
        /// Cell Value = O
        /// </summary>
        Nought,
        /// <summary>
        /// Cell Value = X
        /// </summary>
        Cross
    }
}
