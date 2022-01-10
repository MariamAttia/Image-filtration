using System;

public class Class1
{
	public Class1()
	{



        public static Bitmap Filter(this Bitmap image, int rmax)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            int r = 3;
            int wres = w - 2 * r;
            int hres = h - 2 * r;
            Bitmap result_image = new Bitmap(wres, hres);
            BitmapData result_data = result_image.LockBits(
                new Rectangle(0, 0, wres, hres),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            int res_bytes = result_data.Stride * result_data.Height;
            byte[] result = new byte[res_bytes];

            for (int x = r; x < w - r; x++)
            {
                for (int y = r; y < h - r; y++)
                {
                    int pixel_location = x * 3 + y * image_data.Stride;
                    int res_pixel_loc = (x - r) * 3 + (y - r) * result_data.Stride;
                    byte[][] neighborhood = new byte[3][];

                    for (int c = 0; c < 3; c++)
                    {
                        neighborhood[c] = new byte[(int)Math.Pow(2 * r + 1, 2)];
                        int added = 0;

                        for (int kx = -r; kx <= r; kx++)
                        {
                            for (int ky = -r; ky <= r; ky++)
                            {
                                int kernel_pixel = pixel_location + kx * 3 + ky * image_data.Stride;
                                neighborhood[c][added] = buffer[kernel_pixel + c];
                                added++;
                            }
                        }
                    }

                    for (int c = 0; c < 3; c++)
                    {
                        if (neighborhood[c].median() > neighborhood[c].Min() && neighborhood[c].median() < neighborhood[c].Max())
                        {
                            if (neighborhood[c].Min() < buffer[pixel_location + c] && buffer[pixel_location + c] < neighborhood[c].Max())
                            {
                                result[res_pixel_loc + c] = buffer[pixel_location + c];
                            }

                            else
                            {
                                result[res_pixel_loc + c] = (byte)neighborhood[c].median();
                            }
                        }

                        else
                        {
                            r++;
                            x = r;
                            y = r;

                            if (r > rmax)
                            {
                                result[res_pixel_loc + c] = (byte)neighborhood[c].median();
                            }
                        }
                    }
                }
            }

            Marshal.Copy(result, 0, result_data.Scan0, res_bytes);
            result_image.UnlockBits(result_data);
            return result_image;
        }




    }
}
