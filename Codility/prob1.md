The effects of global warming can be seen more and more each year. That is why many countries aim to reduce greenhouse gases by creating electricity from the wind instead of from fossil fuels. Wind turbines have fewer negative effects on the environment and create less carbon dioxide.

A company has a contract to build a wind farm on a rectangular area of land. The goal is to build as many turbines as possible, to make the wind farm's power capacity as high as possible.

It was recently discovered that an endangered species of bird lives on the land. The area where these birds live is called a "habitat". The company wants to build the wind turbines at a distance greater than K from every bird habitat.

The map of the land is given as a rectangular matrix A of integers. Bird habitats are represented as 1 and all other locations are represented as 0.

A turbine will fill exactly one cell of the map and each cell can have at most one turbine. The distance between two locations is equal to the sum of horizontal and vertical distances between two cells on the map. For example, the distance between cells A[3][2] and A[1][4] is [1-31+14-21=4.

Write a function:

class Solution { public int solution (int[][] A, int K); }

that, given matrix A consisting of N rows and M columns and an integer K, returns the maximum number of wind turbines that can be built while staying more than K distance from the birds.

Examples:

1. Given A of size 4 * 3 and K = 1 with bird habitats at (0, 0), (2, 2) and (3, 1):
A[0][0] = 1A[0][1] = 0A[0][2] = 0A[1][0] = 0A[1][1] = 0A[1] [2] = 0A[2][0] = 0A[2][1] = 0A[2][2] = 1A[3][0] = 0A[3][1] = 1 A[3][2] = 0
the function should return 3. Wind turbines can be built in three locations: (0, 2), (1, 1) and (2, 0).

2. Given A of size 3 * 4 and K = 2 with no habitats:
A[0][0] = 0A[0][1] = 0A[0][2] = 0A[0][3] = 0A[1][0] = 0A[1] [1] = 0A[1][2] = 0A[1][3] = 0A[2][0] = 0A[2][1] = 0A[2][2] = A[2][3] = 0
the function should return 12. A wind turbine can be built in every location.

3. Given A of size 8 x 8 and K = 2 with bird habitats at (2, 2) and (6, 6):
   the function should return 40. Wind turbines can be built in the white cells. Cells that are too close to bird habitats are blue.

Write an efficient algorithm for the following assumptions:
* N and M are integers within the range [1..600];
* K is an integer within the range [1..1,200];
each element of matrix A is an integer that can have one of the following values: 0, 1.