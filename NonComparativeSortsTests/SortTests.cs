using NonComparativeSorts;

namespace NonComparativeSortsTests
{
    public class CountingSortTests
    {
        [Fact]
        public void SimpleCountingSort_Works()
        {
            List<int> unsorted = [1, 2, 6, 1, 7, 0, 9, 5, 2, -2, -2, 2, 9];
            List<int> expected = unsorted.ToList();
            List<int> sorted = unsorted.ToList();
            expected.Sort();
            Sorts.SimpleCountingSort(sorted);

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void PigeonholeSort_Works()
        {
            List<KeyValuePair<int, char>> unsorted = [new(1,'a'), new(2,'b'), new(6,'g'), new(1, 'a'), 
                                                      new(7,'h'), new(0,'$'), new(9,'i'), new(5,'e'), 
                                                      new(2, 'b'), new(-2,'y'), new(-2,'y'), new(2, 'b'), 
                                                      new(9, 'i')];
            List<KeyValuePair<int, char>> expected = unsorted.ToList();
            List<KeyValuePair<int, char>> sorted = unsorted.ToList();
            expected.Sort((a,b) => a.Key - b.Key);
            Sorts.PigeonholeSort(sorted);

            Assert.Equal(expected, sorted);
        }
    }
    public class BucketSortTests
    {
        [Fact]
        public void BucketSort_Works()
        {
            List<int> unsorted = [1, 2, 6, 1, 7, 0, 9, 5, 2, -2, -2, 2, 9];
            List<int> expected = unsorted.ToList();
            List<int> sorted = unsorted.ToList();
            expected.Sort();
            Sorts.BucketSort(sorted, 5);

            Assert.Equal(expected, sorted);
        }
    }
    public class RadixSortTests
    {
        [Fact]
        public void RadixSort_Works()
        {
            List<int> unsorted = [1, 2, 6, 1, 7, 0, 9, 5, 2, -2, -2, 2, 9];
            List<int> expected = unsorted.ToList();
            List<int> sorted = unsorted.ToList();
            expected.Sort();
            Sorts.RadixSort(sorted, 10);

            Assert.Equal(expected, sorted);
        }
    }
}
