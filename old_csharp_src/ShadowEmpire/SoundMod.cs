// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SoundMod
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using IrrKlang;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  [StandardModule]
  public sealed class SoundMod
  {
    public static string LastSong;
    private static ISoundEngine engine;
    private static ISoundSource medley;
    private static ISound eventsound;
    private static ISound eventsoundbg;
    public static bool NOSOUND;
    public static bool SYSTEMFAILURE = false;
    public static int dssSoundCounter;
    public static int dssSoundMaxCounter = 9;
    private static ISound[] dssSoundRef = new ISound[10];
    private static int[] dssStatus = new int[10];
    private static int[] dssType = new int[10];
    private static int[] dssId = new int[10];
    private static int[] dssMsMark = new int[10];
    private static DateTime startDatetime;
    public static int DSS_FADE_MS = 5000;
    public static int DSS_MARGIN_MS = 300;

    public static void InitSound(Form FormHandle)
    {
      try
      {
        SoundMod.engine = new ISoundEngine();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        SoundMod.NOSOUND = true;
        SoundMod.SYSTEMFAILURE = true;
        ProjectData.ClearProjectError();
      }
      SoundMod.dssSoundCounter = -1;
      SoundMod.startDatetime = DateAndTime.Now;
    }

    public static void PlayAWave(
      string Soundfile,
      ref EditClass teditobj,
      bool overrule = false,
      int volumeMod = 0)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
        return;
      string str = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        str = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(str, "", false) == 0)
        str = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("sound", str);
      if (!Information.IsNothing((object) SoundMod.eventsound) && SoundMod.eventsound.Finished)
      {
        SoundMod.eventsound.Dispose();
        SoundMod.eventsound = (ISound) null;
      }
      if (!(teditobj.SoundOn | overrule) || !File.Exists(Soundfile))
        return;
      SoundMod.eventsound = SoundMod.engine.Play2D(Soundfile, false);
      if (Information.IsNothing((object) SoundMod.eventsound))
        return;
      if (volumeMod > 0)
        SoundMod.eventsound.Volume = Math.Min(1f, (float) ((double) teditobj.Volume2 / 100.0 * ((double) volumeMod / 100.0)));
      else
        SoundMod.eventsound.Volume = (float) teditobj.Volume2 / 100f;
    }

    public static void PlayEventWave(string Soundfile, ref EditClass teditobj)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
        return;
      string str = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        str = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(str, "", false) == 0)
        str = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("sound", str);
      if (!teditobj.SoundOn || !File.Exists(Soundfile))
        return;
      SoundMod.eventsound = SoundMod.engine.Play2D(Soundfile, false);
      if (Information.IsNothing((object) SoundMod.eventsound))
        return;
      SoundMod.eventsound.Volume = (float) teditobj.Volume2 / 100f;
    }

    public static void STopEventWave()
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.eventsound))
        return;
      SoundMod.eventsound.Stop();
    }

    public static void RestartLastBackground(ref EditClass teditobj)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.LastSong))
        return;
      string lastSong = SoundMod.LastSong;
      SoundMod.LastSong = "";
      SoundMod.PlayEventBackground(lastSong, ref teditobj);
    }

    public static void PlayEventBackground(string Soundfile, ref EditClass teditobj)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
        return;
      Soundfile = Soundfile.Replace("\\", "/");
      string Left = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        Left = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(Left, "", false) == 0)
        Left = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("/sound/", "/" + Left + "/");
      if (!Information.IsNothing((object) SoundMod.eventsoundbg) && Operators.CompareString(SoundMod.LastSong, Soundfile, false) == 0 & !SoundMod.eventsoundbg.Finished)
        return;
      SoundMod.LastSong = Soundfile;
      string str = Soundfile;
      try
      {
        if (!Information.IsNothing((object) teditobj) & !Information.IsNothing((object) DrawMod.TGame))
        {
          if (teditobj.AlternateMusic)
          {
            if ((double) DrawMod.TGame.Data.RuleVar[990] == 1.0)
            {
              if (Strings.InStr(Soundfile, ".") > 0)
                Soundfile = Soundfile.Replace(".", "_alternate.");
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Soundfile = str;
        ProjectData.ClearProjectError();
      }
      if (!teditobj.IntroSoundOn || !File.Exists(Soundfile))
        return;
      if (!Information.IsNothing((object) SoundMod.eventsoundbg))
      {
        SoundMod.eventsoundbg.Stop();
        SoundMod.eventsoundbg = (ISound) null;
      }
      SoundMod.eventsoundbg = SoundMod.engine.Play2D(Soundfile, true);
      if (Information.IsNothing((object) SoundMod.eventsoundbg))
        return;
      SoundMod.eventsoundbg.Volume = (float) teditobj.Volume / 100f;
    }

    public static void ChangeEventSoundBg(EditClass teditobj)
    {
      if (SoundMod.SYSTEMFAILURE)
        return;
      if (!Information.IsNothing((object) SoundMod.eventsoundbg))
        SoundMod.eventsoundbg.Volume = (float) teditobj.Volume / 100f;
      int index = 0;
      do
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[index]))
          SoundMod.dssSoundRef[index].Volume = (float) teditobj.Volume / 100f;
        ++index;
      }
      while (index <= 9);
    }

    public static void ChangeEventSound(EditClass teditobj)
    {
      if (SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.eventsound))
        return;
      SoundMod.eventsound.Volume = (float) teditobj.Volume2 / 100f;
    }

    public static void STopEventBackground()
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.eventsoundbg))
        return;
      SoundMod.eventsoundbg.Stop();
      SoundMod.eventsoundbg.Dispose();
      SoundMod.eventsoundbg = (ISound) null;
    }

    public static void StopWave()
    {
      if (SoundMod.NOSOUND)
        return;
      if (SoundMod.SYSTEMFAILURE)
        return;
      try
      {
        SoundMod.engine.StopAllSounds();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static void EndSound()
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.engine))
        return;
      SoundMod.engine.StopAllSounds();
      SoundMod.engine.RemoveAllSoundSources();
    }

    public static void dssTimer(ref EditClass teditobj)
    {
      if (teditobj.IntroSoundOn & SoundMod.NOSOUND & !SoundMod.SYSTEMFAILURE)
        SoundMod.NOSOUND = false;
      if ((double) DrawMod.TGame.Data.RuleVar[446] < 1.0 | SoundMod.NOSOUND)
      {
        while (SoundMod.dssSoundCounter > -1)
          SoundMod.dssRemoveSoundSlot(SoundMod.dssSoundCounter);
      }
      else
      {
        if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
          return;
        if (!Information.IsNothing((object) SoundMod.eventsoundbg))
        {
          SoundMod.eventsoundbg.Stop();
          SoundMod.eventsoundbg.Dispose();
          SoundMod.eventsoundbg = (ISound) null;
        }
        for (int dssSoundCounter = SoundMod.dssSoundCounter; dssSoundCounter >= 0; dssSoundCounter += -1)
        {
          if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSoundCounter]))
          {
            if (SoundMod.dssSoundRef[dssSoundCounter].Finished)
              SoundMod.dssRemoveSoundSlot(dssSoundCounter);
          }
          else
            SoundMod.dssRemoveSoundSlot(dssSoundCounter);
        }
        bool flag = true;
        int index1 = -1;
        int dssSoundCounter1 = SoundMod.dssSoundCounter;
        for (int index2 = 0; index2 <= dssSoundCounter1; ++index2)
        {
          if (!Information.IsNothing((object) SoundMod.dssSoundRef[index2]) && !SoundMod.dssSoundRef[index2].Finished && SoundMod.dssType[index2] == 1)
          {
            flag = false;
            index1 = index2;
          }
        }
        if (flag)
          SoundMod.dssNew(ref teditobj);
        if (!flag)
          SoundMod.dssAdjust(ref teditobj);
        if (flag)
          return;
        int id = (int) Math.Round((double) DrawMod.TGame.Data.RuleVar[447]);
        int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id);
        if (stringListById <= -1)
          return;
        int length = DrawMod.TGame.Data.StringListObj[stringListById].Length;
        for (int index3 = 0; index3 <= length; ++index3)
        {
          if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[index3, 0]) == (double) SoundMod.dssId[index1] && (double) teditobj.dssLastDominant != Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[index3, 2]))
          {
            SoundMod.dssEnd(ref teditobj);
            break;
          }
        }
      }
    }

    public static void dssEnd(ref EditClass teditobj)
    {
      int num = (int) Math.Round((DateAndTime.Now - SoundMod.startDatetime).TotalMilliseconds);
      for (int dssSoundCounter = SoundMod.dssSoundCounter; dssSoundCounter >= 0; dssSoundCounter += -1)
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSoundCounter]) & SoundMod.dssStatus[dssSoundCounter] != 3)
        {
          SoundMod.dssStatus[dssSoundCounter] = 3;
          SoundMod.dssMsMark[dssSoundCounter] = num;
        }
      }
    }

    public static void dssAdjust(ref EditClass teditobj)
    {
      bool flag1 = true;
      bool flag2 = true;
      int id1 = (int) Math.Round((double) DrawMod.TGame.Data.RuleVar[448]);
      int stringListById1 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id1);
      if (stringListById1 < 0 | id1 < 1)
        flag2 = false;
      int id2 = (int) Math.Round((double) DrawMod.TGame.Data.RuleVar[449]);
      int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id2);
      if (stringListById2 < 0 | id2 < 1)
        flag1 = false;
      if (flag2 & flag1)
      {
        int dssSoundCounter1 = SoundMod.dssSoundCounter;
        for (int index1 = 0; index1 <= dssSoundCounter1; ++index1)
        {
          if (!Information.IsNothing((object) SoundMod.dssSoundRef[index1]) && !SoundMod.dssSoundRef[index1].Finished && SoundMod.dssType[index1] == 1)
          {
            int playPosition = (int) SoundMod.dssSoundRef[index1].PlayPosition;
            bool flag3 = true;
            int dssSoundCounter2 = SoundMod.dssSoundCounter;
            for (int index2 = 0; index2 <= dssSoundCounter2; ++index2)
            {
              if (!Information.IsNothing((object) SoundMod.dssSoundRef[index2]) && !SoundMod.dssSoundRef[index2].Finished && SoundMod.dssType[index2] == 2)
                flag3 = false;
            }
            if (flag3)
            {
              SimpleList simpleList1 = new SimpleList();
              int length1 = DrawMod.TGame.Data.StringListObj[stringListById1].Length;
              for (int tid = 0; tid <= length1; ++tid)
              {
                if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById1].Data[tid, 1]) == (double) SoundMod.dssId[index1] && Math.Abs(playPosition - Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById1].Data[tid, 2])) <= SoundMod.DSS_MARGIN_MS)
                  simpleList1.Add(tid, DrawMod.RandyNumber.Next(0, 100));
              }
              if (simpleList1.Counter > -1)
              {
                simpleList1.Sort();
                int index3 = simpleList1.Id[0];
                int integer1 = Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById1].Data[index3, 3]);
                int integer2 = Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById1].Data[index3, 4]);
                SimpleList simpleList2 = new SimpleList();
                int length2 = DrawMod.TGame.Data.StringListObj[stringListById2].Length;
                for (int tid = 0; tid <= length2; ++tid)
                {
                  if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById2].Data[tid, 2]) == (double) integer1 && Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById2].Data[tid, 3]) == (double) integer2)
                    simpleList2.Add(tid, DrawMod.RandyNumber.Next(0, 100));
                }
                if (simpleList2.Counter > -1)
                {
                  simpleList2.Sort();
                  int index4 = simpleList2.Id[0];
                  SoundMod.dssAddSoundSlot();
                  string str = DrawMod.TGame.Data.StringListObj[stringListById2].Data[index4, 1];
                  SoundMod.dssStartSound(ref teditobj, SoundMod.dssSoundCounter, DrawMod.TGame.AppPath + "sound/" + str, 2, 2, 1f, Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById2].Data[index4, 0]), false);
                }
              }
            }
          }
        }
      }
      int num1 = (int) Math.Round((DateAndTime.Now - SoundMod.startDatetime).TotalMilliseconds);
      for (int dssSoundCounter = SoundMod.dssSoundCounter; dssSoundCounter >= 0; dssSoundCounter += -1)
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSoundCounter]) && !SoundMod.dssSoundRef[dssSoundCounter].Finished && SoundMod.dssStatus[dssSoundCounter] == 3)
        {
          int num2 = num1 - SoundMod.dssMsMark[dssSoundCounter];
          if (num2 > SoundMod.DSS_FADE_MS)
            SoundMod.dssRemoveSoundSlot(dssSoundCounter);
          else if (num2 > 0)
            SoundMod.dssSoundRef[dssSoundCounter].Volume = (float) (1.0 - (double) num2 / (double) SoundMod.DSS_FADE_MS) * ((float) teditobj.Volume / 100f);
        }
      }
    }

    public static void dssNew(ref EditClass teditobj)
    {
      int id = (int) Math.Round((double) DrawMod.TGame.Data.RuleVar[447]);
      int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id);
      if (stringListById < 0 || teditobj.dssLastDominant < 0 & DrawMod.TGame.Data.Product == 7)
        return;
      SimpleList simpleList = new SimpleList();
      if (!teditobj.IntroSoundOn)
        return;
      int length = DrawMod.TGame.Data.StringListObj[stringListById].Length;
      for (int tid = 0; tid <= length; ++tid)
      {
        bool flag = false;
        if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[tid, 2]) == -1.0)
          flag = true;
        if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[tid, 2]) == (double) teditobj.dssLastDominant)
          flag = true;
        if (teditobj.dssLastDominant == -1)
          flag = true;
        if (flag)
          simpleList.Add(tid, DrawMod.RandyNumber.Next(0, 100));
      }
      int index;
      if (simpleList.Counter > -1)
      {
        simpleList.Sort();
        index = simpleList.Id[0];
      }
      else
        index = -1;
      if (index <= -1)
        return;
      SoundMod.dssAddSoundSlot();
      string str = DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 1];
      if (simpleList.Counter == 0)
        SoundMod.dssStartSound(ref teditobj, SoundMod.dssSoundCounter, DrawMod.TGame.AppPath + "sound/" + str, 2, 1, 1f, Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 0]), true);
      else
        SoundMod.dssStartSound(ref teditobj, SoundMod.dssSoundCounter, DrawMod.TGame.AppPath + "sound/" + str, 2, 1, 1f, Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 0]), false);
    }

    public static void dssStartSound(
      ref EditClass teditobj,
      int dssSlotNr,
      string Soundfile,
      int tStatus,
      int tType,
      float tVolume,
      int tId,
      bool tLoop)
    {
      Soundfile = Soundfile.Replace("\\", "/");
      string Left = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        Left = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(Left, "", false) == 0)
        Left = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("/sound/", "/" + Left + "/");
      if (!teditobj.IntroSoundOn || !File.Exists(Soundfile))
        return;
      if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSlotNr]))
      {
        SoundMod.dssSoundRef[dssSlotNr].Stop();
        SoundMod.dssSoundRef[dssSlotNr] = (ISound) null;
      }
      SoundMod.dssSoundRef[dssSlotNr] = !tLoop ? SoundMod.engine.Play2D(Soundfile, false) : SoundMod.engine.Play2D(Soundfile, true);
      if (Information.IsNothing((object) SoundMod.dssSoundRef[dssSlotNr]))
        return;
      int num = (int) Math.Round((DateAndTime.Now - SoundMod.startDatetime).TotalMilliseconds);
      SoundMod.dssType[dssSlotNr] = tType;
      SoundMod.dssId[dssSlotNr] = tId;
      SoundMod.dssStatus[dssSlotNr] = tStatus;
      SoundMod.dssMsMark[dssSlotNr] = num;
      SoundMod.dssSoundRef[dssSlotNr].Volume = (float) ((double) tVolume * (double) teditobj.Volume / 100.0);
    }

    public static void dssAddSoundSlot()
    {
      if (SoundMod.dssSoundCounter >= SoundMod.dssSoundMaxCounter)
      {
        int num = (int) Interaction.MsgBox((object) "DSS Sound slot overload");
      }
      else
      {
        ++SoundMod.dssSoundCounter;
        SoundMod.dssSoundRef[SoundMod.dssSoundCounter] = (ISound) null;
        SoundMod.dssStatus[SoundMod.dssSoundCounter] = 0;
        SoundMod.dssType[SoundMod.dssSoundCounter] = 0;
        SoundMod.dssId[SoundMod.dssSoundCounter] = 0;
        SoundMod.dssMsMark[SoundMod.dssSoundCounter] = 0;
      }
    }

    public static void dssRemoveSoundSlot(int slot)
    {
      if (slot < 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Negative DSS Sound slot removal");
      }
      else if (slot > SoundMod.dssSoundCounter)
      {
        int num2 = (int) Interaction.MsgBox((object) "To high DSS Sound slot removal");
      }
      else
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[slot]))
        {
          SoundMod.dssSoundRef[slot].Stop();
          SoundMod.dssSoundRef[slot] = (ISound) null;
        }
        int num3 = slot;
        int dssSoundCounter = SoundMod.dssSoundCounter;
        for (int index = num3; index <= dssSoundCounter; ++index)
        {
          if (index + 1 <= SoundMod.dssSoundCounter)
          {
            SoundMod.dssSoundRef[index] = SoundMod.dssSoundRef[index + 1];
            SoundMod.dssStatus[index] = SoundMod.dssStatus[index + 1];
            SoundMod.dssType[index] = SoundMod.dssType[index + 1];
            SoundMod.dssId[index] = SoundMod.dssId[index + 1];
            SoundMod.dssMsMark[index] = SoundMod.dssMsMark[index + 1];
          }
        }
        --SoundMod.dssSoundCounter;
      }
    }
  }
}
