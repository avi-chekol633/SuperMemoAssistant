﻿using SuperMemoAssistant.Interop.SuperMemo.Components.Models;
using SuperMemoAssistant.Interop.SuperMemo.Components.Types;
using SuperMemoAssistant.Interop.SuperMemo.Registry.Members;
using SuperMemoAssistant.SuperMemo.SuperMemo17.Files;

namespace SuperMemoAssistant.SuperMemo.SuperMemo17.Components.Types
{
  public class ComponentVideo : ComponentBase, IComponentVideo
  {
    protected int VideoId { get; set; }

    public ComponentVideo(InfComponentsVideo comp)
      : base(comp.left, comp.top, comp.right, comp.bottom, (AtFlags)comp.displayAt)
    {
      VideoId = SetValue(comp.registryId, nameof(VideoId));
      IsContinuous = SetValue(comp.isContinuous, nameof(IsContinuous));
      IsFullScreen = SetValue(comp.isFullScreen, nameof(IsFullScreen));
      ExtractStart = SetValue(comp.extractStart, nameof(ExtractStart));
      ExtractStop = SetValue(comp.extractStop, nameof(ExtractStop));
      Panel = SetValue((MediaPanelType)comp.panel, nameof(Panel));
    }

    public void Update(InfComponentsVideo comp)
    {
      ComponentFieldFlags flags = ComponentFieldFlags.None;

      VideoId = SetValue(VideoId, comp.registryId, nameof(VideoId), ref flags);
      IsContinuous = SetValue(IsContinuous, comp.isContinuous, nameof(IsContinuous), ref flags);
      IsFullScreen = SetValue(IsFullScreen, comp.isFullScreen, nameof(IsFullScreen), ref flags);
      ExtractStart = SetValue(ExtractStart, comp.extractStart, nameof(ExtractStart), ref flags);
      ExtractStop = SetValue(ExtractStop, comp.extractStop, nameof(ExtractStop), ref flags);
      Panel = SetValue(Panel, (MediaPanelType)comp.panel, nameof(Panel), ref flags);

      base.Update(
        comp.left, comp.top,
        comp.right, comp.bottom,
        (AtFlags)comp.displayAt,
        flags
      );
    }

    public IVideo Video => SMA.Instance.Registry.Video?[VideoId];
    public bool IsContinuous { get; set; }
    public bool IsFullScreen { get; set; }
    public uint ExtractStart { get; set; }
    public uint ExtractStop { get; set; }
    public MediaPanelType Panel { get; set; }
  }
}
