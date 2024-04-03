namespace grid_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var grid = new int[2][] { new int[] { 2, 5, 4 }, new int[] { 1, 5, 1 } };
            var ans = sol.GridGame(grid);
            Console.WriteLine(ans);
        }
    }
    // https://www.youtube.com/watch?v=N4wDSOw65hI
    public class Solution
    {
        public long GridGame(int[][] grid)
        {
            // step 1 - create prefix sum for each row
            // step 2 - do brute force for each cell and check whats the max robo 2 can get between both rows ?
            // why between 2 rows ? robo 2 has only one option eaither to take row one or two, cant take both 
            var length = grid[0].Length;
            // for row 1
            var prefix1 = new long[length];
            // for row 2
            var prefix2 = new long[length];
            prefix1[0] = grid[0][0];
            prefix2[0] = grid[1][0];
            for (int i = 1; i < length; i++)
            {
                prefix1[i] = prefix1[i - 1] + grid[0][i];
                prefix2[i] = prefix2[i - 1] + grid[1][i];
            }

            long ans = long.MaxValue;
            for (int i = 0; i < length; i++)
            {
                var firstrow = prefix1[length - 1] - prefix1[i];
                // why i == 0 then 0, coz if robo 1 take the path from first position, it will gonna take all points from 2nd row  
                var secondrow = i == 0 ? 0 : prefix2[i - 1];
                // now robo2 has one path to take, either row1 or row2
                var max = Math.Max(firstrow, secondrow);
                ans = Math.Min(ans, max);
            }
            return ans;
        }
    }
}
