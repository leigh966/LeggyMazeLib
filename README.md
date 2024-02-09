# LeggyMazeLib

## Generating the maze

### Usage
To generate the maze, all you have to do it instantiate an object of the Maze class. And that's it! You will have a maze defined as a grid of maze positions with width and height defined by their respective constants within the Maze class (although I will change this because it would be far better to pass these values in than have them constant)
```c# 
Maze m = new Maze();
```

### The Alorithm
I've chosen to use a randomized depth-first search to generate the mazes as it's straight-forward and incredibly similar to the sort of AI projects that I've worked on before. Here is a high-level view of the algorithm:
![image](https://github.com/leigh966/LeggyMazeLib/assets/56688635/8ddf8140-7e71-4d31-87eb-14fdeddb1f1b)
