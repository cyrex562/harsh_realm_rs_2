// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.My.Resources.Resources
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WindowsApplication1.My.Resources
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [StandardModule]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [HideModuleName]
  internal sealed class Resources
  {
     static ResourceManager resourceMan;
     static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) WindowsApplication1.My.Resources.Resources.resourceMan, (object) null))
          WindowsApplication1.My.Resources.Resources.resourceMan = new ResourceManager("WindowsApplication1.Resources", typeof (WindowsApplication1.My.Resources.Resources).Assembly);
        return WindowsApplication1.My.Resources.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => WindowsApplication1.My.Resources.Resources.resourceCulture;
      set => WindowsApplication1.My.Resources.Resources.resourceCulture = value;
    }
  }
}
