using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDiffView.Demo
{
    public class DemoViewModel
    {
        public string Left => @"
public Diff Diff
{
    get;
    private set;
}

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

        public string Right => @"
public Diff Diff
{
    get;
    private set;
}

internal void Show(Change change)
{
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
    }
}
