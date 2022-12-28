using GalaSoft.MvvmLight;
using QuickPick.Model;
using QuickPick.Core;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Media;

namespace QuickPick.ViewModel
{
    public class MainViewModel : QuickPick.Core.ObservableObject
    {
        private Random r = new Random();
        public MainViewModel()
        {
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
        private ObservableCollection<ButtonTemplate> _buttonList;
        public ObservableCollection<ButtonTemplate> ButtonList
        {
            get { return _buttonList; }
            set
            {
                _buttonList = value;
                OnPropertyChanged("ButtonList");
            }
        }
        private ButtonTemplate _selectedButton;
        public ButtonTemplate SelectedButton
        {
            get { return _selectedButton; }
            set
            {
                _selectedButton = value;
                OnPropertyChanged("SelectedButton");
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
                    if(obj != null)
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

        #endregion
    }
}