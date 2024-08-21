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
            ImageListQueue = new ImageList(components);
            timerMouseMovement = new System.Windows.Forms.Timer(components);
            playPictureBox = new PictureBox();
            menuStrip = new MenuStrip();
            médiaToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnFichierToolStripMenuItem = new ToolStripMenuItem();
            ouvrirPlusieursFichiersToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnDossierToolStripMenuItem = new ToolStripMenuItem();
            historiqueToolStripMenuItem = new ToolStripMenuItem();
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
            optionsToolStripMenuItem = new ToolStripMenuItem();
            flushHistoryToolStripMenuItem = new ToolStripMenuItem();
            panelMediaControl = new Panel();
            NextPictureBox = new PictureBox();
            precedentPictureBox = new PictureBox();
            labelTest = new Label();
            mediaPlayerSlider = new CustomControls.CustomSlider();
            queuePictureBox = new PictureBox();
            stopPictureBox = new PictureBox();
            timeWithProgressBar = new Panel();
            labelTotalMediaTime = new Label();
            labelCurrentMediaTime = new Label();
            mediaCustomProgressBar = new CustomControls.CustomProgressBar();
            updateMediaTime = new System.Windows.Forms.Timer(components);
            customMediaPlayer = new CustomControls.CustomMediaPlayer();
            customQueuePanel = new CustomControls.CustomQueuePanel();
            ((System.ComponentModel.ISupportInitialize)playPictureBox).BeginInit();
            menuStrip.SuspendLayout();
            panelMediaControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NextPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precedentPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).BeginInit();
            timeWithProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customMediaPlayer).BeginInit();
            SuspendLayout();
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
            timerMouseMovement.Interval = 200;
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
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { médiaToolStripMenuItem, lectureToolStripMenuItem, audioToolStripMenuItem, vidéoToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(882, 24);
            menuStrip.TabIndex = 10;
            menuStrip.Text = "menuStrip";
            // 
            // médiaToolStripMenuItem
            // 
            médiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ouvrirUnFichierToolStripMenuItem, ouvrirPlusieursFichiersToolStripMenuItem, ouvrirUnDossierToolStripMenuItem, historiqueToolStripMenuItem });
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
            ouvrirPlusieursFichiersToolStripMenuItem.Click += ouvrirPlusieursFichiersToolStripMenuItem_Click;
            // 
            // ouvrirUnDossierToolStripMenuItem
            // 
            ouvrirUnDossierToolStripMenuItem.Name = "ouvrirUnDossierToolStripMenuItem";
            ouvrirUnDossierToolStripMenuItem.Size = new Size(207, 22);
            ouvrirUnDossierToolStripMenuItem.Text = "Ouvrir un dossier...";
            // 
            // historiqueToolStripMenuItem
            // 
            historiqueToolStripMenuItem.Name = "historiqueToolStripMenuItem";
            historiqueToolStripMenuItem.Size = new Size(207, 22);
            historiqueToolStripMenuItem.Text = "Historique";
            historiqueToolStripMenuItem.MouseHover += historiqueToolStripMenuItem_MouseHover;
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
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { flushHistoryToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(56, 20);
            optionsToolStripMenuItem.Text = "Option";
            // 
            // flushHistoryToolStripMenuItem
            // 
            flushHistoryToolStripMenuItem.Name = "flushHistoryToolStripMenuItem";
            flushHistoryToolStripMenuItem.Size = new Size(143, 22);
            flushHistoryToolStripMenuItem.Text = "Flush History";
            flushHistoryToolStripMenuItem.Click += flushHistoryToolStripMenuItem_Click;
            // 
            // panelMediaControl
            // 
            panelMediaControl.BackColor = Color.DimGray;
            panelMediaControl.Controls.Add(NextPictureBox);
            panelMediaControl.Controls.Add(precedentPictureBox);
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
            panelMediaControl.MouseEnter += panelMediaControl_MouseEnter;
            // 
            // NextPictureBox
            // 
            NextPictureBox.BackgroundImage = Properties.Resources.next_50;
            NextPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            NextPictureBox.Location = new Point(127, 71);
            NextPictureBox.Name = "NextPictureBox";
            NextPictureBox.Size = new Size(25, 25);
            NextPictureBox.TabIndex = 20;
            NextPictureBox.TabStop = false;
            NextPictureBox.Click += NextPictureBox_Click;
            // 
            // precedentPictureBox
            // 
            precedentPictureBox.BackgroundImage = Properties.Resources.precedent_50;
            precedentPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            precedentPictureBox.Location = new Point(96, 71);
            precedentPictureBox.Name = "precedentPictureBox";
            precedentPictureBox.Size = new Size(25, 25);
            precedentPictureBox.TabIndex = 19;
            precedentPictureBox.TabStop = false;
            precedentPictureBox.Click += precedentPictureBox_Click;
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
            mediaPlayerSlider.LabelDebug = labelTest;
            mediaPlayerSlider.Location = new Point(745, 61);
            mediaPlayerSlider.Maximum = 125;
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
            // customMediaPlayer
            // 
            customMediaPlayer.BackColor = Color.Black;
            customMediaPlayer.Dock = DockStyle.Fill;
            customMediaPlayer.Location = new Point(0, 24);
            customMediaPlayer.Name = "customMediaPlayer";
            customMediaPlayer.PositionSeconds = 0D;
            customMediaPlayer.Size = new Size(882, 425);
            customMediaPlayer.Spu = -1;
            customMediaPlayer.TabIndex = 12;
            customMediaPlayer.Text = "customMediaPlayer1";
            customMediaPlayer.VlcMediaplayerOptions = null;
            customMediaPlayer.EndReached += customMediaPlayer_EndReached;
            customMediaPlayer.Click += customMediaPlayer_Click;
            // 
            // customQueuePanel
            // 
            customQueuePanel.AutoScroll = true;
            customQueuePanel.AutoSize = true;
            customQueuePanel.BoxSize = new Size(200, 50);
            customQueuePanel.Dock = DockStyle.Right;
            customQueuePanel.Location = new Point(882, 24);
            customQueuePanel.MaxNumberOfPanel = 30;
            customQueuePanel.Name = "customQueuePanel";
            customQueuePanel.Size = new Size(0, 425);
            customQueuePanel.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(882, 557);
            Controls.Add(customQueuePanel);
            Controls.Add(customMediaPlayer);
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
            ((System.ComponentModel.ISupportInitialize)NextPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)precedentPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).EndInit();
            timeWithProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customMediaPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private CustomControls.CustomSlider mediaPlayerSlider;
        private Label labelTest;
        private ToolStripMenuItem historiqueToolStripMenuItem;
        private CustomControls.CustomMediaPlayer customMediaPlayer;
        private CustomControls.CustomQueuePanel customQueuePanel;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem flushHistoryToolStripMenuItem;
        private PictureBox precedentPictureBox;
        private PictureBox NextPictureBox;
    }
}
