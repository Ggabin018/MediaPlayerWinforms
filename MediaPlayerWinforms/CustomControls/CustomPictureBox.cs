using MediaToolkit.Model;
using MediaToolkit.Options;
using MediaToolkit;
using System.Diagnostics;

namespace MediaPlayerWinforms.CustomControls
{
    public class CustomPictureBox : PictureBox
    {
        private string _path;

        public CustomPictureBox(string videoPath, Size boxSize) : base()
        {
            _path = videoPath;
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
            Debug.WriteLine("CALL CustomPictureBox_Click");
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

            var inputFile = new MediaFile { Filename = videoPath };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                // Extract the middle frame
                var middleFrame = new MediaFile { Filename = middleFramePath };
                var middleTime = TimeSpan.FromSeconds(inputFile.Metadata.Duration.TotalSeconds / 2);
                engine.GetThumbnail(inputFile, middleFrame, new ConversionOptions { Seek = middleTime });
            }

            Debug.WriteLine($"Frames extracted successfully from {videoName}.");
            return middleFramePath;
        }
    }
}
