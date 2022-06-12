// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MapClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace WindowsApplication1
{
  [Serializable]
  public class MapClass : ISerializable
  {
    public string Name;
    public int MapWidth;
    public int MapHeight;
    public HexClass[,] HexObj;
    public bool MapLoop;
    public bool CanSee;
    public bool TempCanSee;

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      GC.Collect();
      Application.DoEvents();
      info.AddValue("Name", (object) this.Name);
      info.AddValue("MapWidth", this.MapWidth);
      info.AddValue("MapHeight", this.MapHeight);
      int num1 = 164 * ((this.MapWidth + 1) * (this.MapHeight + 1)) + 24 * ((this.MapWidth + 1) * (this.MapHeight + 1)) + 4 * ((this.MapWidth + 1) * (this.MapHeight + 1));
      int num2 = 4;
      int num3 = num1 + 112 * ((this.MapWidth + 1) * (this.MapHeight + 1));
      int mapWidth1 = this.MapWidth;
      int index1;
      int index2;
      for (index1 = 0; index1 <= mapWidth1; ++index1)
      {
        int mapHeight = this.MapHeight;
        for (index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.HexObj[index1, index2].RegimeCount > -1)
            num3 += 56 * (1 + this.HexObj[index1, index2].RegimeCount);
          if (this.HexObj[index1, index2].RegimeFullCount > -1)
            num3 += 8 * (1 + this.HexObj[index1, index2].RegimeFullCount);
          if (this.HexObj[index1, index2].ConnectionCount > -1)
            num3 += 12 * (1 + this.HexObj[index1, index2].ConnectionCount);
          if (this.HexObj[index1, index2].UnitCounter > -1)
            num3 += 4 * (1 + this.HexObj[index1, index2].UnitCounter);
          if (Information.IsNothing((object) this.HexObj[index1, index2].Name))
            this.HexObj[index1, index2].Name = "";
          if (Information.IsNothing((object) this.HexObj[index1, index2].LabelText1))
            this.HexObj[index1, index2].LabelText1 = "";
          if (Information.IsNothing((object) this.HexObj[index1, index2].LabelText2))
            this.HexObj[index1, index2].LabelText2 = "";
          if (Information.IsNothing((object) this.HexObj[index1, index2].SmallLabel))
            this.HexObj[index1, index2].SmallLabel = "";
          num3 = num3 + (10 + this.HexObj[index1, index2].SmallLabel.Length * num2) + (10 + this.HexObj[index1, index2].Name.Length * num2) + (10 + this.HexObj[index1, index2].LabelText1.Length * num2) + (10 + this.HexObj[index1, index2].LabelText2.Length * num2);
          if (this.HexObj[index1, index2].HexLibVarCounter > -1)
            num3 += 8 * (1 + this.HexObj[index1, index2].HexLibVarCounter);
          if (DrawMod.TGame.Data.Product >= 5)
            num3 += 4;
          if (DrawMod.TGame.Data.Product >= 6)
            num3 = num3 + 12 + 24 + 4;
          if (DrawMod.TGame.Data.Product == 7)
            num3 = num3 + 180 + 36;
        }
      }
      int num4 = num3;
      byte[] numArray1 = new byte[num4 + 1];
      MemoryStream output = new MemoryStream(numArray1);
      BinaryWriter bw = new BinaryWriter((Stream) output);
      try
      {
        int mapWidth2 = this.MapWidth;
        for (index1 = 0; index1 <= mapWidth2; ++index1)
        {
          int mapHeight = this.MapHeight;
          for (index2 = 0; index2 <= mapHeight; ++index2)
          {
            this.HexObj[index1, index2].StreamWrite(ref bw);
            bw = bw;
          }
          bw.Flush();
          output.Flush();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        int num5 = (int) Interaction.MsgBox((object) ("Error in hex data compression. Current size: " + bw.BaseStream.Position.ToString() + " , SizeDimmed: " + num4.ToString() + "..  ix: " + index1.ToString() + "/" + this.MapWidth.ToString() + " iy: " + index2.ToString() + "/" + this.MapHeight.ToString() + " .. actual error message: " + exception.Message));
        ProjectData.ClearProjectError();
      }
      bw.Flush();
      output.Flush();
      byte[] numArray2 = (byte[]) Utils.CopyArray((Array) numArray1, (Array) new byte[(int) (output.Position + 1L) + 1]);
      info.AddValue("DataSize", numArray2.GetUpperBound(0));
      info.AddValue("Data", (object) numArray2);
      bw.Close();
      output.Close();
      info.AddValue("MapLoop", this.MapLoop);
      info.AddValue("CanSee", this.CanSee);
    }

    protected MapClass(SerializationInfo info, StreamingContext context)
    {
      this.HexObj = new HexClass[1, 1];
      GC.Collect();
      Application.DoEvents();
      this.Name = info.GetString(nameof (Name));
      this.MapWidth = info.GetInt32(nameof (MapWidth));
      this.MapHeight = info.GetInt32(nameof (MapHeight));
      this.HexObj = new HexClass[this.MapWidth + 1, this.MapHeight + 1];
      try
      {
        this.HexObj = (HexClass[,]) info.GetValue(nameof (HexObj), this.HexObj.GetType());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        byte[] numArray1 = new byte[info.GetInt32("DataSize") + 1];
        Stream input = (Stream) new MemoryStream((byte[]) info.GetValue("Data", numArray1.GetType()));
        BinaryReader br = new BinaryReader(input);
        int mapWidth = this.MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            this.HexObj[index1, index2] = new HexClass(0, 0, 0);
            this.HexObj[index1, index2].StreamRead(ref br);
          }
        }
        byte[] numArray2 = new byte[1];
        br.Close();
        input.Close();
        ProjectData.ClearProjectError();
      }
      this.MapLoop = info.GetBoolean(nameof (MapLoop));
      try
      {
        this.CanSee = info.GetBoolean(nameof (CanSee));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.CanSee = false;
        ProjectData.ClearProjectError();
      }
    }

    public MapClass(int hardcoded, int regimecount, int w, int h)
    {
      this.HexObj = new HexClass[1, 1];
      this.Name = "New Extra Map";
      this.MapWidth = w;
      this.MapHeight = h;
      this.MapLoop = false;
      this.CanSee = false;
      this.HexObj = new HexClass[w + 1, h + 1];
      int num1 = w;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = h;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          this.HexObj[index1, index2] = new HexClass(0, regimecount, regimecount);
          this.HexObj[index1, index2].Location2 = -1;
        }
      }
    }
  }
}
