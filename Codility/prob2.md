You are given a 3 x 3 grid which contains exactly nine stones within its cells. A cell may contain any number of stones.

In each move, you can shift a stone from one cell to another if the two cells share a common side.

The grid is described by a 3 x 3 matrix of integers A. Rows are numbered from 0 to 2 from top to bottom. Columns are numbered from 0 to 2 from left to right. A[K][J] represents the number of stones in the cell located in the intersection of the Kth row and Jth column.

Write a function:
class Solution { public int solution(int[][] A); }
that, given the matrix A, retums the minimum number of moves needed to place one stone in each cell.

Examples:

1. Given input A = [[1, 0, 1], [1, 3, 0], [2, 0, 1]], the function should return 3 as output. 
2. Given input A =[ [2, 0, 2], [1, 0, 0], [2, 1, 1]] the function should return 4 as output.
3. Given Input A = [ [0, 6, 0], [2, 0, 0], [0, 1, 0]] the function should retum 9 as output.


Consider this condition 
 ** We may shift a stone from (1,1) to (0,1), from (1,1) to (1,2) and from (2,0) to (2,1).**

Write an efficient algorithm for the following assumptions:
* A has 3 rows and 3 columns;
* each element of matrix A is an integer within the range [0..9]
* A contains exactly 9 stones