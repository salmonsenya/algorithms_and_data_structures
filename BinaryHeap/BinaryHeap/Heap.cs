namespace BinaryHeap
{
    class Heap
    {
        public int[] heap;
        public int heapSize;

        public int[] InitHeap(int n)
        {
            this.heapSize = n;
            return new int[n];
        }
          
        // O(log(n)) просеивание вниз
        public void siftDown(int i)
        {
            int left, right, j;
            while (2*i+1 < heapSize)
            {
                left = 2 * i + 1;
                right = 2 * i + 2;
                j = left;

                if (right < heapSize && heap[right] < heap[left])
                {
                    j = right;
                }

                if (heap[j] > heap[i])
                {
                    break;
                }

                swap(i, j);
                i = j;
            }
        }

        // O(log(n)) проссеивание вверх
        public void siftUp(int i)
        {
            while (heap[i] < heap[(i - 1) / 2])
            {
                swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        // O(log(n)) добавление нового элемента
        public void Insert(int x)
        {
            var newHeap = InitHeap(heapSize + 1);
            for (int i = 0; i < heapSize; i++)
            {
                newHeap[i] = heap[i];
            }
            heap = newHeap;
            heapSize++;

            heap[heapSize - 1] = x;
            siftUp(heapSize - 1);
        }

        // O(log(n)) извлечение минимального элемента
        public int ExtractMin()
        {
            var min = heap[0];
            heap[0] = heap[heapSize - 1];
            heapSize--;
            siftDown(0);
            return min;
        }

        private void swap(int i, int j)
        {
            var temp = heap[j];
            heap[j] = heap[i];
            heap[i] = temp;
        }
    }
}
