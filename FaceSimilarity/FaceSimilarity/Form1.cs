using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceDetection
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private VideoCapture capture;
        private CascadeClassifier faceCascade;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop capturing frames and release resources
            if (capture != null && capture.IsOpened)
            {
                capture.Stop();
                capture.Dispose();
            }

            faceCascade?.Dispose();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            // Retrieve the current frame from the webcam
            using var frame = capture.QueryFrame().ToImage<Bgr, byte>();
            OriginalPic.Image = frame.ToBitmap();

            // Convert the frame to grayscale for face detection
            using (var grayFrame = frame.Convert<Gray, byte>())
            {
                // Perform face detection
                var faces = faceCascade.DetectMultiScale(
                    grayFrame,
                    scaleFactor: 1.3,
                    minNeighbors: 5,
                    minSize: new Size(30, 30),
                    maxSize: Size.Empty);


                List<Bitmap> faceBitmaps = new List<Bitmap>();

                // Draw rectangles around the detected faces
                foreach (var face in faces)
                {
                    frame.Draw(face, new Bgr(Color.Green), thickness: 2);
                    Rectangle faceRect = new(face.X, face.Y, face.Width, face.Height);

                    var faceImage = frame.Copy(faceRect).ToBitmap();
                    // picDebug.Image = faceImage;

                    faceBitmaps.Add(faceImage);
                }

                if (faces.Length == 2)
                {
                    Compare compare = new();
                    double result = compare.CompareImages(faceBitmaps[0], faceBitmaps[1]);
                    score.Text = "%" + result.ToString("F2");
                }

            }

            // Display the frame with detected faces
            DetectedPic.Image = frame.ToBitmap();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Initialize the webcam capture
            capture = new VideoCapture();

            // Load the pre-trained face detection model
            faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

            // Start capturing frames from the webcam
            Application.Idle += ProcessFrame;
        }
    }
}