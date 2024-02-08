namespace LeggyMazeLib
{
    public class GridVector
    {
        public int x, y;
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt((double)(x*x + y*y));
            }
        }
        public GridVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public static readonly GridVector Up = new GridVector(0, 1), Down = new GridVector(0, -1), Left = new GridVector(-1, 0), Right = new GridVector(1, 0), Zero = new GridVector(0, 0);

        public static GridVector operator +(GridVector lhs, GridVector rhs)
        {
            return new GridVector(lhs.x+rhs.x, lhs.y+rhs.y);
        }

        public static GridVector operator -(GridVector lhs, GridVector rhs)
        {
            return new GridVector(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static GridVector operator *(GridVector lhs, int rhs)
        {
            return new GridVector(lhs.x * rhs, lhs.y * rhs);
        }
        public bool Equals(GridVector gv)
        {
            return gv.x == x && gv.y == y;
        }
    }
}
