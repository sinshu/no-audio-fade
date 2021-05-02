using System;
using NAudio.Wave;

class Program
{
    static void Main(string[] args)
    {
        var format = new WaveFormat(16000, 16, 1);
        var silence = new SilenceProvider(format);

        using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
        {
            waveOut.Init(silence);
            waveOut.Play();

            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
    }
}
