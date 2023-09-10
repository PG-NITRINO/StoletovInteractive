using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;


namespace Stoletov_4_0
{
    public partial class Base_Form : Form
    {
        /// Обязательная переменная конструктора.
        private System.ComponentModel.IContainer components = null;
        private int w = 0, h = 0;   //Разрешение экрана
        private int w2 = 0, h2 = 0;  //Центр экрана

        public Base_Form()
        {
            w = SystemInformation.PrimaryMonitorSize.Width;
            h = SystemInformation.PrimaryMonitorSize.Height;
            w2 = w / 2;
            h2 = h / 2;

            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(w, h);

            generateMenu();
            generateInfoPanel();    //Генирируется раньше, чтобы быть поверх панелей
            generateNewMap();
            generateOldMap();
            generateNewVladimirMap();
            generateOldVladimirMap();
            generateTimer();
            OnMenu();
        }


        /* Инициализация формы */
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Base_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImage = global::Stoletov_4_0.Properties.Resources.grey;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Base_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base_Form";
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Timer Info_timer;  //Таймер для информационных окон

        private void generateTimer()
        {
            this.Info_timer = new System.Windows.Forms.Timer();
            this.Info_timer.Enabled = false;
            this.Info_timer.Interval = 1;
            this.Info_timer.Tick += new System.EventHandler(this.Info_Timer_Tick);
        }


        private System.Windows.Forms.Panel Menu_panel;
        private System.Windows.Forms.PictureBox pictureBox_Exit;
        private System.Windows.Forms.PictureBox pictureBox_LeftTablet;
        private System.Windows.Forms.PictureBox pictureBox_RightTablet;
        private System.Windows.Forms.PictureBox pictureBox_NewMap;
        private System.Windows.Forms.PictureBox pictureBox_OldMap;
        private System.Windows.Forms.PictureBox pictureBox_FrameNewMap;
        private System.Windows.Forms.PictureBox pictureBox_FrameOldMap;
        private System.Windows.Forms.Label Left_text;
        private System.Windows.Forms.Label Right_text;

        private void generateMenu()
        {
            /* Создаём объекты */
            this.pictureBox_LeftTablet = new System.Windows.Forms.PictureBox();
            this.pictureBox_RightTablet = new System.Windows.Forms.PictureBox();
            this.pictureBox_NewMap = new System.Windows.Forms.PictureBox();
            this.pictureBox_OldMap = new System.Windows.Forms.PictureBox();
            this.pictureBox_FrameNewMap = new System.Windows.Forms.PictureBox();
            this.pictureBox_FrameOldMap = new System.Windows.Forms.PictureBox();
            this.pictureBox_Exit = new System.Windows.Forms.PictureBox();
            this.Menu_panel = new System.Windows.Forms.Panel();
            this.Left_text = new System.Windows.Forms.Label();
            this.Right_text = new System.Windows.Forms.Label();



            /* Присостанавливаем на время изменений*/
            this.Menu_panel.SuspendLayout();
            this.Left_text.SuspendLayout();
            this.Right_text.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LeftTablet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RightTablet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FrameNewMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FrameOldMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldMap)).BeginInit();
            this.SuspendLayout();


            /* pictureBox_LeftTablet */
            this.pictureBox_LeftTablet.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_LeftTablet.BackgroundImage = global::Stoletov_4_0.Properties.Resources.табличка;
            this.pictureBox_LeftTablet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает

            this.pictureBox_LeftTablet.Size = new System.Drawing.Size((int)(w / 2.4), (int)(h / 4.666));
            this.pictureBox_LeftTablet.Location = new System.Drawing.Point(w / 2 - this.pictureBox_LeftTablet.Size.Width - 20,
                                                                           h / 2 - (int)(this.pictureBox_LeftTablet.Size.Height * 1.5));     //Левый верхний угол
            this.pictureBox_LeftTablet.Name = "pictureBox_LeftTablet";
            this.pictureBox_LeftTablet.TabIndex = 0;
            this.pictureBox_LeftTablet.TabStop = false;


            /* pictureBox_RightTablet */
            this.pictureBox_RightTablet.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_RightTablet.BackgroundImage = global::Stoletov_4_0.Properties.Resources.табличка;
            this.pictureBox_RightTablet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает

            this.pictureBox_RightTablet.Size = new System.Drawing.Size((int)(w / 2.4), (int)(h / 4.666));
            this.pictureBox_RightTablet.Location = new System.Drawing.Point(w / 2 + 20,
                                                                            h / 2 - (int)(this.pictureBox_LeftTablet.Size.Height * 1.5));     //Левый верхний угол
            this.pictureBox_RightTablet.Name = "pictureBox_RightTablet";
            this.pictureBox_RightTablet.TabIndex = 0;
            this.pictureBox_RightTablet.TabStop = false;


            /* pictureBox_NewMap */
            this.pictureBox_NewMap.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_NewMap.BackgroundImage = global::Stoletov_4_0.Properties.Resources.big;
            this.pictureBox_NewMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает

            this.pictureBox_NewMap.Size = new System.Drawing.Size((int)(w / 2.4), (int)(h / 2.4));
            this.pictureBox_NewMap.Location = new System.Drawing.Point(w / 2 - this.pictureBox_NewMap.Size.Width - 20,
                                                                           h / 2 - (int)(this.pictureBox_LeftTablet.Size.Height * 0.5));//Левый верхний угол
            this.pictureBox_NewMap.Name = "pictureBox_NewMap";
            this.pictureBox_NewMap.TabIndex = 0;
            this.pictureBox_NewMap.TabStop = false;

            this.pictureBox_NewMap.Click += new System.EventHandler(this.pictureBox_NewMap_Click);          // Нажатие на современную карту
            this.pictureBox_NewMap.MouseEnter += new System.EventHandler(this.pictureBox_NewMap_Enter);     // Наводим мышь на современную карту
            this.pictureBox_NewMap.MouseLeave += new System.EventHandler(this.pictureBox_NewMap_Leave);     // Убираем мышь с современной карты


            /* pictureBox_OldMap */
            this.pictureBox_OldMap.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldMap.BackgroundImage = global::Stoletov_4_0.Properties.Resources.map_1914;
            this.pictureBox_OldMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает

            this.pictureBox_OldMap.Size = new System.Drawing.Size((int)(w / 2.4), (int)(h / 2.4));
            this.pictureBox_OldMap.Location = new System.Drawing.Point(w / 2 + 20,
                                                                            h / 2 - (int)(this.pictureBox_LeftTablet.Size.Height * 0.5));//Левый верхний угол
            this.pictureBox_OldMap.Name = "pictureBox_OldMap";
            this.pictureBox_OldMap.TabIndex = 0;
            this.pictureBox_OldMap.TabStop = false;

            this.pictureBox_OldMap.Click += new System.EventHandler(this.pictureBox_OldMap_Click);  // Нажатие на старую карту
            this.pictureBox_OldMap.MouseEnter += new System.EventHandler(this.pictureBox_OldMap_Enter);     // Наводим мышь на старую карту
            this.pictureBox_OldMap.MouseLeave += new System.EventHandler(this.pictureBox_OldMap_Leave);     // Убираем мышь со старой карты


            /* pictureBox_FrameNewMap */
            this.pictureBox_FrameNewMap.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_FrameNewMap.BackgroundImage = global::Stoletov_4_0.Properties.Resources.рамка_чёрный_внутрь;
            this.pictureBox_FrameNewMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;         //Растягивает

            this.pictureBox_FrameNewMap.Size = new System.Drawing.Size(this.pictureBox_NewMap.Size.Width, this.pictureBox_NewMap.Size.Height);
            this.pictureBox_FrameNewMap.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_FrameNewMap.Name = "pictureBox_FrameNewMap";
            this.pictureBox_FrameNewMap.TabIndex = 0;
            this.pictureBox_FrameNewMap.TabStop = false;
            this.pictureBox_FrameNewMap.Visible = false;    //Изначально не видно
            this.pictureBox_FrameNewMap.Enabled = false;


            /* pictureBox_FrameOldMap */
            this.pictureBox_FrameOldMap.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_FrameOldMap.BackgroundImage = global::Stoletov_4_0.Properties.Resources.рамка_чёрный_внутрь;
            this.pictureBox_FrameOldMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;         //Растягивает

            this.pictureBox_FrameOldMap.Size = new System.Drawing.Size(this.pictureBox_OldMap.Size.Width, this.pictureBox_OldMap.Size.Height);
            this.pictureBox_FrameOldMap.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_FrameOldMap.Name = "pictureBox_FrameOldMap";
            this.pictureBox_FrameOldMap.TabIndex = 0;
            this.pictureBox_FrameOldMap.TabStop = false;
            this.pictureBox_FrameOldMap.Visible = false;    //Изначально не видно
            this.pictureBox_FrameOldMap.Enabled = false;


            /*pictureBox_Exit*/
            this.pictureBox_Exit.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_Exit.BackgroundImage = global::Stoletov_4_0.Properties.Resources.крест_красный;
            this.pictureBox_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_Exit.Location = new System.Drawing.Point(w - 50, 0);
            this.pictureBox_Exit.Name = "pictureBox_Exit";
            this.pictureBox_Exit.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Exit.TabIndex = 0;
            this.pictureBox_Exit.TabStop = false;

            this.pictureBox_Exit.Click += new System.EventHandler(this.pictureBox_Exit_Click);  // Нажатие на крестик


            /* Left_text */
            this.Left_text.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
            this.Left_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Left_text.MaximumSize = new System.Drawing.Size((int)(this.pictureBox_LeftTablet.Size.Width * 0.8), (int)(this.pictureBox_LeftTablet.Size.Height * 0.8));
            this.Left_text.Name = "Left_text";
            this.Left_text.Size = new System.Drawing.Size((int)(this.pictureBox_LeftTablet.Size.Width * 0.8), (int)(this.pictureBox_LeftTablet.Size.Height * 0.8));
            this.Left_text.Location = new System.Drawing.Point((int)(this.pictureBox_LeftTablet.Size.Width * 0.1), (int)(this.pictureBox_LeftTablet.Size.Height * 0.1));
            this.Left_text.TabIndex = 4;
            this.Left_text.Text = "Память Александра Григорьевича и Николая Григорьевича Столетовых";
            this.Left_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


            /* Right_text */
            this.Right_text.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
            this.Right_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Right_text.MaximumSize = new System.Drawing.Size((int)(this.pictureBox_RightTablet.Size.Width * 0.8), (int)(this.pictureBox_RightTablet.Size.Height * 0.8));
            this.Right_text.Name = "Right_text";
            this.Right_text.Size = new System.Drawing.Size((int)(this.pictureBox_RightTablet.Size.Width * 0.8), (int)(this.pictureBox_RightTablet.Size.Height * 0.8));
            this.Right_text.Location = new System.Drawing.Point((int)(this.pictureBox_RightTablet.Size.Width * 0.1), (int)(this.pictureBox_RightTablet.Size.Height * 0.1));
            this.Right_text.TabIndex = 4;
            this.Right_text.Text = "Жизнь Александра Григорьевича и Николая Григорьевича Столетовых";
            this.Right_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


            /* Menu_panel */
            this.Menu_panel.BackgroundImage = global::Stoletov_4_0.Properties.Resources.grey;
            this.Menu_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;    //Растягивается
            this.Menu_panel.Dock = System.Windows.Forms.DockStyle.Fill;                       //Заполняет форму
            this.Menu_panel.Location = new System.Drawing.Point(0, 0);
            this.Menu_panel.Name = "Menu_panel";
            this.Menu_panel.TabIndex = 0;

            this.Menu_panel.Visible = false;    // Изначально отключаем
            this.Menu_panel.Enabled = false;


            /* Добавление в форму */
            this.Menu_panel.Controls.Add(this.pictureBox_LeftTablet);
            this.Menu_panel.Controls.Add(this.pictureBox_RightTablet);
            this.Menu_panel.Controls.Add(this.pictureBox_NewMap);
            this.Menu_panel.Controls.Add(this.pictureBox_OldMap);
            this.Menu_panel.Controls.Add(this.pictureBox_Exit);
            this.pictureBox_NewMap.Controls.Add(this.pictureBox_FrameNewMap);
            this.pictureBox_OldMap.Controls.Add(this.pictureBox_FrameOldMap);
            this.pictureBox_LeftTablet.Controls.Add(this.Left_text);
            this.pictureBox_RightTablet.Controls.Add(this.Right_text);
            this.Controls.Add(this.Menu_panel);         //Панель в форме


            /* Все изменения внесены - убираем остановку */
            this.Menu_panel.ResumeLayout(false);
            this.Left_text.ResumeLayout(false);
            this.Right_text.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LeftTablet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RightTablet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FrameNewMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FrameOldMap)).EndInit();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.Panel NewMap_panel;
        private System.Windows.Forms.PictureBox pictureBox_NewMapBackMenu;
        private System.Windows.Forms.PictureBox pictureBox_Moscow;
        private System.Windows.Forms.PictureBox pictureBox_Sofia;
        private System.Windows.Forms.PictureBox pictureBox_Vladimir;

        private void generateNewMap()
        {
            /* Создаём объекты */
            this.NewMap_panel = new System.Windows.Forms.Panel();
            this.pictureBox_NewMapBackMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox_Moscow = new System.Windows.Forms.PictureBox();
            this.pictureBox_Sofia = new System.Windows.Forms.PictureBox();
            this.pictureBox_Vladimir = new System.Windows.Forms.PictureBox();


            /* Присостанавливаем на время изменений*/
            this.NewMap_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewMapBackMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Moscow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Sofia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Vladimir)).BeginInit();
            this.SuspendLayout();


            /* pictureBox_Vladimir */
            this.pictureBox_Vladimir.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_Vladimir.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель2;
            this.pictureBox_Vladimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_Vladimir.Size = new System.Drawing.Size(90, 126);
            this.pictureBox_Vladimir.Location = new System.Drawing.Point((int)(w / 2.8), (int)(h / 2.33333));
            this.pictureBox_Vladimir.Name = "pictureBox_Vladimir";
            this.pictureBox_Vladimir.TabIndex = 0;
            this.pictureBox_Vladimir.TabStop = false;

            this.pictureBox_Vladimir.Click += new System.EventHandler(this.pictureBox_Vladimir_Click);  // Нажатие на метку Владимира


            /* pictureBox_Moscow */
            this.pictureBox_Moscow.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_Moscow.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_Moscow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_Moscow.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_Moscow.Location = new System.Drawing.Point((int)(w / 3.2), (int)(h / 2.33333));
            this.pictureBox_Moscow.Name = "pictureBox_Moscow";
            this.pictureBox_Moscow.TabIndex = 0;
            this.pictureBox_Moscow.TabStop = false;

            this.pictureBox_Moscow.Click += new System.EventHandler(this.pictureBox_Moscow_Click);  // Нажатие на метку Москвы


            /* pictureBox_Sofia */
            this.pictureBox_Sofia.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_Sofia.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_Sofia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_Sofia.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_Sofia.Location = new System.Drawing.Point((int)(w / 4.869), (int)(h / 1.522));
            this.pictureBox_Sofia.Name = "pictureBox_Sofia";
            this.pictureBox_Sofia.TabIndex = 0;
            this.pictureBox_Sofia.TabStop = false;

            this.pictureBox_Sofia.Click += new System.EventHandler(this.pictureBox_Sofia_Click);  // Нажатие на метку Софии


            /* pictureBox_NewMapBackMenu */
            this.pictureBox_NewMapBackMenu.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_NewMapBackMenu.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_деревянный;
            this.pictureBox_NewMapBackMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_NewMapBackMenu.Size = new System.Drawing.Size((int)(w / 8), (int)(h / 7));
            this.pictureBox_NewMapBackMenu.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_NewMapBackMenu.Name = "pictureBox_NewMapBackMenu";
            this.pictureBox_NewMapBackMenu.TabIndex = 0;
            this.pictureBox_NewMapBackMenu.TabStop = false;

            this.pictureBox_NewMapBackMenu.Click += new System.EventHandler(this.pictureBox_NewMapBackMenu_Click);  // Нажатие назад

            /* NewMap_panel */
            this.NewMap_panel.BackgroundImage = global::Stoletov_4_0.Properties.Resources.big;
            this.NewMap_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;    //Растягивается
            this.NewMap_panel.Dock = System.Windows.Forms.DockStyle.Fill;                       //Заполняет форму
            this.NewMap_panel.Location = new System.Drawing.Point(0, 0);
            this.NewMap_panel.Name = "NewMap_panel";
            this.NewMap_panel.TabIndex = 0;

            this.NewMap_panel.Visible = false;    // Изначально отключаем
            this.NewMap_panel.Enabled = false;

            //generateInfoPanel();        //Создаём информационное окно, чтобы оно было поверх всех окон

            /* Добавление в форму */
            this.NewMap_panel.Controls.Add(this.pictureBox_NewMapBackMenu);
            this.NewMap_panel.Controls.Add(this.pictureBox_Moscow);
            this.NewMap_panel.Controls.Add(this.pictureBox_Sofia);
            this.NewMap_panel.Controls.Add(this.pictureBox_Vladimir);
            this.Controls.Add(this.NewMap_panel);         //Панель в форме

            /* Все изменения внесены - убираем остановку */
            this.NewMap_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewMapBackMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Moscow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Sofia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Vladimir)).EndInit();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.Panel OldMap_panel;
        private System.Windows.Forms.PictureBox pictureBox_OldMapBackMenu;
        private System.Windows.Forms.PictureBox pictureBox_OldMoscow;
        private System.Windows.Forms.PictureBox pictureBox_OldAfgan;
        private System.Windows.Forms.PictureBox pictureBox_OldVladimir;

        private void generateOldMap()
        {
            /* Создаём объекты */
            this.OldMap_panel = new System.Windows.Forms.Panel();
            this.pictureBox_OldMapBackMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox_OldMoscow = new System.Windows.Forms.PictureBox();
            this.pictureBox_OldAfgan = new System.Windows.Forms.PictureBox();
            this.pictureBox_OldVladimir = new System.Windows.Forms.PictureBox();


            /* Присостанавливаем на время изменений*/
            this.OldMap_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldMapBackMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldMoscow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldAfgan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimir)).BeginInit();
            this.SuspendLayout();


            /* pictureBox_OldVladimir */
            this.pictureBox_OldVladimir.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldVladimir.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель2;
            this.pictureBox_OldVladimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_OldVladimir.Size = new System.Drawing.Size(90, 126);
            this.pictureBox_OldVladimir.Location = new System.Drawing.Point((int)(w / 2.8), (int)(h / 2.33333));
            this.pictureBox_OldVladimir.Name = "pictureBox_OldVladimir";
            this.pictureBox_OldVladimir.TabIndex = 0;
            this.pictureBox_OldVladimir.TabStop = false;

            this.pictureBox_OldVladimir.Click += new System.EventHandler(this.pictureBox_OldVladimir_Click);  // Нажатие на метку Владимира


            /* pictureBox_OldMapBackMenu */
            this.pictureBox_OldMapBackMenu.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldMapBackMenu.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_деревянный;
            this.pictureBox_OldMapBackMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_OldMapBackMenu.Size = new System.Drawing.Size((int)(w / 8), (int)(h / 7));
            this.pictureBox_OldMapBackMenu.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_OldMapBackMenu.Name = "pictureBox_OldMapBackMenu";
            this.pictureBox_OldMapBackMenu.TabIndex = 0;
            this.pictureBox_OldMapBackMenu.TabStop = false;

            this.pictureBox_OldMapBackMenu.Click += new System.EventHandler(this.pictureBox_OldMapBackMenu_Click);  // Нажатие на крестик


            /* pictureBox_OldMoscow */
            this.pictureBox_OldMoscow.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldMoscow.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_OldMoscow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_OldMoscow.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_OldMoscow.Location = new System.Drawing.Point((int)(w / 4.52), (int)(h / 2.8));
            this.pictureBox_OldMoscow.Name = "pictureBox_OldMoscow";
            this.pictureBox_OldMoscow.TabIndex = 0;
            this.pictureBox_OldMoscow.TabStop = false;

            this.pictureBox_OldMoscow.Click += new System.EventHandler(this.pictureBox_OldMoscow_Click);  // Нажатие на метку Москвы


            /* pictureBox_OldAfgan */
            this.pictureBox_OldAfgan.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldAfgan.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_OldAfgan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_OldAfgan.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_OldAfgan.Location = new System.Drawing.Point((int)(w / 3.6), (int)(h / 1.07));
            this.pictureBox_OldAfgan.Name = "pictureBox_OldAfgan";
            this.pictureBox_OldAfgan.TabIndex = 0;
            this.pictureBox_OldAfgan.TabStop = false;

            this.pictureBox_OldAfgan.Click += new System.EventHandler(this.pictureBox_OldAfgan_Click);  // Нажатие на метку Москвы


            /* OldMap_panel */
            this.OldMap_panel.BackgroundImage = global::Stoletov_4_0.Properties.Resources.map_1914;
            this.OldMap_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;    //Растягивается
            this.OldMap_panel.Dock = System.Windows.Forms.DockStyle.Fill;                       //Заполняет форму
            this.OldMap_panel.Location = new System.Drawing.Point(0, 0);
            this.OldMap_panel.Name = "OldMap_panel";
            this.OldMap_panel.TabIndex = 0;

            this.OldMap_panel.Visible = false;    // Изначально отключаем
            this.OldMap_panel.Enabled = false;

            /* Добавление в форму */
            this.OldMap_panel.Controls.Add(this.pictureBox_OldMapBackMenu);
            this.OldMap_panel.Controls.Add(this.pictureBox_OldMoscow);
            this.OldMap_panel.Controls.Add(this.pictureBox_OldAfgan);
            this.OldMap_panel.Controls.Add(this.pictureBox_OldVladimir);
            this.Controls.Add(this.OldMap_panel);         //Панель в форме

            /* Все изменения внесены - убираем остановку */
            this.OldMap_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldMapBackMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldMoscow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldAfgan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimir)).EndInit();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.Panel NewVladimirMap_panel;
        private System.Windows.Forms.PictureBox pictureBox_NewVladimirMapBackMenu;
        private System.Windows.Forms.PictureBox pictureBox_NewVladimirMonument;
        private System.Windows.Forms.PictureBox pictureBox_NewVladimirCollege;

        private void generateNewVladimirMap()
        {
            /* Создаём объекты */
            this.NewVladimirMap_panel = new System.Windows.Forms.Panel();
            this.pictureBox_NewVladimirMapBackMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox_NewVladimirMonument = new System.Windows.Forms.PictureBox();
            this.pictureBox_NewVladimirCollege = new System.Windows.Forms.PictureBox();


            /* Присостанавливаем на время изменений*/
            this.NewVladimirMap_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewVladimirMapBackMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewVladimirMonument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewVladimirCollege)).BeginInit();
            this.SuspendLayout();

            /* pictureBox_NewVladimirMapBackMenu */
            this.pictureBox_NewVladimirMapBackMenu.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_NewVladimirMapBackMenu.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_деревянный;
            this.pictureBox_NewVladimirMapBackMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_NewVladimirMapBackMenu.Size = new System.Drawing.Size((int)(w / 8), (int)(h / 7));
            this.pictureBox_NewVladimirMapBackMenu.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_NewVladimirMapBackMenu.Name = "pictureBox_NewVladimirMapBackMenu";
            this.pictureBox_NewVladimirMapBackMenu.TabIndex = 0;
            this.pictureBox_NewVladimirMapBackMenu.TabStop = false;

            this.pictureBox_NewVladimirMapBackMenu.Click += new System.EventHandler(this.pictureBox_NewVladimirMapBackMenu_Click);  // Нажатие на крестик


            /* pictureBox_NewVladimirMonument */
            this.pictureBox_NewVladimirMonument.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_NewVladimirMonument.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_NewVladimirMonument.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_NewVladimirMonument.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_NewVladimirMonument.Location = new System.Drawing.Point((int)(w / 4.5), (int)(h / 2.4));
            this.pictureBox_NewVladimirMonument.Name = "pictureBox_NewVladimirMonument";
            this.pictureBox_NewVladimirMonument.TabIndex = 0;
            this.pictureBox_NewVladimirMonument.TabStop = false;

            this.pictureBox_NewVladimirMonument.Click += new System.EventHandler(this.pictureBox_NewVladimirMonument_Click);  // Нажатие на метку Москвы


            /* pictureBox_NewVladimirCollege */
            this.pictureBox_NewVladimirCollege.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_NewVladimirCollege.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_NewVladimirCollege.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_NewVladimirCollege.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_NewVladimirCollege.Location = new System.Drawing.Point((int)(w / 3.3), (int)(h / 1.1));
            this.pictureBox_NewVladimirCollege.Name = "pictureBox_NewVladimirCollege";
            this.pictureBox_NewVladimirCollege.TabIndex = 0;
            this.pictureBox_NewVladimirCollege.TabStop = false;

            this.pictureBox_NewVladimirCollege.Click += new System.EventHandler(this.pictureBox_NewVladimirCollege_Click);  // Нажатие на метку Москвы


            /* NewVladimirMap_panel */
            this.NewVladimirMap_panel.BackgroundImage = global::Stoletov_4_0.Properties.Resources.Современная_карта_Владимира;
            this.NewVladimirMap_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;    //Растягивается
            this.NewVladimirMap_panel.Dock = System.Windows.Forms.DockStyle.Fill;                       //Заполняет форму
            this.NewVladimirMap_panel.Location = new System.Drawing.Point(0, 0);
            this.NewVladimirMap_panel.Name = "NewVladimirMap_panel";
            this.NewVladimirMap_panel.TabIndex = 0;

            this.NewVladimirMap_panel.Visible = false;    // Изначально отключаем
            this.NewVladimirMap_panel.Enabled = false;

            /* Добавление в форму */
            this.NewVladimirMap_panel.Controls.Add(this.pictureBox_NewVladimirMapBackMenu);
            this.NewVladimirMap_panel.Controls.Add(this.pictureBox_NewVladimirMonument);
            this.NewVladimirMap_panel.Controls.Add(this.pictureBox_NewVladimirCollege);
            this.Controls.Add(this.NewVladimirMap_panel);         //Панель в форме

            /* Все изменения внесены - убираем остановку */
            this.NewVladimirMap_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewVladimirMapBackMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewVladimirMonument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewVladimirCollege)).EndInit();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.Panel OldVladimirMap_panel;
        private System.Windows.Forms.PictureBox pictureBox_OldVladimirMapBackMenu;
        private System.Windows.Forms.PictureBox pictureBox_OldVladimirPoint;
        private System.Windows.Forms.PictureBox pictureBox_OldVladimirSchool;

        private void generateOldVladimirMap()
        {
            /* Создаём объекты */
            this.OldVladimirMap_panel = new System.Windows.Forms.Panel();
            this.pictureBox_OldVladimirMapBackMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox_OldVladimirPoint = new System.Windows.Forms.PictureBox();
            this.pictureBox_OldVladimirSchool = new System.Windows.Forms.PictureBox();


            /* Присостанавливаем на время изменений*/
            this.OldVladimirMap_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimirMapBackMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimirPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimirSchool)).BeginInit();
            this.SuspendLayout();

            /* pictureBox_OldVladimirMapBackMenu */
            this.pictureBox_OldVladimirMapBackMenu.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldVladimirMapBackMenu.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_деревянный;
            this.pictureBox_OldVladimirMapBackMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_OldVladimirMapBackMenu.Size = new System.Drawing.Size((int)(w / 8), (int)(h / 7));
            this.pictureBox_OldVladimirMapBackMenu.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_OldVladimirMapBackMenu.Name = "pictureBox_OldVladimirMapBackMenu";
            this.pictureBox_OldVladimirMapBackMenu.TabIndex = 0;
            this.pictureBox_OldVladimirMapBackMenu.TabStop = false;

            this.pictureBox_OldVladimirMapBackMenu.Click += new System.EventHandler(this.pictureBox_OldVladimirMapBackMenu_Click);  // Нажатие на крестик


            /* pictureBox_OldVladimirPoint */
            this.pictureBox_OldVladimirPoint.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldVladimirPoint.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_OldVladimirPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_OldVladimirPoint.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_OldVladimirPoint.Location = new System.Drawing.Point((int)(w / 4.5), (int)(h / 2.4));
            this.pictureBox_OldVladimirPoint.Name = "pictureBox_OldVladimirPoint";
            this.pictureBox_OldVladimirPoint.TabIndex = 0;
            this.pictureBox_OldVladimirPoint.TabStop = false;

            this.pictureBox_OldVladimirPoint.Click += new System.EventHandler(this.pictureBox_OldVladimirPoint_Click);  // Нажатие на метку Москвы


            /* pictureBox_OldVladimirSchool */
            this.pictureBox_OldVladimirSchool.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_OldVladimirSchool.BackgroundImage = global::Stoletov_4_0.Properties.Resources.указатель_на_карте;
            this.pictureBox_OldVladimirSchool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_OldVladimirSchool.Size = new System.Drawing.Size(60, 85);
            this.pictureBox_OldVladimirSchool.Location = new System.Drawing.Point((int)(w / 3.3), (int)(h / 1.1));
            this.pictureBox_OldVladimirSchool.Name = "pictureBox_OldVladimirSchool";
            this.pictureBox_OldVladimirSchool.TabIndex = 0;
            this.pictureBox_OldVladimirSchool.TabStop = false;

            this.pictureBox_OldVladimirSchool.Click += new System.EventHandler(this.pictureBox_OldVladimirSchool_Click);  // Нажатие на метку Москвы


            /* OldVladimirMap_panel */
            this.OldVladimirMap_panel.BackgroundImage = global::Stoletov_4_0.Properties.Resources.репринт_по_состоянию_на_1891_год;
            this.OldVladimirMap_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;    //Растягивается
            this.OldVladimirMap_panel.Dock = System.Windows.Forms.DockStyle.Fill;                       //Заполняет форму
            this.OldVladimirMap_panel.Location = new System.Drawing.Point(0, 0);
            this.OldVladimirMap_panel.Name = "OldVladimirMap_panel";
            this.OldVladimirMap_panel.TabIndex = 0;

            this.OldVladimirMap_panel.Visible = false;    // Изначально отключаем
            this.OldVladimirMap_panel.Enabled = false;

            /* Добавление в форму */
            this.OldVladimirMap_panel.Controls.Add(this.pictureBox_OldVladimirMapBackMenu);
            this.OldVladimirMap_panel.Controls.Add(this.pictureBox_OldVladimirPoint);
            this.OldVladimirMap_panel.Controls.Add(this.pictureBox_OldVladimirSchool);
            this.Controls.Add(this.OldVladimirMap_panel);         //Панель в форме

            /* Все изменения внесены - убираем остановку */
            this.OldVladimirMap_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimirMapBackMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimirPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OldVladimirSchool)).EndInit();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.Panel Info_panel;
        private System.Windows.Forms.PictureBox pictureBox_InfoExit;
        private System.Windows.Forms.PictureBox pictureBox_Svitok;
        private System.Windows.Forms.PictureBox pictureBox_InfoPhoto;
        private System.Windows.Forms.PictureBox pictureBox_SlideLeft;
        private System.Windows.Forms.PictureBox pictureBox_SlideRight;
        private System.Windows.Forms.Label label_Info;

        private enum SlideState
        {
            LeftOn,
            RightOn,
            BothOn,
            AllOff
        }
        private SlideState SlideState_InfoPanel = SlideState.AllOff;
        /* SlideState_InfoPanel переходит в состояние AllOff при отключении Info_panel
           переход в другие состояния происходит только, если на панели больше одной фотографии или текста*/

        private uint countOfPhoto = 0;  //Количество фотографий на информационной панели
        private uint currentPhoto = 0;  //Номер текущей картинки, начиная с нуля

        /* Пути к файлам катинок и текста
         * 
           ПОКА НЕ ЗНАЮ КАК СДЕЛАТЬ ЛУЧШЕ!!!1 */

        private struct obj
        {
            List<string> PhotoPath;
            List<string> TextPath;
        }
        private obj Paths;

        private string[] MoscowPhoto = {
            "C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow.jpg",
            "C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow2.png",
            "C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow3.png"
        };
        private string[] MoscowText = { 
            "C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow.txt",
            "C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow2.txt",
            "C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow3.txt"
        };

        private void generateInfoPanel()
        {
            /* Создаём объекты */
            this.Info_panel = new System.Windows.Forms.Panel();
            this.label_Info = new System.Windows.Forms.Label();
            this.pictureBox_InfoExit = new System.Windows.Forms.PictureBox();
            this.pictureBox_Svitok = new System.Windows.Forms.PictureBox();
            this.pictureBox_InfoPhoto = new System.Windows.Forms.PictureBox();
            this.pictureBox_SlideLeft = new System.Windows.Forms.PictureBox();
            this.pictureBox_SlideRight = new System.Windows.Forms.PictureBox();


            /* Присостанавливаем на время изменений*/
            this.Info_panel.SuspendLayout();
            this.label_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_InfoExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Svitok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_InfoPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideRight)).BeginInit();
            this.SuspendLayout();


            /* Info_panel */
            this.Info_panel.BackgroundImage = global::Stoletov_4_0.Properties.Resources.доски_светлые;
            this.Info_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;    //Растягивается
            this.Info_panel.Size = new System.Drawing.Size((int)(w / 2), (int)(h / 2));
            //this.Info_panel.Location = new System.Drawing.Point(w / 2 - this.Info_panel.Size.Width / 2, h / 2 - this.Info_panel.Size.Height / 2);
            this.Info_panel.Location = new System.Drawing.Point(w / 2 - this.Info_panel.Width / 2, -this.Info_panel.Height); //Вне экрана
            this.Info_panel.Name = "Info_panel";
            this.Info_panel.TabIndex = 0;

            this.Info_panel.Visible = false;    // Изначально отключаем
            this.Info_panel.Enabled = false;


            /* pictureBox_Svitok */
            this.pictureBox_Svitok.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_Svitok.BackgroundImage = global::Stoletov_4_0.Properties.Resources.Свиток_2;
            this.pictureBox_Svitok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_Svitok.Location = new System.Drawing.Point(this.Info_panel.Size.Width / 2, 0);
            this.pictureBox_Svitok.Name = "pictureBox_Svitok";
            this.pictureBox_Svitok.Size = new System.Drawing.Size(this.Info_panel.Size.Width / 2, this.Info_panel.Size.Height);
            this.pictureBox_Svitok.TabIndex = 0;
            this.pictureBox_Svitok.TabStop = false;


            /*pictureBox_SlideLeft*/
            this.pictureBox_SlideLeft.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_SlideLeft.BackgroundImage = global::Stoletov_4_0.Properties.Resources.лево_чёрная;
            this.pictureBox_SlideLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;         //Растягивает
            this.pictureBox_SlideLeft.Size = new System.Drawing.Size(this.pictureBox_Svitok.Size.Width / 3, this.pictureBox_Svitok.Size.Height / 10);
            this.pictureBox_SlideLeft.Location = new System.Drawing.Point(this.pictureBox_Svitok.Size.Width / 2 - this.pictureBox_SlideLeft.Size.Width, this.pictureBox_Svitok.Size.Height - this.pictureBox_SlideLeft.Size.Height); //Находиться внизу свитка
            this.pictureBox_SlideLeft.Name = "pictureBox_SlideLeft";
            this.pictureBox_SlideLeft.TabIndex = 0;
            this.pictureBox_SlideLeft.TabStop = false;

            this.pictureBox_SlideLeft.Click += new System.EventHandler(this.pictureBox_SlideLeft_Click);  // Предыдущий слайд


            /*pictureBox_SlideRight*/
            this.pictureBox_SlideRight.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_SlideRight.BackgroundImage = global::Stoletov_4_0.Properties.Resources.право_чёрная;
            this.pictureBox_SlideRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;         //Растягивает
            this.pictureBox_SlideRight.Size = new System.Drawing.Size(this.pictureBox_Svitok.Size.Width / 3, this.pictureBox_Svitok.Size.Height / 10);
            this.pictureBox_SlideRight.Location = new System.Drawing.Point(this.pictureBox_Svitok.Size.Width / 2, this.pictureBox_Svitok.Size.Height - this.pictureBox_SlideRight.Size.Height); //Находиться внизу свитка
            this.pictureBox_SlideRight.Name = "pictureBox_SlideLeft";
            this.pictureBox_SlideRight.TabIndex = 0;
            this.pictureBox_SlideRight.TabStop = false;

            this.pictureBox_SlideRight.Click += new System.EventHandler(this.pictureBox_SlideRight_Click);  // Следующий слайд


            /* pictureBox_InfoPhoto */
            this.pictureBox_InfoPhoto.BackColor = System.Drawing.Color.Transparent;          //Просвечивает

            this.pictureBox_InfoPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_InfoPhoto.Padding = new System.Windows.Forms.Padding(33, 32, 33, 32);
            this.pictureBox_InfoPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.pictureBox_InfoPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_InfoPhoto.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_InfoPhoto.Name = "pictureBox_InfoPhoto";
            this.pictureBox_InfoPhoto.Size = new System.Drawing.Size(this.Info_panel.Size.Width / 2, this.Info_panel.Size.Height);
            this.pictureBox_InfoPhoto.TabIndex = 0;
            this.pictureBox_InfoPhoto.TabStop = false;


            /* pictureBox_InfoExit */
            this.pictureBox_InfoExit.BackColor = System.Drawing.Color.Transparent;          //Просвечивает
            this.pictureBox_InfoExit.BackgroundImage = global::Stoletov_4_0.Properties.Resources.крест_красный;
            this.pictureBox_InfoExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;         //Растягивает
            this.pictureBox_InfoExit.Location = new System.Drawing.Point(this.pictureBox_Svitok.Size.Width - 50, 0);
            this.pictureBox_InfoExit.Name = "pictureBox_InfoExit";
            this.pictureBox_InfoExit.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_InfoExit.TabIndex = 0;
            this.pictureBox_InfoExit.TabStop = false;

            this.pictureBox_InfoExit.Click += new System.EventHandler(this.pictureBox_InfoExit_Click);  // Нажатие на крестик


            /* label_Info */
            this.label_Info.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Info.MaximumSize = new System.Drawing.Size((int)(this.pictureBox_Svitok.Size.Width * 0.8), (int)(this.pictureBox_Svitok.Size.Height * 0.8));
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size((int)(this.pictureBox_Svitok.Size.Width * 0.8), (int)(this.pictureBox_Svitok.Size.Height * 0.8));
            this.label_Info.Location = new System.Drawing.Point((int)(this.pictureBox_Svitok.Size.Width * 0.1), (int)(this.pictureBox_Svitok.Size.Height * 0.1));
            this.label_Info.TabIndex = 4;
            this.label_Info.Text = "Info_label";
            this.label_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


            /* Добавление в форму */
            this.pictureBox_Svitok.Controls.Add(this.pictureBox_InfoExit);
            this.pictureBox_Svitok.Controls.Add(this.label_Info);
            this.pictureBox_Svitok.Controls.Add(this.pictureBox_SlideRight);
            this.pictureBox_Svitok.Controls.Add(this.pictureBox_SlideLeft);
            this.Info_panel.Controls.Add(this.pictureBox_Svitok);
            this.Info_panel.Controls.Add(this.pictureBox_InfoPhoto);
            //this.NewMap_panel.Controls.Add(this.Info_panel);         //Панель в панели карты
            this.Controls.Add(this.Info_panel);


            /* Все изменения внесены - убираем остановку */
            this.Info_panel.ResumeLayout(false);
            this.label_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_InfoExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Svitok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_InfoPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideRight)).EndInit();
            this.ResumeLayout(false);
        }


        #region Методы включения панелей
        private void OnMenu()
        {
            this.Menu_panel.Visible = true;
            this.Menu_panel.Enabled = true;
        }

        private void OnNewMap()
        {
            this.NewMap_panel.Visible = true;
            this.NewMap_panel.Enabled = true;
        }

        private void OnNewVladimirMap()
        {
            this.NewVladimirMap_panel.Visible = true;
            this.NewVladimirMap_panel.Enabled = true;
        }

        private void OnOldVladimirMap()
        {
            this.OldVladimirMap_panel.Visible = true;
            this.OldVladimirMap_panel.Enabled = true;
        }

        private void OnOldMap()
        {
            this.OldMap_panel.Visible = true;
            this.OldMap_panel.Enabled = true;
        }

        private void OnInfoPanel()
        {
            this.Info_panel.Visible = true;
            this.Info_panel.Enabled = true;

            this.pictureBox_SlideRight.Visible = true;
            this.pictureBox_SlideLeft.Visible = true;
            switch (SlideState_InfoPanel)
            {
                case SlideState.RightOn:
                    this.pictureBox_SlideRight.BackgroundImage = global::Stoletov_4_0.Properties.Resources.право_красная;
                    this.pictureBox_SlideLeft.BackgroundImage = global::Stoletov_4_0.Properties.Resources.лево_чёрная;
                    //this.pictureBox_SlideRight.Visible = true;
                    this.pictureBox_SlideRight.Enabled = true;
                    //this.pictureBox_SlideLeft.Visible = false;
                    this.pictureBox_SlideLeft.Enabled = false;
                    break;
                case SlideState.LeftOn:
                    this.pictureBox_SlideRight.BackgroundImage = global::Stoletov_4_0.Properties.Resources.право_чёрная;
                    this.pictureBox_SlideLeft.BackgroundImage = global::Stoletov_4_0.Properties.Resources.лево_красная;
                    //this.pictureBox_SlideRight.Visible = false;
                    this.pictureBox_SlideRight.Enabled = false;
                    //this.pictureBox_SlideLeft.Visible = true;
                    this.pictureBox_SlideLeft.Enabled = true;
                    break;
                case SlideState.BothOn:
                    this.pictureBox_SlideRight.BackgroundImage = global::Stoletov_4_0.Properties.Resources.право_красная;
                    this.pictureBox_SlideLeft.BackgroundImage = global::Stoletov_4_0.Properties.Resources.лево_красная;
                    //this.pictureBox_SlideRight.Visible = true;
                    this.pictureBox_SlideRight.Enabled = true;
                    //this.pictureBox_SlideLeft.Visible = true;
                    this.pictureBox_SlideLeft.Enabled = true;
                    break;
                case SlideState.AllOff:
                    this.pictureBox_SlideRight.Visible = false;
                    this.pictureBox_SlideRight.Enabled = false;
                    this.pictureBox_SlideLeft.Visible = false;
                    this.pictureBox_SlideLeft.Enabled = false;
                    break;
            }

            this.Info_timer.Start();
        }

        #endregion

        #region Методы отключения панелей
        private void OffMenu()
        {
            this.Menu_panel.Visible = false;
            this.Menu_panel.Enabled = false;
        }

        private void OffNewMap()
        {
            this.NewMap_panel.Visible = false;
            this.NewMap_panel.Enabled = false;
        }

        private void OffNewVladimirMap()
        {
            this.NewVladimirMap_panel.Visible = false;
            this.NewVladimirMap_panel.Enabled = false;
        }

        private void OffOldVladimirMap()
        {
            this.OldVladimirMap_panel.Visible = false;
            this.OldVladimirMap_panel.Enabled = false;
        }

        private void OffOldMap()
        {
            this.OldMap_panel.Visible = false;
            this.OldMap_panel.Enabled = false;
        }

        private void OffInfoPanel()
        {
            this.Info_panel.Visible = false;
            this.Info_panel.Enabled = false;
            this.Info_panel.Location = new Point(w / 2 - this.Info_panel.Width / 2, -this.Info_panel.Height); //Вне экрана
            SlideState_InfoPanel = SlideState.AllOff;
        }

        #endregion

        #region Функции кликов на объекты
        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox_NewMap_Click(object sender, EventArgs e)
        {
            OnNewMap();
            OffMenu();
        }

        private void pictureBox_OldMap_Click(object sender, EventArgs e)
        {
            OnOldMap();
            OffMenu();
        }

        private void pictureBox_NewMapBackMenu_Click(object sender, EventArgs e)
        {
            OnMenu();
            OffNewMap();
            OffInfoPanel();
        }

        private void pictureBox_OldMapBackMenu_Click(object sender, EventArgs e)
        {
            OnMenu();
            OffOldMap();
            OffInfoPanel();
        }

        private void pictureBox_NewVladimirMapBackMenu_Click(object sender, EventArgs e)
        {
            OnNewMap();
            OffNewVladimirMap();
            OffInfoPanel();
        }

        private void pictureBox_OldVladimirMapBackMenu_Click(object sender, EventArgs e)
        {
            OnOldMap();
            OffOldVladimirMap();
            OffInfoPanel();
        }

        private void pictureBox_InfoExit_Click(object sender, EventArgs e)
        {
            OffInfoPanel();
        }

        private void pictureBox_SlideLeft_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel(MoscowText[--currentPhoto]);
            this.pictureBox_InfoPhoto.Image = Image.FromFile(MoscowPhoto[currentPhoto]);

            if (currentPhoto == 0)  //Переключились на первую фотографию
            {
                SlideState_InfoPanel = SlideState.RightOn;
                OnInfoPanel();
                return;
            }

            if(currentPhoto > 0 && currentPhoto < countOfPhoto) //Оказались между первой и последней фотографией
            {
                SlideState_InfoPanel = SlideState.BothOn;
                OnInfoPanel();
                return;
            }
        }

        private void pictureBox_SlideRight_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel(MoscowText[++currentPhoto]);
            this.pictureBox_InfoPhoto.Image = Image.FromFile(MoscowPhoto[currentPhoto]);

            if (currentPhoto == countOfPhoto - 1)  //Переключились на последнюю фотографию
            {
                SlideState_InfoPanel = SlideState.LeftOn;
                OnInfoPanel();
                return;
            }

            if (currentPhoto > 0 && currentPhoto < countOfPhoto) //Оказались между первой и последней фотографией
            {
                SlideState_InfoPanel = SlideState.BothOn;
                OnInfoPanel();
                return;
            }
        }
        #endregion 

        #region Наведение курсора на карты
        private void pictureBox_NewMap_Enter(object sender, EventArgs e)
        {
            this.pictureBox_FrameNewMap.Visible = true;
        }

        private void pictureBox_NewMap_Leave(object sender, EventArgs e)
        {
            this.pictureBox_FrameNewMap.Visible = false;
        }

        private void pictureBox_OldMap_Enter(object sender, EventArgs e)
        {
            this.pictureBox_FrameOldMap.Visible = true;
        }

        private void pictureBox_OldMap_Leave(object sender, EventArgs e)
        {
            this.pictureBox_FrameOldMap.Visible = false;
        }
        #endregion

        #region Функции кликов на метки на картах

        #region Новая карта
        private void pictureBox_Moscow_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel(MoscowText[0]);
            this.pictureBox_InfoPhoto.Image = Image.FromFile(MoscowPhoto[0]);

           // this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow.txt");
            //this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Moscow.jpg");
            countOfPhoto = 3;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.RightOn;
            OnInfoPanel();
        }

        private void pictureBox_Sofia_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Sofia.txt");
            this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Sofia.jpg");
            countOfPhoto = 1;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.AllOff;
            OnInfoPanel();
        }

        private void pictureBox_Vladimir_Click(object sender, EventArgs e)
        {
            OnNewVladimirMap();
            OffNewMap();
            OffInfoPanel();
        }
        #endregion

        #region Старая карта
        private void pictureBox_OldMoscow_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\OldMoscow.txt");
            this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\OldMoscow.jpg");
            countOfPhoto = 1;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.AllOff;
            OnInfoPanel();
        }

        private void pictureBox_OldAfgan_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\OldAfgan.txt");
            this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\OldAfgan.jpg");
            countOfPhoto = 1;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.AllOff;
            OnInfoPanel();
        }

        private void pictureBox_OldVladimir_Click(object sender, EventArgs e)
        {
            OnOldVladimirMap();
            OffOldMap();
            OffInfoPanel();
        }
        #endregion
        
        #region Новый Владимир
        private void pictureBox_NewVladimirMonument_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Monument.txt");
            this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Monument.jpg");
            countOfPhoto = 1;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.AllOff;
            OnInfoPanel();
        }

        private void pictureBox_NewVladimirCollege_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\College.txt");
            this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\College.jpg");
            countOfPhoto = 1;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.AllOff;
            OnInfoPanel();
        }
        #endregion

        #region Старый Владимир 
        private void pictureBox_OldVladimirPoint_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Point.txt");
            this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\Point.jpg");
            countOfPhoto = 1;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.AllOff;
            OnInfoPanel();
        }

        private void pictureBox_OldVladimirSchool_Click(object sender, EventArgs e)
        {
            this.label_Info.Text = GetTextForLabel("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\School.txt");
            this.pictureBox_InfoPhoto.Image = Image.FromFile("C:\\Users\\khabi\\OneDrive\\Рабочий стол\\Programming\\Programs on C#\\StoletovInteractive\\Stoletov 4_0\\My_resource\\School.jpg");
            countOfPhoto = 1;
            currentPhoto = 0;
            SlideState_InfoPanel = SlideState.AllOff;
            OnInfoPanel();
        }
        #endregion

        #endregion


        private void Info_Timer_Tick(object sender, EventArgs e)
        {
            if (!(this.Info_panel.Location.Y < h / 2 - this.Info_panel.Size.Height / 2))
            {
                this.Info_timer.Stop();
                this.Info_panel.Location = new System.Drawing.Point(w2 - this.Info_panel.Size.Width / 2, h2 - this.Info_panel.Size.Height / 2);
            }
            else
            {
                this.Info_panel.Location = new Point(this.Info_panel.Location.X, this.Info_panel.Location.Y + Math.Abs(h2 - this.Info_panel.Location.Y) / 8);
            }
        }

        private String GetTextForLabel(String Path) /* Принимает путь до текстового файла и возвращает его содержимое*/
        {
            String line = "";
            try
            {
                StreamReader sr = new StreamReader(Path);
                String str = sr.ReadLine();
                while (str != null)
                {
                    line += str + "\n";
                    str = sr.ReadLine();
                }
            }
            catch (Exception err) { line = "Exception: " + err.Message; }
            finally { if (line == "") line = "Executing finally block"; }

            return line;
        }
        
        
        /// Освободить все используемые ресурсы.
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
