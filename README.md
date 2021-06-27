# 8PuzzleSim

## Running the Simulator

### Drag and Drop Tiles

Click and hold to drag and drop the tiles in the placements that you desire. The puzzle will warn you if your placement isn't solvable.

![Drag and drop](https://github.com/williammcintosh/8PuzzleSim/blob/main/images/8piece_start_loading_gif.gif)

### Choose Desired Settings

Click and hold to drag and drop the tiles in the palcement you desire and select the desired settings.

![Select settings](https://github.com/williammcintosh/8PuzzleSim/blob/main/images/8piece_shift_around.gif)

### Press Start and Look Around

You can hold the spacebar to move quickly. Press 'q' (without shift) to zoom in, press 'a' (without shift) to zoom out. Press the arrows to move around.

![Find the answer](https://github.com/williammcintosh/8PuzzleSim/blob/main/images/8piece_move_around.gif)

## Explaining the Logic

### A-Star Search

A-Star search examines all values available in all leafs of the tree and selects the leaf with the lowest value. That value is calculated by adding together two parts:
* G(n)
    * The distance in height of the tree from the root note
* H(n)
    * The heurustic value (read below for more)

![Values Explained](https://github.com/williammcintosh/8PuzzleSim/blob/main/images/8piece_values_explained.png)

### Heuristic

This is a fancy way of labeling the method of placing a value of one configuration from the goal state to another. Heuristics give values to the configuration of the nodes. The A-Star search then uses this value to determine which node configuration to prioritize over others.

Though there are many heuristics out there, these are the three I chose for this project:
* Misplaced Tiles
* Manhattan Distance
* Gaschnig’s Swaps

#### Misplaced Tiles
This is counting the number of misplaced tiles, meaning each tile is considered, if that tile is not in the same position as the goal state position, then you count it. Add the count together for each tile and add that to the total. That’s the Misplaced Tiles cost.

![Misplaced Tiles](https://github.com/williammcintosh/8PuzzleSim/blob/main/images/8piece_misplaced.png)

#### Manhattan Distance

Is the sum of the distances of the tiles from their goal positions. Because tiles cannot move along diagonals, the distance we will count is the sum of the horizontal and vertical distances. The main idea is that in a grid-like city like Manhattan, you can only move orthogonal distances. Take the sums of all of those for each time in the entire configuration and you’ve got yourself the Manhattan Distance cost total.

The single configuration below would have a total of:
    * = (#1 = 1) + (#3 =  3)    + (#5 =  1)    + (#6 =  1)    + (#7 =  4)    + (#8 =  3)
    * =       1  +        3     +        1     +        1     +        4     +        3
    * = 14

![Manhattan Distance](https://github.com/williammcintosh/8PuzzleSim/blob/main/images/8piece_manhattan_distance.png)

#### Gaschnig’s Swaps
This is an iterative approach to finding the heuristics above. How this works is that we consider the problem of the 8 puzzle a relaxed problem first, then we iteratively swap the tiles in the placements they need. This unfortunately turns out to be a more computationally expensive Misplaced Tiles heuristic. The value is always the same.

![Gashnigs Swaps](https://github.com/williammcintosh/8PuzzleSim/blob/main/images/8piece_gashnigs.png)

These are the steps:
* We start with the blank space and find which location it’s in. Locate that tile and swap it with the blank.
* Increment a counter by one.
* Do that again until all tiles have been in their right place.
 
## Resulting Data

### Best-First Search

#### Misplaced Tiles Heuristic

* 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.070, Nodes Visited: 6
* 136042758 -> 136402758 -> ??? (my nodes start to clutter together)
    * Run Time: 0.094, Nodes Visited: 99
* 253176408 -> 253106478 -> 203156478 -> 023156478 -> 123056478 -> 123456078 -> 123456708 -> 123456780
    * Run Time: 0.104, Nodes Visited: 9
* 412703856 -> 412753806 -> 412753086 -> 412053786 -> 012453786 -> 102453786 -> 120453786 -> 123450786 -> 123456780
    * Run Time: 0.094, Nodes Visited: 9
* 410723586 -> 413720586 -> 413726580 -> 413702586 -> 413072586 -> ???
    * Run Time: 28.386, Nodes Visited: Max Nodes Reached (Increased max to 200)

Average Time: 5.7496, Average Nodes: 64.6

#### Manhattan Distance

* 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
   * Run Time: 0.050, Nodes Visited: 6
* 136042758 -> 136402758 -> 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
   * Run Time: 5.166, Nodes Visited: 8
* 253176408 -> 253106478 -> 203156478 -> 023156478 -> 123056478 -> 123456078 -> 123456708 -> 123456780
   * Run Time: 0.109, Nodes Visited: 8
* 412703856 -> 412753806 -> 412753086 -> 412053786 -> 012453786 -> 102453786 -> 120453786 -> 123450786 -> 123456780
   * Run Time: 0.091, Nodes Visited: 9
* 410723586 -> 413720586 -> 413726580 -> 413726508 -> 413726058 -> 413026758 -> 013426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
   * Run Time: 0.191, Nodes Visited: 11

Average Time: 1.1214, Average Nodes: 8.4

#### Gaschnig’s Swaps
* 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.105, Nodes Visited: 6
* 136042758 -> 136402758 -> ??? (my nodes start to clutter together)
    * Run Time: 7.166, Nodes Visited: 99
* 253176408 -> 253106478 -> 203156478 -> 023156478 -> 123056478 -> 123456078 -> 123456708 -> 123456780
    * Run Time: 0.298, Nodes Visited: 9
* 412703856 -> 412753806 -> 412753086 -> 412053786 -> 012453786 -> 102453786 -> 120453786 -> 123450786 -> 123456780
    * Run Time: 0.194, Nodes Visited: 9
* 410723586 -> ???
    * Run Time: TIMEOUT, Nodes Visited: Error (Increased max to 200)

Average Time: 10.7552, Average Nodes: 64.6

### A* Search

#### Misplaced Tiles Heuristic

* 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.090, Nodes Visited: 6
* 136042758 -> 136402758 -> 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.136, Nodes Visited: 11
* 253176408 -> 253106478 -> 203156478 -> 023156478 -> 123056478 -> 123456078 -> 123456708 -> 123456780
    * Run Time: 0.124, Nodes Visited: 9
* 412703856 -> 412753806 -> 412753086 -> 412053786 -> 012453786 -> 102453786 -> 120453786 -> 123450786 -> 123456780
    * Run Time: 0.133, Nodes Visited: 9
* 410723586 -> 413720586 -> 413726580 -> 413702586 -> 413072586 -> 413572086 -> 413026758 -> 013426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.717, Nodes Visited: 32

Average Time: 0.240, Average Nodes: 13.4

#### Manhattan Distance

* 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.070, Nodes Visited: 6
* 136042758 -> 136402758 -> 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.090, Nodes Visited: 8
* 253176408 -> 253106478 -> 203156478 -> 023156478 -> 123056478 -> 123456078 -> 123456708 -> 123456780
    * Run Time: 0.101, Nodes Visited: 8
* 412703856 -> 412753806 -> 412753086 -> 412053786 -> 012453786 -> 102453786 -> 120453786 -> 123450786 -> 123456780
    * Run Time: 0.130, Nodes Visited: 9
* 410723586 -> 413720586 -> 413726580 -> 413072586 -> 413572086 -> 413026758 -> 013426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.198, Nodes Visited: 14

Average Time: 0.1178, Average Nodes: 9

#### Gaschnig’s Swaps
* 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.130, Nodes Visited: 6
* 136042758 -> 136402758 -> 136420758 -> 130426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 0.159, Nodes Visited: 11
* 253176408 -> 253106478 -> 203156478 -> 023156478 -> 123056478 -> 123456078 -> 123456708 -> 123456780
    * Run Time: 0.359, Nodes Visited: 9
* 412703856 -> 412753806 -> 412753086 -> 412053786 -> 012453786 -> 102453786 -> 120453786 -> 123450786 -> 123456780
    * Run Time: 0.267, Nodes Visited: 9
* 410723586 -> 413720586 -> 413726580 -> 413702586 -> 413072586 -> 413572086 -> 413026758 -> 013426758 -> 103426758 -> 123406758 -> 123456708 -> 123456780
    * Run Time: 1.439, Nodes Visited: 32

Average Time: 0.4708, Nodes Visited: 13.4
