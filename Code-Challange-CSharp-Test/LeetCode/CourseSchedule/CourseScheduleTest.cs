using Code_Challange_CSharp.LeetCode;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challange_CSharp_Test.LeetCode
{
    public static class CourseScheduleTest
    {
        [Theory]
        [ClassData(typeof(CourseScheduleSampleData))]
        public static void CanFinishTest(int numCourse , int[][] prerequisites , bool expected)
        {
            var result = CourseSchedule.CanFinish(numCourse, prerequisites);
            Assert.Equal(result , expected);
        }
    }



    public class CourseScheduleSampleData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            int[][] test = new int[1][];
            test[0] = [1 , 2];
            yield return new object[] { 2, test  , false};
            //yield return new object[] { 1, [[1 ,2]] };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
