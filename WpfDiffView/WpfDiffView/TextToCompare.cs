using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfDiffView
{
    public class TextToCompare : INotifyPropertyChanged
    {
        private string _textLeft = "";
        private string _textRight = "";

        public string TextLeft
        {
            get { return _textLeft ?? ""; }
            set
            {
                if (value != _textLeft)
                {
                    _textLeft = value;
                    RaisePropChanged();
                }
            }
        }
        public string TextRight
        {
            get { return _textRight ?? ""; }
            set
            {
                if (value != _textRight)
                {
                    _textRight = value;
                    RaisePropChanged();
                }
            }
        }

        private void RaisePropChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static TextToCompare Empty => new TextToCompare();
    }
}
