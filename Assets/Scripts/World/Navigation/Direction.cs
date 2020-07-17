using UnityEngine;

namespace World.Navigation
{
    public enum Direction
    {
        Up = 0,
        Down = 1,
        Right = 2,
        Left = 3
    }

    public static class DirectionMethods
    {
        public static Vector2 Normal(this Direction type)
        {
            switch (type)
            {
                case Direction.Up:
                    return Vector2.up;
                case Direction.Down:
                    return Vector2.down;
                case Direction.Left:
                    return Vector2.left;
                case Direction.Right:
                    return Vector2.right;
                default:
                    return Vector2.zero;
            }
        }

        public static Quaternion Rotation(this Direction type)
        {
            switch (type)
            {
                case Direction.Up:
                    return Quaternion.Euler(new Vector3(0, 0, 0));
                case Direction.Down:
                    return Quaternion.Euler(new Vector3(0, 0, 180));
                case Direction.Left:
                    return Quaternion.Euler(new Vector3(0, 0, 90));
                case Direction.Right:
                    return Quaternion.Euler(new Vector3(0, 0, -90));
                default:
                    return Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }
}