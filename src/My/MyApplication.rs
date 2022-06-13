// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.My.MyApplication
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1.My
{
  [GeneratedCode("MyTemplate", "11.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal class MyApplication : WindowsFormsApplicationBase
  {
    [STAThread]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DebuggerHidden]
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static void Main(string[] Args)
    {
      try
      {
        Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
      }
      finally
      {
      }
      MyProject.Application.Run(Args);
    }

    [DebuggerStepThrough]
    pub MyApplication()
      : base(AuthenticationMode.ApplicationDefined)
    {
      this.IsSingleInstance = false;
      this.EnableVisualStyles = false;
      this.SaveMySettingsOnExit = false;
      this.ShutdownStyle = ShutdownMode.AfterAllFormsClose;
    }

    [DebuggerStepThrough]
    protected void OnCreateMainForm() => this.MainForm =  MyProject.Forms.Form1;
  }
}
