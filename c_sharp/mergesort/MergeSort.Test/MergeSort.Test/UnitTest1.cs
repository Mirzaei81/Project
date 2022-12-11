namespace MergeSort.Test
{
    [TestClass]
    public class UnitTest1
    {
        public static int[] testarray = new int[] { 2, 8, 1, 3, 6, 7, 5, 4 };
        MergeSortClass merge = new MergeSortClass();
        [TestMethod]
        public void TestMethod1()
        {
            int[] sorted = new int[] {1,2,3,4,5,6,7,8};
            merge.sort(testarray, 0, testarray.Length - 1);

            CollectionAssert.AreEqual(sorted,testarray);
        }
    }
}