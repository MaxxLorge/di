﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TagsCloudContainer.BitmapSaver
{
    public interface IBitmapSaver
    {
        public void Save(Bitmap bmp, string fullPathWithExt);
    }
}