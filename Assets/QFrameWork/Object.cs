using System;
using System.Collections.Generic;
using UnityEngine;

namespace QFrameWork
{
    public class Object : IObject
    {
        public string LoadText(string path)
        {
            return this.loadManager.LoadText(path);
        }

        public Dictionary<string, string> LoadCsv(string path)
        {
            return this.loadManager.LoadCsv(path);
        }

        public string DataPath()
        {
            return this.loadManager.DataPath();
        }

        public string StreamimgAssetsPath()
        {
            return this.loadManager.StreamingAssetsPath();
        }

        public void Subscribe(string str, Action<object, object> handler)
        {
            this.eventDispatcher.Subscribe(str, handler);
        }

        public void UnSubscribe(string str, Action<object, object> handler)
        {
            this.eventDispatcher.UnSubscribe(str, handler);
        }

        public void Post(string str)
        {
            this.Post(str, null, null);
        }

        public void Post(string str, object sender, object args)
        {
            this.eventDispatcher.Post(str, sender, args);
        }

        public void ChangeProcedure(Msg msg)
        {
            this.proceduceManager.ChangeProcedure(msg);
        }

        public void LoadProceduces(List<Msg> msgs)
        {
            this.proceduceManager.LoadProceduces(msgs);
        }

        public void CacheAudioClip(string name,AudioClip audioClip)
        {
            this.audioManager.CacheAudioClip(name ,audioClip);
        }

        public void PlayBgm(string name, bool loop = true)
        {
            this.audioManager.PlayBgm(name, loop);
        }

        public void PlaySfx(string name)
        {
            this.audioManager.PlaySfx(name);
        }

        public void SaveConfig()
        {
            this.audioManager.SaveConfig();
        }

        public void Mute()
        {
            this.audioManager.Mute();
        }

        public void Resume()
        {
            this.audioManager.Resume();
        }

        public void SetBgmVolume(float volume)
        {
            this.audioManager.SetBgmVolume(volume);
        }

        public void SetSfxVolume(float volume)
        {
            this.audioManager.SetSfxVolume(volume);
        }

        public float GetBgmVolume()
        {
            return this.audioManager.GetBgmVolume();
        }

        public float GetSfxVolume()
        {
            return this.audioManager.GetSfxVolume();
        }

        public void HttpSend(string url, int timeout, Action<object> onSuccessCallback, Action<object> onFailCallback)
        {
            this.networkManager.HttpSend(url, timeout, onSuccessCallback, onFailCallback);
        }

        public IApp app
        {
            get
            {
                return Global.app;
            }
        }

        public IEventDispatcher eventDispatcher
        {
            get { return Global.eventDispatcher; }
        }

        public ILoadManager loadManager
        {
            get { return Global.loadManager; }
        }

        public IResourcesManager resourcesManager
        {
            get { return Global.resourcesManager; }
        }

        public ISceneManager sceneManager
        {
            get { return Global.sceneManager; }
        }

        public IUIManager uiManager
        {
            get { return Global.uiManager; }
        }

        public IProcedureManager proceduceManager
        {
            get { return Global.proceduceManager; }
        }

        public IAudioManager audioManager
        {
            get { return Global.audioManager; }
        }

        public INetworkManager networkManager
        {
            get { return Global.networkManager; }
        }
    }
}
