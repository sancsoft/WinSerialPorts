using System;
using Tulpep.NotificationWindow;

namespace WinSerialPorts
{
    internal class SerialPopup : PopupNotifier
    {
        public SerialPopup(Image? image, String title, String content)
        {
            Size = new Size(250, 80);
            HeaderHeight = 15;
            ContentText = content;
            Delay = 5000;
            AnimationDuration = 100;
            ImagePadding = new Padding(15);
            TitlePadding = new Padding(10, 10, 10, 5);
            ContentPadding = new Padding(10, 5, 10, 10);
            Image = image;
            TitleText = title;
        }
    }
}
