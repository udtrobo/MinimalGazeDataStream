
namespace MinimalGazeDataStream
{
    using EyeXFramework;
    using System;
    using System.IO;
    using Tobii.EyeX.Framework;

    public static class Program
    {
       
            

        public static void Main(string[] args)
        {
             String GetTimestamp(DateTime value)
            {
                return value.ToString("HHmmssffff");
            }

            //String timeStamp = GetTimestamp(DateTime.Now);
            
            using (var eyeXHost = new EyeXHost())
            {
                // Create a data stream: lightly filtered gaze point data.
                // Other choices of data streams include EyePositionDataStream and FixationDataStream.
                using (var lightlyFilteredGazeDataStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered))
                {
                    // Start the EyeX host.
                    eyeXHost.Start();

                    // Write the data to the console.
                    lightlyFilteredGazeDataStream.Next += (s,e) => Console.WriteLine("{0:0.0}, {1:0.0},{2:0.0} ", e.X, e.Y, GetTimestamp(DateTime.Now));

                    FileStream ostrm;
                    StreamWriter writer;
                    TextWriter oldOut = Console.Out;
                    try
                    {
                        ostrm = new FileStream("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        writer = new StreamWriter(ostrm);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Cannot open Redirect.txt for writing");
                        Console.WriteLine(e.Message);
                        return;
                    }

                    // Let it run until a key is pressed.
                    Console.SetOut(writer);

                    //Console.WriteLine("Listening for gaze data, press any key to exit...");
                    Console.In.Read();
                    

                    //Console.WriteLine("Console.WriteLine() will be written to a file");
                   
                    Console.SetOut(oldOut);
                    writer.Close();
                    ostrm.Close();
                    //Console.WriteLine("Done");
                }
            }
        }
    }
}
