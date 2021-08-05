using System;
using System.IO;

namespace Panosen.Storage.Local
{
    /// <summary>
    /// 保存文件到本地
    /// </summary>
    public class LocalStorage
    {
        private readonly LocalConfig localConfig;

        /// <summary>
        /// 保存文件到本地
        /// </summary>
        public LocalStorage(LocalConfig qiniuConfig)
        {
            this.localConfig = qiniuConfig;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        public void Save(string key, byte[] bytes)
        {
            var path = Path.Combine(localConfig.Folder, key);

            var folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.WriteAllBytes(path, bytes);
        }
    }
}
