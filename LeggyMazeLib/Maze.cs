namespace LeggyMazeLib
{
    public class Maze
    {
        private MazePosition[,] maze;
        public const int MAZE_WIDTH = 5, MAZE_HEIGHT = 5;
        public GridVector startPos, endPos;

        Random rand = new Random();

        public int GetRandomInt(int minInclusive, int maxExclusive)
        {
            return rand.Next(minInclusive, maxExclusive);
        }

        public MazePosition GetPosition(int x, int y)
        {
            return maze[x, y];
        }

        private void MakeMazeNull()
        {
            maze = new MazePosition[MAZE_WIDTH, MAZE_HEIGHT];
            for (int x = 0; x < MAZE_WIDTH; x++)
            {
                for (int y = 0; y < MAZE_HEIGHT; y++)
                {
                    maze[x, y] = null;
                }
            }
        }

        private void GenerateStartPos()
        {
            int swap = GetRandomInt(0, 2);
            if (swap == 0)
            {
                startPos = new GridVector(GetRandomInt(0, MAZE_WIDTH), GetRandomInt(0, 2) * (MAZE_HEIGHT - 1));
            }
            else
            {
                startPos = new GridVector(GetRandomInt(0, 2) * (MAZE_WIDTH - 1), GetRandomInt(0, MAZE_HEIGHT));
            }
        }


        private int FlipOrRandomize(int value, int exclusiveMax)
        {
            int inclusiveMax = exclusiveMax - 1;
            if (value == 0) return inclusiveMax;
            if (value == inclusiveMax) return 0;
            return GetRandomInt(0, exclusiveMax);
        }

        private void GenerateEndPos()
        {
            endPos = GridVector.Zero;
            endPos.x = FlipOrRandomize(startPos.x, MAZE_WIDTH);
            endPos.y = FlipOrRandomize(startPos.y, MAZE_HEIGHT);
        }

        private static bool IsInMaze(GridVector pos)
        {
            bool goodX = pos.x >= 0 && pos.x < MAZE_WIDTH;
            bool goodY = pos.y >= 0 && pos.y < MAZE_HEIGHT;
            return goodX && goodY;
        }
        static readonly GridVector[] directions = { GridVector.Up, GridVector.Right, GridVector.Down, GridVector.Left };

        private GridVector[] GetPossibleMoves(GridVector currentPosition)
        {
            List<GridVector> output = new List<GridVector>();
            foreach (var dir in directions)
            {
                GridVector nextPos = currentPosition + dir;
                if (IsInMaze(nextPos) && maze[nextPos.x, nextPos.y] == null)
                {
                    output.Add(dir);
                }
            }
            return output.ToArray();
        }


        private void RemoveWall(GridVector selectedMove, ref MazePosition mazePosition)
        {
            if (selectedMove.Equals(GridVector.Up))
            {
                // remove north wall
                mazePosition.canMoveNorth = true;
            }
            else if (selectedMove.Equals(GridVector.Down))
            {
                // remove south wall
                mazePosition.canMoveSouth = true;
            }
            else if (selectedMove.Equals(GridVector.Left))
            {
                // remove west wall
                mazePosition.canMoveWest = true;
            }
            else if (selectedMove.Equals(GridVector.Right))
            {
                // remove east wall
                mazePosition.canMoveEast = true;
            }
            else
            {
                // throw error
            }
        }

        private void GenerateMaze()
        {
            // how do we do this? -  "recursive backtracker" algorithm
            MakeMazeNull();
            GenerateStartPos();
            GenerateEndPos();

            Stack<GridVector> visitedPositions = new Stack<GridVector>();
            GridVector currentPos = new GridVector(startPos.x, startPos.y);
            maze[currentPos.x, currentPos.y] = new MazePosition(false);
            while (true)
            {
                GridVector[] possibleMoves = GetPossibleMoves(currentPos);
                if (possibleMoves.Length == 0)
                {
                    // if we're back to the start square and have been in every direction, stop
                    if (visitedPositions.Count == 0) break;

                    // backtrack
                    currentPos = visitedPositions.Pop();
                    continue;
                }
                visitedPositions.Push(currentPos);
                var selectedMove = possibleMoves[GetRandomInt(0, possibleMoves.Length)];
                RemoveWall(selectedMove, ref maze[currentPos.x, currentPos.y]);
                currentPos += selectedMove;
                maze[currentPos.x, currentPos.y] = new MazePosition(false);
                RemoveWall(selectedMove * -1, ref maze[currentPos.x, currentPos.y]);
            }
        }

        public Maze()
        {
            GenerateMaze();
        }
    }
}
