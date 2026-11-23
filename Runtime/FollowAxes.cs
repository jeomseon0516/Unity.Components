using System;

namespace Jeomseon.Unity.Components
{
    [Flags]
    public enum FollowAxes
    {
        None = 0b000,
        X = 0b001,
        Y = 0b010,
        Z = 0b100,
        All = X | Y | Z,
    }
}
