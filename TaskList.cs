using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIMvsPSNR
{
    class Task
    {
        public List<TaskGroup> TaskGroups { get; set; }
        public bool finsihed;
    }

    class TaskGroup{
        public string GroupName{get;set;}
        public string OriginalImageFileName { get; set; }
        public List<TaskItem> TaskItems{get;set;}
        public bool Done { get; set; }
    }

    class TaskItem
    {
        public string FileName { set; get; }
        public int BlurLevel { get; set; }
        public int NoiseLevel { get; set; }
        public int JpegLevel { get; set; }
        public double PSNR { get; set; }
        public double SSIM { get; set; }
    }
}
