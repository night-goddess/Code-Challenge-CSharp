using Code_Challange_CSharp.LeetCode;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challange_CSharp_Test.LeetCode
{
    public static class CourseScheduleTest
    {
        [Fact]
        public static void CanFinishTest()
        {
            var test = new int[1][];
            test[0] = new int[] { 1, 0 };
            test[1] = new int[] { 0, 1 };
            var result = CourseSchedule.CanFinish(2, test);
            Assert.False(result);
        }
    }
}
