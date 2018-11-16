using System;
using System.Collections.Generic;

namespace QFrameWork
{
    public interface ILoadManager
    {
        string LoadText(string path);

        Dictionary<string, string> LoadCsv(string path);

        T LoadJson<T>(string path);

        string DataPath();

        string StreamingAssetsPath();
    }
}
