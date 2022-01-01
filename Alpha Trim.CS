
 public static byte Filter1(byte[,] ImageMatrix,)
        {
            byte[] Array;
            int neighborno;
             int x;
             int y;
             
            int[] Dx, Dy;
            if (neighborno % 2 != 0)
            {
                Array = new byte[neighborno * neighborno];
                Dx = new int[neighborno * neighborno];
                Dy = new int[neighborno *neighborno];
            }
            else
            {
                Array = new byte[(neighborno + 1) * (neighborn + 1)];
                Dx = new int[(neighborno + 1) * (neighborno+ 1)];
                Dy = new int[(neighborno + 1) * (neighborno+ 1)];
            }
            int Index = 0;
            for (int y = -(neighborno / 2); y <= (neighborno/ 2); y++)
            {
                for (int x = -(neighborno / 2);x <= (neighborno / 2); x++)
                {
                    Dx[Index] = x;
                    Dy[Index] = y;
                    Index++;
                }
            }
            byte Max, Min, Z;
            int ArrayLength, Sum, NewY, NewX, Avg;
            Sum = 0;
            Max = 0;
            Min = 255;
            ArrayLength = 0;
            Z = ImageMatrix[y, x];
            for (int i = 0; i < neighborno * neighborno; i++)
            {
                NewY = y + Dy[i];
                NewX = x + Dx[i];
                if (NewX >= 0 && NewX < GetWidth(ImageMatrix) && NewY >= 0 && NewY < GetHeight(ImageMatrix))
                {
                    Array[ArrayLength] = ImageMatrix[NewY, NewX];
                    if (Array[ArrayLength] > Max)
                        Max = Array[ArrayLength];
                    if (Array[ArrayLength] < Min)
                        Min = Array[ArrayLength];
                    Sum += Array[ArrayLength];
                    ArrayLength++;
                }
            }
            
            Sum -= Max;
            Sum -= Min;
            ArrayLength -= 2;
            Avg = Sum / ArrayLength;
            return (byte)Avg;
            =================================================================================================================================
           

 
 // A C# program to find k'th smallest element using max heap
using System;
  
public class GFG {
  
    // A class for Max Heap
    public
  
        class MaxHeap {
        public
  
            int[] harr; // pointer to array of elements in
                        // heap
        public
  
            int capacity; // maximum possible size of max
                          // heap
        public
  
            int heap_size; // Current number of elements in
                           // max heap
  
        public
  
            int
            parent(int i)
        {
            return (i - 1) / 2;
        }
        public
  
            int
            left(int i)
        {
            return (2 * i + 1);
        }
        public
  
            int
            right(int i)
        {
            return (2 * i + 2);
        }
        public
  
            int
            getMax()
        {
            return harr[0];
        } // Returns maximum
  
        // to replace root with new node x and heapify() new
        // root
        public
  
            void
            replaceMax(int x)
        {
            this.harr[0] = x;
            maxHeapify(0);
        }
        public
  
            MaxHeap(int[] a, int size)
        {
            heap_size = size;
            harr = a; // store address of array
            int i = (heap_size - 1) / 2;
            while (i >= 0) {
                maxHeapify(i);
                i--;
            }
        }
  
        // Method to remove maximum element (or root) from
        // max heap
        public
  
            int
            extractMax()
        {
            if (heap_size == 0)
                return int.MaxValue;
  
            // Store the maximum vakue.
            int root = harr[0];
  
            // If there are more than 1 items, move the last
            // item to root and call heapify.
            if (heap_size > 1) {
                harr[0] = harr[heap_size - 1];
                maxHeapify(0);
            }
            heap_size--;
            return root;
        }
  
        // A recursive method to heapify a subtree with root
        // at given index This method assumes that the
        // subtrees are already heapified
        public
  
            void
            maxHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int largest = i;
            if (l < heap_size && harr[l] > harr[i])
                largest = l;
            if (r < heap_size && harr[r] > harr[largest])
                largest = r;
            if (largest != i) {
                int t = harr[i];
                harr[i] = harr[largest];
                harr[largest] = t;
                maxHeapify(largest);
            }
        }
    };
  
    // Function to return k'th largest element in a given
    // array
    int kthSmallest(int[] arr, int n, int k)
    {
  
        // Build a heap of first k elements: O(k) time
        MaxHeap mh = new MaxHeap(arr, k);
  
        // Process remaining n-k elements.  If current
        // element is smaller than root, replace root with
        // current element
        for (int i = k; i < n; i++)
            if (arr[i] < mh.getMax())
                mh.replaceMax(arr[i]);
  
        // Return root
        return mh.getMax();
    }
  
    // Driver code
    public static void Main(String[] args)
    {
        int[] arr = { 12, 3, 5, 7, 19 };
        int n = arr.Length, k = 4;
        GFG gfg = new GFG();
        Console.Write("K'th smallest element is "
                      + gfg.kthSmallest(arr, n, k));
    }
}
  
// This code is contributed by gauravrajput1
