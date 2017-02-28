using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using WpfPdfMover.Annotations;
using WpfPdfMover.Commands;
using WpfPdfMover.DataAccess;

namespace WpfPdfMover.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _canExecute = true;
        private string _pdfPath;
        private ICommand _openPdfCommand;
        private readonly CollectionView _customerEntries;

        public MainWindowViewModel()
        {
            OpenPdfCommand = new RelayCommand(OpenPdf, param => _canExecute);
            //_toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            var kundenModel = new KundenModel();
            var list = kundenModel.Kundens.ToList();
            
            _customerEntries = new CollectionView(list);
        }

        public CollectionView CustomerEntries
        {
            get { return _customerEntries; }
        }

        public string PdfPath
        {
            get { return _pdfPath; }
            set
            {
                _pdfPath = value;
                OnPropertyChanged(nameof(PdfPath));
            }
        }

        public bool CanExecute
        {
            get
            {
                return _canExecute;
            }

            set
            {
                if (_canExecute == value)
                {
                    return;
                }

                _canExecute = value;
            }
        }

        //public ICommand ToggleExecuteCommand
        //{
        //    get
        //    {
        //        return _toggleExecuteCommand;
        //    }
        //    set
        //    {
        //        _toggleExecuteCommand = value;
        //    }
        //}

        public ICommand OpenPdfCommand
        {
            get
            {
                return _openPdfCommand;
            }
            set
            {
                _openPdfCommand = value;
            }
        }

        public void OpenPdf(object obj)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog()
            {
                Filter =
                    "Pdf Files (*.pdf)|*.pdf"
            };
            var result = ofd.ShowDialog();
            if (result != false)
                PdfPath = ofd.FileName;
        }

        public void ChangeCanExecute(object obj)
        {
            _canExecute = !_canExecute;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
