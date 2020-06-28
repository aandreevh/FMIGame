using UnityEngine;

namespace World.Navigation
{
    public class Direction
    {
        public enum Type 
        {
            Up=0,Down=1,Right=2,Left=3
        }

        public static Vector2 NormalFromDirection(Type type)
        {
            switch (type)
            {
                case Type.Up:
                    return Vector2.up;
                case Type.Down:
                    return Vector2.down;
                case Type.Left:
                    return Vector2.left;
                case Type.Right:
                    return Vector2.right;
                default:
                    return Vector2.zero;
            }
        }
        

    }
}