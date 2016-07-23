using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfDiffView.Demo
{
    public class DemoModel : INotifyPropertyChanged
    {
        private string _left = @"
public Diff Diff
{
    get;
    private set;
}

// remove this comment later

internal void Show(Change change)
{
    if (change == null)
    {
        Clear();
        return;
    }
    var a = (change.ReferenceObject != null ? (change.ReferenceObject as Blob).RawData : new byte[0]);
    var b = (change.ComparedObject != null ? (change.ComparedObject as Blob).RawData : new byte[0]);
    a = (Diff.IsBinary(a) == true ? Encoding.ASCII.GetBytes(""Binary content\nFile size: "" + a.Length) : a);
    b = (Diff.IsBinary(b) == true ? Encoding.ASCII.GetBytes(""Binary content\nFile size: "" + b.Length) : b);
    Init(new Diff(a, b));
}
".Trim();

        private string _right = @"
public Diff Diff
{
    get;
    private set;
}

internal void Show(Change change)
{
    // updated to C#6

    if (change == null)
    {
        Clear();
        return;
    }

    var b = (change.ComparedObject as Blob)?.RawData ?? new byte[0];
    var a = (change.ReferenceObject as Blob)?.RawData ?? new byte[0];    
    a = (Diff.IsBinary(a) ? Encoding.ASCII.GetBytes(""Binary content\nFile size: "" + a.Length) : a);
    b = (Diff.IsBinary(b) ? Encoding.ASCII.GetBytes(""Binary content\nFile size: "" + b.Length) : b);
    Init(new Diff(a, b));
}
".Trim();

        public string Left
        {
            get { return _left; }
            set
            {
                _left = value;
                RaisePropChanged();
            }
        }
        public string Right
        {
            get { return _right; }
            set
            {
                _right = value;
                RaisePropChanged();
            }
        }

        private void RaisePropChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}