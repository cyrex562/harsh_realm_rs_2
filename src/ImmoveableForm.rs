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
  pub class ImmoveableForm : Form
  {
     const int HTCAPTION = 2;
     const int MF_BYCOMMAND = 0;
     const int MF_ENABLED = 0;
     const int MF_GRAYED = 1;
     const int MF_DISABLED = 2;
     const int SC_MOVE = 61456;
     const int WM_NCLBUTTONDOWN = 161;
     const int WM_SYSCOMMAND = 274;
     const int WM_INITMENUPOPUP = 279;
    pub bMoveable: bool;

    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
     static extern int EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);

    pub ImmoveableForm() => this.bMoveable = true;

    [Description("Allows the form to be moved")]
    [Category("Behavior")]
    pub virtual bool Moveable
    {
      get => this.bMoveable;
      set
      {
        if (this.bMoveable == value)
          return;
        this.bMoveable = value;
      }
    }

    protected void WndProc( Message m)
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
      base.WndProc( m);
    }
  }
}
