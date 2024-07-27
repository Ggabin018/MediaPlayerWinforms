using Vlc.DotNet.Forms;

namespace MediaPlayerWinforms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            QueuePanel = new FlowLayoutPanel();
            ImageListQueue = new ImageList(components);
            timerMouseMovement = new System.Windows.Forms.Timer(components);
            playPictureBox = new PictureBox();
            menuStrip = new MenuStrip();
            médiaToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnFichierToolStripMenuItem = new ToolStripMenuItem();
            ouvrirPlusieursFichiersToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnDossierToolStripMenuItem = new ToolStripMenuItem();
            lectureToolStripMenuItem = new ToolStripMenuItem();
            lireToolStripMenuItem = new ToolStripMenuItem();
            arrêterToolStripMenuItem = new ToolStripMenuItem();
            précedentToolStripMenuItem = new ToolStripMenuItem();
            suivantToolStripMenuItem = new ToolStripMenuItem();
            audioToolStripMenuItem = new ToolStripMenuItem();
            augmenterLeVolumeToolStripMenuItem = new ToolStripMenuItem();
            réduireLeVolumeToolStripMenuItem = new ToolStripMenuItem();
            couperLeSonToolStripMenuItem = new ToolStripMenuItem();
            vidéoToolStripMenuItem = new ToolStripMenuItem();
            pleinÉcranToolStripMenuItem = new ToolStripMenuItem();
            panelMediaControl = new Panel();
            labelTest = new Label();
            mediaPlayerSlider = new CustomControls.CustomSlider();
            queuePictureBox = new PictureBox();
            stopPictureBox = new PictureBox();
            timeWithProgressBar = new Panel();
            labelTotalMediaTime = new Label();
            labelCurrentMediaTime = new Label();
            mediaCustomProgressBar = new CustomControls.CustomProgressBar();
            updateMediaTime = new System.Windows.Forms.Timer(components);
            windowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)playPictureBox).BeginInit();
            menuStrip.SuspendLayout();
            panelMediaControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).BeginInit();
            timeWithProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)windowsMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // QueuePanel
            // 
            QueuePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            QueuePanel.BackColor = Color.Honeydew;
            QueuePanel.Dock = DockStyle.Right;
            QueuePanel.Location = new Point(718, 24);
            QueuePanel.Name = "QueuePanel";
            QueuePanel.Size = new Size(164, 425);
            QueuePanel.TabIndex = 5;
            // 
            // ImageListQueue
            // 
            ImageListQueue.ColorDepth = ColorDepth.Depth32Bit;
            ImageListQueue.ImageSize = new Size(16, 16);
            ImageListQueue.TransparentColor = Color.Transparent;
            // 
            // timerMouseMovement
            // 
            timerMouseMovement.Enabled = true;
            timerMouseMovement.Interval = 1000;
            timerMouseMovement.Tick += timerMouvementMouse_Tick;
            // 
            // playPictureBox
            // 
            playPictureBox.BackColor = Color.DimGray;
            playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            playPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            playPictureBox.Location = new Point(3, 71);
            playPictureBox.Name = "playPictureBox";
            playPictureBox.Size = new Size(25, 25);
            playPictureBox.TabIndex = 9;
            playPictureBox.TabStop = false;
            playPictureBox.Click += playPictureBox_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { médiaToolStripMenuItem, lectureToolStripMenuItem, audioToolStripMenuItem, vidéoToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(882, 24);
            menuStrip.TabIndex = 10;
            menuStrip.Text = "menuStrip";
            // 
            // médiaToolStripMenuItem
            // 
            médiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ouvrirUnFichierToolStripMenuItem, ouvrirPlusieursFichiersToolStripMenuItem, ouvrirUnDossierToolStripMenuItem });
            médiaToolStripMenuItem.Name = "médiaToolStripMenuItem";
            médiaToolStripMenuItem.Size = new Size(52, 20);
            médiaToolStripMenuItem.Text = "Média";
            // 
            // ouvrirUnFichierToolStripMenuItem
            // 
            ouvrirUnFichierToolStripMenuItem.Name = "ouvrirUnFichierToolStripMenuItem";
            ouvrirUnFichierToolStripMenuItem.Size = new Size(207, 22);
            ouvrirUnFichierToolStripMenuItem.Text = "Ouvrir un fichier...";
            ouvrirUnFichierToolStripMenuItem.Click += ouvrirUnFichierToolStripMenuItem_Click;
            // 
            // ouvrirPlusieursFichiersToolStripMenuItem
            // 
            ouvrirPlusieursFichiersToolStripMenuItem.Name = "ouvrirPlusieursFichiersToolStripMenuItem";
            ouvrirPlusieursFichiersToolStripMenuItem.Size = new Size(207, 22);
            ouvrirPlusieursFichiersToolStripMenuItem.Text = "Ouvrir plusieurs fichiers...";
            // 
            // ouvrirUnDossierToolStripMenuItem
            // 
            ouvrirUnDossierToolStripMenuItem.Name = "ouvrirUnDossierToolStripMenuItem";
            ouvrirUnDossierToolStripMenuItem.Size = new Size(207, 22);
            ouvrirUnDossierToolStripMenuItem.Text = "Ouvrir un dossier...";
            // 
            // lectureToolStripMenuItem
            // 
            lectureToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lireToolStripMenuItem, arrêterToolStripMenuItem, précedentToolStripMenuItem, suivantToolStripMenuItem });
            lectureToolStripMenuItem.Name = "lectureToolStripMenuItem";
            lectureToolStripMenuItem.Size = new Size(58, 20);
            lectureToolStripMenuItem.Text = "Lecture";
            // 
            // lireToolStripMenuItem
            // 
            lireToolStripMenuItem.Name = "lireToolStripMenuItem";
            lireToolStripMenuItem.Size = new Size(127, 22);
            lireToolStripMenuItem.Text = "Lire";
            // 
            // arrêterToolStripMenuItem
            // 
            arrêterToolStripMenuItem.Name = "arrêterToolStripMenuItem";
            arrêterToolStripMenuItem.Size = new Size(127, 22);
            arrêterToolStripMenuItem.Text = "Arrêter";
            // 
            // précedentToolStripMenuItem
            // 
            précedentToolStripMenuItem.Name = "précedentToolStripMenuItem";
            précedentToolStripMenuItem.Size = new Size(127, 22);
            précedentToolStripMenuItem.Text = "Précedent";
            // 
            // suivantToolStripMenuItem
            // 
            suivantToolStripMenuItem.Name = "suivantToolStripMenuItem";
            suivantToolStripMenuItem.Size = new Size(127, 22);
            suivantToolStripMenuItem.Text = "Suivant";
            // 
            // audioToolStripMenuItem
            // 
            audioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { augmenterLeVolumeToolStripMenuItem, réduireLeVolumeToolStripMenuItem, couperLeSonToolStripMenuItem });
            audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            audioToolStripMenuItem.Size = new Size(51, 20);
            audioToolStripMenuItem.Text = "Audio";
            // 
            // augmenterLeVolumeToolStripMenuItem
            // 
            augmenterLeVolumeToolStripMenuItem.Name = "augmenterLeVolumeToolStripMenuItem";
            augmenterLeVolumeToolStripMenuItem.Size = new Size(189, 22);
            augmenterLeVolumeToolStripMenuItem.Text = "Augmenter le volume";
            // 
            // réduireLeVolumeToolStripMenuItem
            // 
            réduireLeVolumeToolStripMenuItem.Name = "réduireLeVolumeToolStripMenuItem";
            réduireLeVolumeToolStripMenuItem.Size = new Size(189, 22);
            réduireLeVolumeToolStripMenuItem.Text = "Réduire le volume";
            // 
            // couperLeSonToolStripMenuItem
            // 
            couperLeSonToolStripMenuItem.Name = "couperLeSonToolStripMenuItem";
            couperLeSonToolStripMenuItem.Size = new Size(189, 22);
            couperLeSonToolStripMenuItem.Text = "Couper le son";
            // 
            // vidéoToolStripMenuItem
            // 
            vidéoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pleinÉcranToolStripMenuItem });
            vidéoToolStripMenuItem.Name = "vidéoToolStripMenuItem";
            vidéoToolStripMenuItem.Size = new Size(49, 20);
            vidéoToolStripMenuItem.Text = "Vidéo";
            // 
            // pleinÉcranToolStripMenuItem
            // 
            pleinÉcranToolStripMenuItem.Name = "pleinÉcranToolStripMenuItem";
            pleinÉcranToolStripMenuItem.Size = new Size(132, 22);
            pleinÉcranToolStripMenuItem.Text = "Plein écran";
            // 
            // panelMediaControl
            // 
            panelMediaControl.BackColor = Color.DimGray;
            panelMediaControl.Controls.Add(labelTest);
            panelMediaControl.Controls.Add(mediaPlayerSlider);
            panelMediaControl.Controls.Add(queuePictureBox);
            panelMediaControl.Controls.Add(stopPictureBox);
            panelMediaControl.Controls.Add(playPictureBox);
            panelMediaControl.Controls.Add(timeWithProgressBar);
            panelMediaControl.Dock = DockStyle.Bottom;
            panelMediaControl.Location = new Point(0, 449);
            panelMediaControl.Name = "panelMediaControl";
            panelMediaControl.Size = new Size(882, 108);
            panelMediaControl.TabIndex = 11;
            // 
            // labelTest
            // 
            labelTest.AutoSize = true;
            labelTest.BackColor = Color.White;
            labelTest.Location = new Point(368, 71);
            labelTest.Name = "labelTest";
            labelTest.Size = new Size(26, 15);
            labelTest.TabIndex = 18;
            labelTest.Text = "test";
            // 
            // mediaPlayerSlider
            // 
            mediaPlayerSlider.Anchor = AnchorStyles.Right;
            mediaPlayerSlider.ForeColor = Color.White;
            mediaPlayerSlider.Location = new Point(745, 61);
            mediaPlayerSlider.Maximum = 125;
            mediaPlayerSlider.MediaPlayer = null;
            mediaPlayerSlider.Name = "mediaPlayerSlider";
            mediaPlayerSlider.Size = new Size(125, 35);
            mediaPlayerSlider.TabIndex = 17;
            mediaPlayerSlider.Value = 100;
            // 
            // queuePictureBox
            // 
            queuePictureBox.BackgroundImage = Properties.Resources.list_50px;
            queuePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            queuePictureBox.Location = new Point(65, 71);
            queuePictureBox.Name = "queuePictureBox";
            queuePictureBox.Size = new Size(25, 25);
            queuePictureBox.TabIndex = 14;
            queuePictureBox.TabStop = false;
            queuePictureBox.Click += queuePictureBox_Click;
            // 
            // stopPictureBox
            // 
            stopPictureBox.BackgroundImage = Properties.Resources.stop_50px;
            stopPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            stopPictureBox.Location = new Point(34, 71);
            stopPictureBox.Name = "stopPictureBox";
            stopPictureBox.Size = new Size(25, 25);
            stopPictureBox.TabIndex = 13;
            stopPictureBox.TabStop = false;
            stopPictureBox.Click += stopPictureBox_Click;
            // 
            // timeWithProgressBar
            // 
            timeWithProgressBar.Controls.Add(labelTotalMediaTime);
            timeWithProgressBar.Controls.Add(labelCurrentMediaTime);
            timeWithProgressBar.Controls.Add(mediaCustomProgressBar);
            timeWithProgressBar.Dock = DockStyle.Top;
            timeWithProgressBar.Location = new Point(0, 0);
            timeWithProgressBar.Name = "timeWithProgressBar";
            timeWithProgressBar.Size = new Size(882, 43);
            timeWithProgressBar.TabIndex = 16;
            // 
            // labelTotalMediaTime
            // 
            labelTotalMediaTime.BackColor = Color.White;
            labelTotalMediaTime.Dock = DockStyle.Right;
            labelTotalMediaTime.Location = new Point(833, 26);
            labelTotalMediaTime.Name = "labelTotalMediaTime";
            labelTotalMediaTime.Size = new Size(49, 17);
            labelTotalMediaTime.TabIndex = 11;
            labelTotalMediaTime.Text = "00:00:00";
            // 
            // labelCurrentMediaTime
            // 
            labelCurrentMediaTime.BackColor = Color.White;
            labelCurrentMediaTime.Dock = DockStyle.Left;
            labelCurrentMediaTime.Location = new Point(0, 26);
            labelCurrentMediaTime.Name = "labelCurrentMediaTime";
            labelCurrentMediaTime.Size = new Size(49, 17);
            labelCurrentMediaTime.TabIndex = 12;
            labelCurrentMediaTime.Text = "00:00:00";
            // 
            // mediaCustomProgressBar
            // 
            mediaCustomProgressBar.ChannelColor = Color.FromArgb(64, 64, 64);
            mediaCustomProgressBar.ChannelHeight = 10;
            mediaCustomProgressBar.Dock = DockStyle.Top;
            mediaCustomProgressBar.ForeBackColor = Color.Black;
            mediaCustomProgressBar.ForeColor = Color.White;
            mediaCustomProgressBar.Location = new Point(0, 0);
            mediaCustomProgressBar.MediaPlayer = null;
            mediaCustomProgressBar.Name = "mediaCustomProgressBar";
            mediaCustomProgressBar.ShowMaximun = false;
            mediaCustomProgressBar.ShowValue = CustomControls.TextPosition.None;
            mediaCustomProgressBar.Size = new Size(882, 26);
            mediaCustomProgressBar.SliderColor = Color.LightSeaGreen;
            mediaCustomProgressBar.SliderHeight = 10;
            mediaCustomProgressBar.SymbolAfter = "";
            mediaCustomProgressBar.SymbolBefore = "";
            mediaCustomProgressBar.TabIndex = 17;
            // 
            // updateMediaTime
            // 
            updateMediaTime.Enabled = true;
            updateMediaTime.Interval = 10;
            updateMediaTime.Tick += updateMediaTime_Tick;
            // 
            // windowsMediaPlayer
            // 
            windowsMediaPlayer.Dock = DockStyle.Fill;
            windowsMediaPlayer.Enabled = true;
            windowsMediaPlayer.Location = new Point(0, 24);
            windowsMediaPlayer.Name = "windowsMediaPlayer";
            windowsMediaPlayer.OcxState = (AxHost.State)resources.GetObject("windowsMediaPlayer.OcxState");
            windowsMediaPlayer.Size = new Size(718, 425);
            windowsMediaPlayer.TabIndex = 13;
            windowsMediaPlayer.DoubleClickEvent += windowsMediaPlayer_DoubleClickEvent;
            windowsMediaPlayer.MouseUpEvent += windowsMediaPlayer_MouseUpEvent;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(882, 557);
            Controls.Add(windowsMediaPlayer);
            Controls.Add(QueuePanel);
            Controls.Add(panelMediaControl);
            Controls.Add(menuStrip);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "MediaPlayer";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)playPictureBox).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelMediaControl.ResumeLayout(false);
            panelMediaControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).EndInit();
            timeWithProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)windowsMediaPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel QueuePanel;
        private ImageList ImageListQueue;
        private System.Windows.Forms.Timer timerMouseMovement;
        private PictureBox playPictureBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem médiaToolStripMenuItem;
        private ToolStripMenuItem lectureToolStripMenuItem;
        private ToolStripMenuItem audioToolStripMenuItem;
        private ToolStripMenuItem vidéoToolStripMenuItem;
        private Panel panelMediaControl;
        private Label labelCurrentMediaTime;
        private Label labelTotalMediaTime;
        private System.Windows.Forms.Timer updateMediaTime;
        private ToolStripMenuItem ouvrirUnFichierToolStripMenuItem;
        private ToolStripMenuItem ouvrirPlusieursFichiersToolStripMenuItem;
        private ToolStripMenuItem ouvrirUnDossierToolStripMenuItem;
        private ToolStripMenuItem lireToolStripMenuItem;
        private ToolStripMenuItem arrêterToolStripMenuItem;
        private ToolStripMenuItem précedentToolStripMenuItem;
        private ToolStripMenuItem suivantToolStripMenuItem;
        private ToolStripMenuItem augmenterLeVolumeToolStripMenuItem;
        private ToolStripMenuItem réduireLeVolumeToolStripMenuItem;
        private ToolStripMenuItem couperLeSonToolStripMenuItem;
        private ToolStripMenuItem pleinÉcranToolStripMenuItem;
        private PictureBox stopPictureBox;
        private PictureBox queuePictureBox;
        private Panel timeWithProgressBar;
        private CustomControls.CustomProgressBar mediaCustomProgressBar;
        private AxWMPLib.AxWindowsMediaPlayer windowsMediaPlayer;
        private CustomControls.CustomSlider mediaPlayerSlider;
        private Label labelTest;
    }
}
