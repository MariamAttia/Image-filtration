
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
           
