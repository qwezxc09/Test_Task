using GalaSoft.MvvmLight;
using QuickPick.Model;
using QuickPick.Core;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace QuickPick.ViewModel
{
    public class MainViewModel : Core.ObservableObject
    {
        private Random r = new Random();
        private Point previewPointer;
        private Point currentPointer;
        private DateTime previewTime;
        private DateTime currentTime;
        public MainViewModel()
        {
            ScrollArgs = new ScrollArgs();
            ButtonList = new ObservableCollection<ButtonTemplate>
            {
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
                new ButtonTemplate(r),
            };
        }
        #region Properties
        private ScrollArgs _scrollArgs;
        public ScrollArgs ScrollArgs
        {
            get => _scrollArgs;
            set
            {
                _scrollArgs = value;
                OnPropertyChanged("ScrollArgs");
            }
        }
        private ObservableCollection<ButtonTemplate> _buttonList;
        public ObservableCollection<ButtonTemplate> ButtonList
        {
            get => _buttonList;
            set
            {
                _buttonList = value;
                OnPropertyChanged("ButtonList");
            }
        }
        #endregion

        #region Commands

        private RelayCommand _changeColorCommand;
        public RelayCommand ChangeColorCommand
        {
            get
            {
                return _changeColorCommand ?? (_changeColorCommand = new RelayCommand((obj) =>
                {
                    if (obj != null)
                    {
                        var selectedButton = obj as ButtonTemplate;
                        var r = new Random();
                        var color = ButtonTemplate.GetRandomColor(r);
                        var index = ButtonList.IndexOf(selectedButton);
                        ButtonList.RemoveAt(index);
                        ButtonList.Insert(index, new ButtonTemplate(r, color, 70, 70));
                    }
                }));
            }
        }
        private RelayCommand _addButtonCommand;
        public RelayCommand AddButtonCommand
        {
            get
            {
                return _addButtonCommand ?? (_addButtonCommand = new RelayCommand((obj) =>
                {
                    ButtonList.Insert(0, new ButtonTemplate(r));
                }));
            }
        }
        private RelayCommand _removeButtonCommand;
        public RelayCommand RemoveButtonCommand
        {
            get
            {
                return _removeButtonCommand ?? (_removeButtonCommand = new RelayCommand((obj) =>
                {
                    ButtonList.RemoveAt(0);
                }));
            }
        }


        private RelayCommand _previewMouseDownCommand;
        public RelayCommand PreviewMouseDownCommand
        {
            get
            {
                return _previewMouseDownCommand ?? (_previewMouseDownCommand = new RelayCommand((obj) =>
                {
                    previewPointer = GetMousePos();
                    previewTime = DateTime.Now;
                }));
            }
        }
        private RelayCommand _previewMouseUpCommand;
        public RelayCommand PreviewMouseUpCommand
        {
            get
            {
                return _previewMouseUpCommand ?? (_previewMouseUpCommand = new RelayCommand((obj) =>
                {
                    ScrollButtons();
                }));
            }
        }
        #endregion

        #region Functions
        Point GetMousePos() => Mouse.GetPosition(Application.Current.MainWindow);
        public void ScrollButtons()
        {
            currentPointer = GetMousePos();
            if (previewPointer.X > currentPointer.X)
            {
                ScrollArgs = new ScrollArgs
                {
                    Direction = "right",
                    Offset = previewPointer.X - currentPointer.X,
                    Speed = CountSpeed(currentPointer, previewPointer)
                };
            }
            else
            {
                ScrollArgs = new ScrollArgs
                {
                    Direction = "left",
                    Offset = currentPointer.X - previewPointer.X,
                    Speed = CountSpeed(previewPointer, currentPointer)
                };
            }
        }
        public int CountSpeed(Point startPoint, Point endPoint)
        {
            currentTime = DateTime.Now;
            var speed = Convert.ToInt32((endPoint.X - startPoint.Y) / (currentTime - previewTime).TotalMilliseconds);
            return speed;
        }
        #endregion
    }
}