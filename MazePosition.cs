namespace LeggyMazeLib
{
    public class MazePosition
    {
        public bool canMoveWest, canMoveEast, canMoveNorth, canMoveSouth;

        public MazePosition(bool left, bool right, bool up, bool down)
        {
            canMoveWest = left;
            canMoveEast = right;
            canMoveNorth = up;
            canMoveSouth = down;
        }

        public MazePosition(bool startingValue) : this(startingValue, startingValue, startingValue, startingValue)
        {

        }

        public MazePosition(MazePosition pos) : this(pos.canMoveWest, pos.canMoveEast, pos.canMoveNorth, pos.canMoveSouth)
        {

        }

        public bool IsValidMove(GridVector move)
        {
            return move.Magnitude == 1 && (move.x == 1 && canMoveEast || move.x == -1 && canMoveWest || move.y == 1 && canMoveNorth || move.y == -1 && canMoveSouth);
        }
    }
}