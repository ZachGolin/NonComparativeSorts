namespace NonComparativeSorts
{
    public abstract class Sorts
    {
        public static void SimpleCountingSort(List<int> data)
        {
            int min = data.Min();
            int max = data.Max();
            int[] buckets = new int[max-min+1]; //one bucket for each possible value in the data range
            for (int k = 0; k < data.Count; k++)
            {
                buckets[data[k] - min]++;
            }
            int i = 0; //bucket index
            int j = 0; //data index
            while (i < buckets.Length)
            {
                if (buckets[i] > 0)
                {
                    data[j] = min + i;
                    buckets[i]--;
                    j++;
                }
                else
                {
                    i++;
                }
            }
        }

        public static void PigeonholeSort<T>(List<KeyValuePair<int, T>> data) //ugly ass pigeonhole sort lol
        {
            int min = int.MaxValue;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Key < min)
                { 
                    min = data[i].Key;
                }
            }
            int max = int.MinValue;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Key > max)
                {
                    max = data[i].Key;
                }
            }
            
            List<KeyValuePair<int, T>>[] buckets = new List<KeyValuePair<int, T>>[max - min + 1]; //one bucket for each possible value in the data range
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new();
            }
            for (int i = 0; i < data.Count; i++)
            {
                buckets[data[i].Key - min].Add(data[i]);
            }
            int n = 0; //bucket index
            int h = buckets[0].Count - 1; //index within bucket
            int k = 0; //data index
            while (n < buckets.Length)
            {
                if (h >= 0)
                {
                    data[k] = buckets[n][h];
                    k++;
                    h--;
                }
                else
                {
                    n++;
                    if (n >= buckets.Length) { break; }
                    h = buckets[n].Count - 1;
                }
            }
        }

        public static void BucketSort(List<int> data, uint bucketCount)
        {
            List<List<int>> buckets = new();
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new());
            }
            int min = data.Min();
            int max = data.Max();
            //divide the range into bucketCount segments, ideally of equal length
            int bucketWidth = (int)Math.Ceiling((double)(max - min + 1) / bucketCount);
            //int q = (max - min + 1) / bucketWidth;
            //int r = (max - min + 1) % bucketWidth;
            //if (max - min + 1 != (q * bucketWidth + r)) { throw new Exception("euclidean division disagrees with input range. check your math, nerd :3"); }
            for (int i = 0; i < data.Count; i++)
            {
                buckets[(data[i] - min)/bucketWidth].Add(data[i]);
            }
            foreach (List<int> bucket in buckets)
            {
                bucket.Sort();
            }
            int k = 0;
            for (int i = 0; i < buckets.Count; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    data[k] = buckets[i][j];
                    k++;
                }
            }
        }

        public static void RadixSort(List<int> data, int radixBase) //radix sort in base b
        {
            Func<int, int, int> DigitDecomposition = (n, d) => (n/(int)Math.Pow(radixBase, d)) % radixBase;
            int min = data.Min();
            for (int i = 0; i < data.Count; i++) //eliminate negatives by shifting values around
            {
                data[i] -= min;
            }

            List<List<int>> buckets = new();
            for (int i = 0; i < radixBase; i++)
            {
                buckets.Add(new());
            }

            
            for (int iterations = 0; iterations < (int)Math.Ceiling(Math.Log(data.Max(), radixBase)); iterations++)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    buckets[DigitDecomposition(data[i], iterations)].Add(data[i]);
                }
                int k = 0;
                for (int i = 0; i < buckets.Count; i++)
                {
                    for (int j = 0; j < buckets[i].Count; j++)
                    {
                        data[k] = buckets[i][j];
                        k++;
                    }
                }
                for (int i = 0; i < radixBase; i++)
                {
                    buckets[i].Clear();
                }
            }

            for (int i = 0; i < data.Count; i++) //restore original values by shifting everything back
            {
                data[i] += min;
            }
        }
    }
}
