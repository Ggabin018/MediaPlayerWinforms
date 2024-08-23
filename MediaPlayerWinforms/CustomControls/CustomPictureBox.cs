using MediaToolkit.Model;
using MediaToolkit.Options;
using MediaToolkit;
using System.Diagnostics;
using System.Drawing;

namespace MediaPlayerWinforms.CustomControls
{
    public class CustomPictureBox : PictureBox
    {
        private string _videoPath;

        public string VideoPath { get => _videoPath; set => _videoPath = value; }

        public event Action<string> LoadAndPlay;

        public CustomPictureBox(string videoPath, Size boxSize) : base()
        {
            _videoPath = videoPath;
            Size = boxSize;
            BackColor = Color.Black;
            SizeMode = PictureBoxSizeMode.Zoom;
            string framePath = GetImageFromVideo(videoPath);
            Image = new Bitmap(framePath);
            Click += CustomPictureBox_Click;
            Tag = 1;
        }

        private void CustomPictureBox_Click(object? sender, EventArgs e)
        {
            LoadAndPlay(VideoPath);
        }

        private string GetImageFromVideo(string videoPath)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbDirectory = Path.Combine(appDataPath, "MediaPlayerWinforms");
            if (!Directory.Exists(dbDirectory))
                Directory.CreateDirectory(dbDirectory);
            string dbImagesDirectory = Path.Combine(dbDirectory, "Images");
            if (!Directory.Exists(dbImagesDirectory))
                Directory.CreateDirectory(dbImagesDirectory);

            string videoName = Path.GetFileNameWithoutExtension(videoPath);
            string dbVideoName = Path.GetFileName(Path.GetDirectoryName(videoPath));
            Debug.WriteLine(dbVideoName);
            string middleFramePath = Path.Combine(dbImagesDirectory, dbVideoName + "_" + videoName + ".png");
            
            if (File.Exists(middleFramePath))
                return middleFramePath;

            // create the demo img
            var inputFile = new MediaFile { Filename = videoPath };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                var middleFrame = new MediaFile { Filename = middleFramePath };
                var middleTime = TimeSpan.FromSeconds(inputFile.Metadata.Duration.TotalSeconds / 2);
                engine.GetThumbnail(inputFile, middleFrame, new ConversionOptions { Seek = middleTime });
            }

            // change the dimension of the img
            string imagePath = middleFramePath;
            int heightWanted = Size.Height;
            Bitmap resizedImage;
            using (Image originalImage = Image.FromFile(imagePath))
            {
                int newWidth = (originalImage.Width * heightWanted) / originalImage.Height;

                resizedImage = new Bitmap(newWidth, heightWanted);
                {
                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                    {
                        // Set high-quality interpolation mode for better quality
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                        graphics.DrawImage(originalImage, 0, 0, newWidth, heightWanted);
                    }
                }
            }
            File.Delete(imagePath);
            resizedImage.Save(imagePath);


            Debug.WriteLine($"Frames extracted successfully from {videoName}.");
            return middleFramePath;
        }
    }
}
