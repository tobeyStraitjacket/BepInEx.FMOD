using BepInEx;
using FMOD;
using FMODUnity;
using System;

namespace BepInEx.FMOD
{
    internal static class Utils
    {
        public static Sound CreateSound(string path, MODE mode = MODE.DEFAULT)
        {
            var soundFilePath = new Uri(path);
            var gameDirectoryPath = new Uri(Paths.BepInExRootPath);
            var diff = gameDirectoryPath.MakeRelativeUri(soundFilePath);

            RuntimeManager.LowlevelSystem.createSound(Uri.UnescapeDataString(diff.OriginalString), mode, out Sound sound);

            return sound;
        }

        public static Channel PlaySound(Sound sound)
        {
            RuntimeManager.LowlevelSystem.getMasterChannelGroup(out ChannelGroup channelGroup);
            RuntimeManager.LowlevelSystem.playSound(sound, channelGroup, false, out Channel channel);
            return channel;
        }
        public static Channel PlaySound(string path, MODE mode = MODE.DEFAULT)
            => PlaySound(CreateSound(path, mode));

        public static Channel PlaySound(Sound sound, ChannelGroup channelGroup)
        {
            RuntimeManager.LowlevelSystem.playSound(sound, channelGroup, false, out var channel);
            return channel;
        }
        public static Channel PlaySound(string path, ChannelGroup channelGroup, MODE mode = MODE.DEFAULT)
            => PlaySound(CreateSound(path, mode), channelGroup);
    }
}
