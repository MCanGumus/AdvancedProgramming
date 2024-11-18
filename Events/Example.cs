using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class PathControl
    {
        public delegate void PathHandler(float sizeMB);
        public event PathHandler PathControlEvent;

        public async Task ControlPanel(string path)
        {
            while (true)
            {
                await Task.Delay(1000);
                DirectoryInfo directoryInfo = new(path);

                var files = directoryInfo.GetFiles();

                float size = await Task.Run(() => directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(f => f.Length));

                float sizeMB = (size / 1024) / 1024;

                if (sizeMB > 50)
                {
                    PathControlEvent(sizeMB);
                }
            }
        }
    }
}
