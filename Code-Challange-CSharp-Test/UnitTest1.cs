using Code_Challange_CSharp.LeetCode;

namespace Code_Challange_CSharp_Test
{
    public class UnitTest1
    {
        [Fact]
        public void CanFinishTest()
        {
            var test = new int[1][];
            test[0] = new int[] { 1 , 0};
            test[1] = new int[] { 0, 1 };
            var result = CourseSchedule.CanFinish(2 , test);
            Assert.False(result);
        }
    }
}