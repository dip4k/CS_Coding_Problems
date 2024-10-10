// Given an array of binary digits, 0 and 1, sort the array so that all zeros are at one end and all ones are at the other. Which end does not matter. Determine the minimum number of swaps to sort the array.
// Example:
// arr=[0,1,0,1,0]
// With 1 move, switching elements 1 and 4, yields [0,0,0,1,1], a sorted array.

/* Approach 1 -> bruteforce
Assume all o's should be at one end and all 1's at other end
1. count number of 0's and 1's 
2. array can be sorted in ascending or descending order, to find exact minimum swaps we need to consider both scenario
3. assume array is sorted in ascending -> 0's then 1's
    for this count no of misplaced 1's in left side of array for cont of 0's 
    it will give misplaced 1's in ascending sorted array
4. assume array is sorted in descending -> 1's then 0's
    for count of 1's check how many 0's are misplaced in left side of array for cont of 1's 
    it will give misplaced 0's in descending sorted array
4. return minimum of misplaced 1's and misplaced 0's count
*/

public int MinSwapCount(int[] input)
{
  int countOf0s = 0;
  int countOf1s = 0;

  // count 0's and 1's
  for (int i = 0; i < input.Length; i++)
  {
    if (input[i] == 1)
    {
      countOf1s++;
    }
    else countOf0s++;
  }

  // check misplaced 1's in ascending sorted array
  int misplaced1sInAscendingArray = 0;
  for (int i = 0; i < countOf0s; i++)
  {
    if (input[i] == 1) misplaced1sInAscendingArray++;
  }

  // check misplaced 0's in descending sorted array
  int misplaced0sInDescendingArray = 0;
  for (int i = 0; i < countOf1s; i++)
  {
    if (input[i] == 0) misplaced0sInDescendingArray++;
  }

  return Math.Min(misplaced1sInAscendingArray, misplaced0sInDescendingArray);
}

/* Approach 2 : using 2 pointers
1. 

*/

public int MinSwaps1(int[] input)
{
  int swapsForAscending = MinSwapCount1(input,true);
  int swapsForDescending = MinSwapCount1(input,false);
  return Math.Min(swapsForAscending,swapsForDescending);
}

public int MinSwapCount1(int[] input, bool isAscending)
{
  int left = 0;
  int right = input.Length - 1;
  int swaps = 0;

  while (left < right)
  {
    if (isAscending)
    {
      // Ascending order: all 0's on the left, all 1's on the right
      while (left < right && input[left] == 0)
      {
        left++;
      }
      while (left < right && input[right] == 1)
      {
        right--;
      }
    }
    else
    { // Descending order: all 1's on the left, all 0's on the right
      while (left < right && input[left] == 1)
      {
        left++;
      }
      while (left < right && input[right] == 0)
      {
        right--;
      }
    }

    // swap element if they are misplaced
    if (left < right)
    {
      // int temp = input[left];
      // input[left] = input[right];
      // input[right] = temp;
      swaps++;
      left++;
      right--;
    }
  }
  return swaps;
}
