// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ImmoveableForm
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class ImmoveableForm : Form
  {
    private const int HTCAPTION = 2;
    private const int MF_BYCOMMAND = 0;
    private const int MF_ENABLED = 0;
    private const int MF_GRAYED = 1;
    private const int MF_DISABLED = 2;
    private const int SC_MOVE = 61456;
    private const int WM_NCLBUTTONDOWN = 161;
    private const int WM_SYSCOMMAND = 274;
    private const int WM_INITMENUPOPUP = 279;
    public bool bMoveable;

    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);

    public ImmoveableForm() => this.bMoveable = true;

    [Description("Allows the form to be moved")]
    [Category("Behavior")]
    public virtual bool Moveable
    {
      get => this.bMoveable;
      set
      {
        if (this.bMoveable == value)
          return;
        this.bMoveable = value;
      }
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 32)
        m = m;
      IntPtr num1;
      if (m.Msg == 279)
      {
        num1 = m.LParam;
        if (num1.ToInt32() / 65536 != 0)
        {
          int num2 = 0;
          if (!this.Moveable)
            num2 = 3;
          ImmoveableForm.EnableMenuItem(m.WParam, 61456, 0 | num2);
        }
      }
      if (!this.Moveable)
      {
        if (m.Msg == 161)
        {
          num1 = m.WParam;
          if (num1.ToInt32() == 2)
            return;
        }
        if (m.Msg == 274)
        {
          num1 = m.WParam;
          if ((num1.ToInt32() & 65520) == 61456)
            return;
        }
      }
      base.WndProc(ref m);
    }
  }
}
