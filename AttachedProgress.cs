using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

/// <summary>
/// 簡単にProgressRingを表示するためのクラス
/// Active()で開始
/// InActive()で終了
/// コンストラクタにはPanelを継承したGridやStackPanelなどを入れる
/// </summary>
    public class AttachedProgress
    {
        bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            
        }

        public Panel ParentElement { get; set; }

        private Popup popup;

        public Popup Popup
        {
            get { return popup; }
            set { popup = value; }
        }

        private ProgressRing progressRing;

        public ProgressRing ProgressRing
        {
            get { return progressRing; }
            set { progressRing = value; }
        }

        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; progressRing.Width = value; popup.Width = value; }
        }

        private double height;

        public double Height
        {
            get { return height; }
            set { height = value; progressRing.Height = value; popup.Height = value; }
        }

        private SolidColorBrush progressBrush;

        public SolidColorBrush ProgressBrush
        {
            get { return progressBrush; }
            set { progressBrush = value; progressRing.Foreground = value; }
        }
        public AttachedProgress(Panel parentElement,double width,double height)
        {
            ParentElement = parentElement;
            isActive = false;
            popup = new Popup();
            progressRing = new ProgressRing();
            progressRing.IsActive = false;
           
            progressRing.VerticalAlignment = VerticalAlignment.Stretch;
            progressRing.HorizontalAlignment = HorizontalAlignment.Stretch;
            Width = width;
            Height = height;
            popup.Child = progressRing;

            parentElement.Children.Add(popup);
        }

        public void Active()
        {
            popup.IsOpen = true;
            isActive = true;
            progressRing.IsActive = true;
        }

        public void InActive()
        {
            popup.IsOpen = false;
            isActive = false;
            progressRing.IsActive = false;
        }


        public void Dispose()
        {
            ParentElement.Children.Remove(popup);
        }

        
    }

