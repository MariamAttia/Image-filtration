using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    namespace algoProject
    {
        internal class CountSort
        { 
                public int[] countSort( int[] arr) 
            {
                int[] sortedArr = new int[arr.Length];

                

                // get the maximum element of the array 
             
                int maxElement = arr[0];
       
              for ( int i=1;i<arr.Length;i++)
                { 
                    if ( arr[i] >maxElement)
                    {
                    
                        maxElement = arr[i];

                    }

                } 


             

                // make a new array called count to count the no of occurences of each unique element 
                int[] count = new int[maxElement + 1];
                 Array.Clear(count, 0, count.Length);//intializes  the count arr by zeros 
                // store the count of each element 
                for ( int i=0; i<arr.Length;i++)
                {
                
                        count[arr[i]]++; 
               

                }
              

                // store the cummilative count of the count array
                for (int i = 1; i < count.Length; i++)
                {
                    count[i] += count[i - 1];

                }
                // Find the index of each element of the original array in count array, and
                // place the elements in output array
                for ( int i=0;i< arr.Length;i++)
                {
                    sortedArr[count[arr[i]] - 1] = arr[i];
                    count[arr[i]] -= 1;
                }

              
                return sortedArr ;

            }




        } 
    }
