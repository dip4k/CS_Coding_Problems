We are given a two-dimensional board of size Nx M (N rows and M columns). Each field of the board can be empty (.), may contain an obstacle (X") or may have a character in it. The character might be either an assassin (A) or a guard. Each guard stands still and looks straight ahead, in the direction they are facing.

Every guard looks in one of four directions (up, down, left or right on the board) and is represented by one of four symbols. A guard denoted by '<' is looking to the left; by '>', to the right; '*', up; or 'v', down. The guards can see everything in a straight line in the direction in which they are facing, as far as the first obstacle ('X' or any other guard) or the edge of the board.

The assassin can move from the current field to any other empty field with a shared edge. The assassin cannot move onto fields containing obstacles or enemies.

Write a function:
class Solution { public bool solution(string[] B); }
that, given an array B consisting of N strings denoting rows of the array, retums true if is it possible for the assassin to sneak from their current location to the bottom-right cell of the board undetected, and false otherwise.

Examples:
1. Given B = [x..............", "A...... 1 your function should retum false. All available paths lead through a field observed by a guard.
2. Given B[...Xv", "Ax..^", .xx.. 1 your function should return true. The guard in the second row is blocking the other one from watching the bottom-right square.
3. Given B =["...", ">.A"], your function should return false, as the assassin gets spotted right at the start.
4. Given B = [A. v,... 1 your function should return false. It's not possible for the assassin to enter the bottom-right cell undetected, as the cell is observed.

Write an efficient C# algorithm for the following assumptions:
N is an integer within the range [1..500];
all strings in B are of the same length M from range [1..500];
there is exactly one assassin on the board,
there is no guard or wall on B[N-1][M-1];
every string in B consists only of the following characters X,',', 'V, and/or 'A'.