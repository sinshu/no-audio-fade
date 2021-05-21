# No audio fade

I couldn't fix the audio fade-in issue on Windows in a decent way.  
So here is an ad-hoc solution to the issue.  
This program continuously generates silent audio signal so that the audio driver will never become the idle state.

```cs
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
```
