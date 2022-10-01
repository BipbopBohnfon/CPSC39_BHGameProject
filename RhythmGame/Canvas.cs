using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using static RhythmGame.KeyHandler;

namespace RhythmGame
{
    /// <summary>
    /// This is honestly pretty much the main, it controls the game loop and after the application starts, 
    /// this is the highest point in the heirarchy the thread ever returns to.
    /// </summary>
    public partial class Canvas : Form
    {
        EntityManager game = new EntityManager();
        Graphics renderer;
        TimeNBeat timer = new TimeNBeat();
        SoundPlayer sound = new SoundPlayer();
        GameTiming gameTime;
        long lastRender = 0;

        public Canvas()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 800;
        }

        private void Canvas_Load(object sender, EventArgs e)
        {
            sound.SoundLocation = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\brut.wav";
            GameStart();
        }

        /// <summary>
        /// Controls the game loop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            
            timer.UpdateTime();
            game.Update();
            renderer = e.Graphics;

            if (TimeNBeat.currentTime - lastRender > 6)
            {
                lastRender = TimeNBeat.currentTime;
                timer.FixedUpdateTime();
                Render(renderer);
            }

            Thread.Sleep(7);
            Invalidate();
        }

        /// <summary>
        /// Draws the frame
        /// </summary>
        /// <param name="renderer"></param>
        private void Render(Graphics renderer)
        {
            gameTime.Check(game);
            // Color, pen, and brushes need to be reinstantiated for each new frame's Graphics object
            Pen pen = new Pen(Color.Black);
            Color background = Color.FromArgb(230, 230, 230);
            Brush fill = new SolidBrush(Color.Red);
            Brush fill2 = new SolidBrush(Color.Blue);
            Brush fill3 = new SolidBrush(background);

            renderer.FillRectangle(fill3, 0, 0, 800, 800); // Background
            renderer.DrawEllipse(pen, 100, 100, 600, 600); // Arena

            for (short i = 0; i < game.entList.Count; i++)
            {
                if (game.entList[i] is Bullet)
                { // Pattern Matches Bullet
                    Bullet current = (Bullet)game.entList[i];
                    renderer.FillEllipse(fill, current.posx - 8, current.posy - 8, 16, 16);
                } else if (game.entList[i] is BulletSpawner)
                { // Pattern Matches BulletSpawner
                    BulletSpawner current = (BulletSpawner)game.entList[i];
                    renderer.FillPolygon(fill2, current.Points()); // Current.Points returns points of a trapezoid
                } else if (game.entList[i] is Player)
                { // Pattern Matches Player
                    Player current = (Player)game.entList[i];
                    renderer.FillEllipse(fill2, current.posx - 15, current.posy - 15, 30, 30);
                    if (current.isDead)
                    {
                        // Restarts Game
                        GameStart();
                    }
                }
            }
        }

        /// <summary>
        /// Restart the game or start it in the first place
        /// </summary>
        private void GameStart()
        {
            sound.Stop();
            timer.Reset();
            game = new EntityManager();
            gameTime = new GameTiming();
            sound.Play();
        }

        /// <summary>
        /// Tracks whether W A S and D are pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    KeyHandler.wChange(true);
                    break;
                case Keys.A:
                    KeyHandler.aChange(true);
                    break;
                case Keys.S:
                    KeyHandler.sChange(true);
                    break;
                case Keys.D:
                    KeyHandler.dChange(true);
                    break;
            }
                
        }

        /// <summary>
        /// Tracks whether W A S and D are released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    KeyHandler.wChange(false);
                    break;
                case Keys.A:
                    KeyHandler.aChange(false);
                    break;
                case Keys.S:
                    KeyHandler.sChange(false);
                    break;
                case Keys.D:
                    KeyHandler.dChange(false);
                    break;
            }
        }
    }
}
